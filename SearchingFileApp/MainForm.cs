﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchingFileApp
{
    /// <summary>
    /// Класс главной формы приложения
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        Task filesSearchTask;
        CancellationTokenSource cTS;
        ManualResetEventSlim mREvent;
        int timeLeft = 0;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            searchOptionComboBox.SelectedIndex = 0;
            searchOptionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Methods
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("savedInf.json"))
            {
                try
                {
                    string jsonSavedInf;
                    jsonSavedInf = File.ReadAllText("savedInf.json");
                    SavedInf savedInf = JsonConvert.DeserializeObject<SavedInf>(jsonSavedInf);
                    startDirPathTextBox.Text = savedInf.DirPath;
                    filePatternTextBox.Text = savedInf.FilePattern;
                    searchingTxtTextBox.Text = savedInf.SearchingText;
                }
                catch (Exception)
                {
                    MessageBox.Show("Нет возможности восcтановить предыдущие настройки. Файл либо повреждён, либо в него внесены некорректные изменения.", "Сообщение");
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavedInf savedInf = new SavedInf()
            {
                DirPath = startDirPathTextBox.Text,
                FilePattern = filePatternTextBox.Text,
                SearchingText = searchingTxtTextBox.Text
            };
            try
            {
                File.WriteAllText("savedInf.json", JsonConvert.SerializeObject(savedInf));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение");
            }
            if (cTS != null)
                cTS.Cancel();
        }
        private void OpenDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBD = new FolderBrowserDialog();
            fBD.ShowDialog();
            startDirPathTextBox.Text = fBD.SelectedPath;
        }
        private void StartSearchButton_Click(object sender, EventArgs e)
        {
            if (filesSearchTask != null)
            {
                mREvent.Set();
                cTS.Cancel();
                filesSearchTask.Wait();
            }

            cTS = new CancellationTokenSource();
            mREvent = new ManualResetEventSlim(true);
            int processedFileNum = 0;
            string dirPath = startDirPathTextBox.Text;
            Progress<string> processedFile = new Progress<string>(fileName =>
            {
                processedFileNum++;
                processedFileViewLabel.Text = fileName;
                processedFilesNumViewLabel.Text = processedFileNum.ToString();
            });
            Progress<string> searchedFile = new Progress<string>(fileName =>
            {
                List<string> pathParts = fileName.Split('\\').ToList();
                fileName = dirPath + "\\" + fileName;
                AddNodeToTreeView(searchedFilesTreeView.Nodes, pathParts, fileName);
            });
            Progress<bool> end = new Progress<bool>(stopTimer =>
            {
                timer.Stop();
                processedFileViewLabel.Text = "";
                MessageBox.Show("Поиск завершён", "Сообщение");
            });

            TextSearchOption textSearchOption;
            switch(searchOptionComboBox.SelectedItem as string)
            {
                case "любое из слов": {
                        textSearchOption = TextSearchOption.AnyWord;
                        break; }
                case "все слова в любом порядке": {
                        textSearchOption = TextSearchOption.AllWordsInAnyOrder;
                        break; }
                default: {
                        textSearchOption = TextSearchOption.StrongString;
                        break; }
            }
            searchedFilesTreeView.Nodes.Clear();
            filesSearchTask = SearchFilesAync(startDirPathTextBox.Text,
                                                filePatternTextBox.Text,
                                                searchingTxtTextBox.Text,
                                                textSearchOption,
                                                cTS.Token,
                                                processedFile,
                                                searchedFile,
                                                end);
            timeLeft = 0;
            processedFilesNumViewLabel.Text = "0";
            processedTimeViewLabel.Text = "0 сек";
            timer.Start();
        }
        private void StopSearchButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            mREvent.Reset();
        }
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            mREvent.Set();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLeft++;
            processedTimeViewLabel.Text = timeLeft.ToString() + " сек";
        }
        private void SearchedFilesTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(searchedFilesTreeView.SelectedNode.Tag as string);
        }
        private void CloseAppButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        #region Support Methods
        /// <summary>
        /// Метод, осуществляющий поиск файла в отдельном потоке
        /// </summary>
        /// <param name="dirPath">Стартовая папка для поиска</param>
        /// <param name="filePattern">Шаблон поиска файла</param>
        /// <param name="searchingText">Искомый текст</param>
        /// <param name="searchOption">Режим поиска</param>
        /// <param name="cToken">Токен отмены</param>
        /// <param name="processedFile">Передача из потока имени обрабатываемого файла</param>
        /// <param name="searchedFile">Передача из потока имени найденного файла</param>
        /// <param name="end">Передача из потока информации о том, что поиск завёршен</param>
        /// <returns></returns>
        Task SearchFilesAync(string dirPath,
                               string filePattern,
                               string searchingText,
                               TextSearchOption searchOption,
                               CancellationToken cToken,
                               IProgress<string> processedFile,
                               IProgress<string> searchedFile,
                               IProgress<bool> end)
        {
            return Task.Run(() =>
            {
                dirPath += "\\";
                IEnumerable<string> fileNames = Directory.EnumerateFiles(dirPath,
                                                                        filePattern,
                                                                        SearchOption.AllDirectories)
                                                     .Select(fileName => fileName.Replace(dirPath, ""));
                Regex regex;
                switch (searchOption)
                {
                    case TextSearchOption.AnyWord:
                        {
                            searchingText = "(" + searchingText.Replace(" ", "|") + ")";
                            regex = new Regex(searchingText, RegexOptions.IgnoreCase);
                            break;
                        }
                    case TextSearchOption.AllWordsInAnyOrder:
                        {
                            searchingText = "(" + searchingText.Replace(" ", "|") + ")";
                            regex = new Regex(searchingText);
                            MatchCollection matchCollection = regex.Matches(searchingText); ;
                            for (int i = 0; i < matchCollection.Count - 1; i++)
                            {
                                searchingText += ".+"+searchingText;
                            }
                            regex = new Regex(searchingText, RegexOptions.IgnoreCase);
                            break;
                        }
                    default:
                        {
                            regex = new Regex(searchingText, RegexOptions.IgnoreCase);
                            break;
                        }
                }

                foreach (var fileName in fileNames)
                {
                    mREvent.Wait();
                    if (cToken.IsCancellationRequested)
                    {
                        return;
                    }

                    processedFile.Report(dirPath + fileName);
                    Thread.Sleep(2);

                    if (File.Exists(dirPath + fileName))
                    {
                        string fileText = "";
                        try
                        {
                            fileText = File.ReadAllText(dirPath + fileName, Encoding.Default);
                        }
                        finally { }
                        if (fileText != "")
                            if (regex.IsMatch(fileText))
                            {
                                searchedFile.Report(fileName);
                                Thread.Sleep(2);
                            }
                    }
                }
                end.Report(true);
            }, cToken);
        }
        /// <summary>
        /// Метод, осуществляющий добавление в элемент управления TreeView нового TreeNode
        /// по ссылке на коллекцию 
        /// </summary>
        /// <param name="tNCollection">Ссылка на колекцию TreeNode элементов дерева TreeView</param>
        /// <param name="pathParts">Список частей относильного пути файла(относительно искомой 
        /// папки). Части пути - это строка, разбитая на массив строк имен всех содержащих папок
        /// и имени файла с удалёнными слешами.
        /// </param>
        /// <param name="fileName">Абсолютный путь файла</param>
        void AddNodeToTreeView(TreeNodeCollection tNCollection, List<string> pathParts, string fileName)
        {
            bool finded = false;
            if (tNCollection.Count != 0)
                foreach (TreeNode node in tNCollection)
                {
                    if (node.Text == pathParts[0])
                    {
                        finded = true;
                        pathParts.RemoveAt(0);
                        if (pathParts.Count > 0)
                            AddNodeToTreeView(node.Nodes, pathParts, fileName);
                        break;
                    }
                }
            if (!finded)
            {
                TreeNode treeNode = new TreeNode(pathParts[0]);
                tNCollection.Add(treeNode);
                pathParts.RemoveAt(0);
                if (pathParts.Count > 0)
                    AddNodeToTreeView(treeNode.Nodes, pathParts, fileName);
                else
                    treeNode.Tag = fileName;
            }
        }
        #endregion
        #endregion

        #region Internal
        public class SavedInf
        {
            public string DirPath { get; set; }
            public string FilePattern { get; set; }
            public string SearchingText { get; set; }
        }
        enum TextSearchOption
        {
            StrongString,
            AnyWord,
            AllWordsInAnyOrder
        }
        #endregion
    }
}
