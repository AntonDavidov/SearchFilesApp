namespace SearchingFileApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.searchedFilesTreeView = new System.Windows.Forms.TreeView();
            this.searchOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.filePatternTextBox = new System.Windows.Forms.TextBox();
            this.searchOptionComboBox = new System.Windows.Forms.ComboBox();
            this.searchingTxtLabel = new System.Windows.Forms.Label();
            this.filePatternLabel = new System.Windows.Forms.Label();
            this.startDirPathLabel = new System.Windows.Forms.Label();
            this.searchingTxtTextBox = new System.Windows.Forms.TextBox();
            this.openDirButton = new System.Windows.Forms.Button();
            this.startDirPathTextBox = new System.Windows.Forms.TextBox();
            this.start_continueSearchButton = new System.Windows.Forms.Button();
            this.stopSearchButton = new System.Windows.Forms.Button();
            this.searchProgressGroupBox = new System.Windows.Forms.GroupBox();
            this.processedTimeViewLabel = new System.Windows.Forms.Label();
            this.processedFilesNumViewLabel = new System.Windows.Forms.Label();
            this.processedFileViewLabel = new System.Windows.Forms.Label();
            this.processTimeLabel = new System.Windows.Forms.Label();
            this.processedFilesNumLabel = new System.Windows.Forms.Label();
            this.processedFileLabel = new System.Windows.Forms.Label();
            this.closeAppButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.searchOptionsGroupBox.SuspendLayout();
            this.searchProgressGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchedFilesTreeView
            // 
            this.searchedFilesTreeView.Location = new System.Drawing.Point(13, 131);
            this.searchedFilesTreeView.Name = "searchedFilesTreeView";
            this.searchedFilesTreeView.Size = new System.Drawing.Size(212, 182);
            this.searchedFilesTreeView.TabIndex = 0;
            this.searchedFilesTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SearchedFilesTreeView_MouseDoubleClick);
            // 
            // searchOptionsGroupBox
            // 
            this.searchOptionsGroupBox.Controls.Add(this.filePatternTextBox);
            this.searchOptionsGroupBox.Controls.Add(this.searchOptionComboBox);
            this.searchOptionsGroupBox.Controls.Add(this.searchingTxtLabel);
            this.searchOptionsGroupBox.Controls.Add(this.filePatternLabel);
            this.searchOptionsGroupBox.Controls.Add(this.startDirPathLabel);
            this.searchOptionsGroupBox.Controls.Add(this.searchingTxtTextBox);
            this.searchOptionsGroupBox.Controls.Add(this.openDirButton);
            this.searchOptionsGroupBox.Controls.Add(this.startDirPathTextBox);
            this.searchOptionsGroupBox.Location = new System.Drawing.Point(13, 13);
            this.searchOptionsGroupBox.Name = "searchOptionsGroupBox";
            this.searchOptionsGroupBox.Size = new System.Drawing.Size(593, 112);
            this.searchOptionsGroupBox.TabIndex = 1;
            this.searchOptionsGroupBox.TabStop = false;
            this.searchOptionsGroupBox.Text = "Параметры поиска файлов";
            // 
            // filePatternTextBox
            // 
            this.filePatternTextBox.Location = new System.Drawing.Point(207, 48);
            this.filePatternTextBox.Name = "filePatternTextBox";
            this.filePatternTextBox.Size = new System.Drawing.Size(195, 20);
            this.filePatternTextBox.TabIndex = 8;
            this.filePatternTextBox.Text = "*.txt";
            // 
            // searchOptionComboBox
            // 
            this.searchOptionComboBox.FormattingEnabled = true;
            this.searchOptionComboBox.Items.AddRange(new object[] {
            "строго как в тексте",
            "любое из слов",
            "все слова в любом порядке"});
            this.searchOptionComboBox.Location = new System.Drawing.Point(420, 80);
            this.searchOptionComboBox.Name = "searchOptionComboBox";
            this.searchOptionComboBox.Size = new System.Drawing.Size(167, 21);
            this.searchOptionComboBox.TabIndex = 7;
            // 
            // searchingTxtLabel
            // 
            this.searchingTxtLabel.AutoSize = true;
            this.searchingTxtLabel.Location = new System.Drawing.Point(7, 81);
            this.searchingTxtLabel.Name = "searchingTxtLabel";
            this.searchingTxtLabel.Size = new System.Drawing.Size(121, 13);
            this.searchingTxtLabel.TabIndex = 5;
            this.searchingTxtLabel.Text = "Ищем файл с текстом";
            // 
            // filePatternLabel
            // 
            this.filePatternLabel.AutoSize = true;
            this.filePatternLabel.Location = new System.Drawing.Point(6, 51);
            this.filePatternLabel.Name = "filePatternLabel";
            this.filePatternLabel.Size = new System.Drawing.Size(116, 13);
            this.filePatternLabel.TabIndex = 4;
            this.filePatternLabel.Text = "Шаблон имени файла";
            // 
            // startDirPathLabel
            // 
            this.startDirPathLabel.AutoSize = true;
            this.startDirPathLabel.Location = new System.Drawing.Point(7, 22);
            this.startDirPathLabel.Name = "startDirPathLabel";
            this.startDirPathLabel.Size = new System.Drawing.Size(182, 13);
            this.startDirPathLabel.TabIndex = 3;
            this.startDirPathLabel.Text = "Стартовая директория для поиска";
            // 
            // searchingTxtTextBox
            // 
            this.searchingTxtTextBox.Location = new System.Drawing.Point(207, 78);
            this.searchingTxtTextBox.Name = "searchingTxtTextBox";
            this.searchingTxtTextBox.Size = new System.Drawing.Size(195, 20);
            this.searchingTxtTextBox.TabIndex = 1;
            // 
            // openDirButton
            // 
            this.openDirButton.Location = new System.Drawing.Point(420, 19);
            this.openDirButton.Name = "openDirButton";
            this.openDirButton.Size = new System.Drawing.Size(75, 23);
            this.openDirButton.TabIndex = 2;
            this.openDirButton.Text = "Открыть";
            this.openDirButton.UseVisualStyleBackColor = true;
            this.openDirButton.Click += new System.EventHandler(this.OpenDirButton_Click);
            // 
            // startDirPathTextBox
            // 
            this.startDirPathTextBox.Location = new System.Drawing.Point(207, 19);
            this.startDirPathTextBox.Name = "startDirPathTextBox";
            this.startDirPathTextBox.Size = new System.Drawing.Size(195, 20);
            this.startDirPathTextBox.TabIndex = 0;
            // 
            // start_continueSearchButton
            // 
            this.start_continueSearchButton.Location = new System.Drawing.Point(612, 30);
            this.start_continueSearchButton.Name = "start_continueSearchButton";
            this.start_continueSearchButton.Size = new System.Drawing.Size(152, 23);
            this.start_continueSearchButton.TabIndex = 3;
            this.start_continueSearchButton.Text = "Запустить поиск";
            this.start_continueSearchButton.UseVisualStyleBackColor = true;
            this.start_continueSearchButton.Click += new System.EventHandler(this.StartSearchButton_Click);
            // 
            // stopSearchButton
            // 
            this.stopSearchButton.Location = new System.Drawing.Point(612, 59);
            this.stopSearchButton.Name = "stopSearchButton";
            this.stopSearchButton.Size = new System.Drawing.Size(152, 23);
            this.stopSearchButton.TabIndex = 3;
            this.stopSearchButton.Text = "Остановить поиск";
            this.stopSearchButton.UseVisualStyleBackColor = true;
            this.stopSearchButton.Click += new System.EventHandler(this.StopSearchButton_Click);
            // 
            // searchProgressGroupBox
            // 
            this.searchProgressGroupBox.Controls.Add(this.processedTimeViewLabel);
            this.searchProgressGroupBox.Controls.Add(this.processedFilesNumViewLabel);
            this.searchProgressGroupBox.Controls.Add(this.processedFileViewLabel);
            this.searchProgressGroupBox.Controls.Add(this.processTimeLabel);
            this.searchProgressGroupBox.Controls.Add(this.processedFilesNumLabel);
            this.searchProgressGroupBox.Controls.Add(this.processedFileLabel);
            this.searchProgressGroupBox.Location = new System.Drawing.Point(230, 131);
            this.searchProgressGroupBox.Name = "searchProgressGroupBox";
            this.searchProgressGroupBox.Size = new System.Drawing.Size(534, 182);
            this.searchProgressGroupBox.TabIndex = 4;
            this.searchProgressGroupBox.TabStop = false;
            this.searchProgressGroupBox.Text = "Процесс поиска файлов";
            // 
            // processedTimeViewLabel
            // 
            this.processedTimeViewLabel.AutoSize = true;
            this.processedTimeViewLabel.Location = new System.Drawing.Point(156, 128);
            this.processedTimeViewLabel.Name = "processedTimeViewLabel";
            this.processedTimeViewLabel.Size = new System.Drawing.Size(0, 13);
            this.processedTimeViewLabel.TabIndex = 5;
            // 
            // processedFilesNumViewLabel
            // 
            this.processedFilesNumViewLabel.AutoSize = true;
            this.processedFilesNumViewLabel.Location = new System.Drawing.Point(156, 92);
            this.processedFilesNumViewLabel.Name = "processedFilesNumViewLabel";
            this.processedFilesNumViewLabel.Size = new System.Drawing.Size(0, 13);
            this.processedFilesNumViewLabel.TabIndex = 4;
            // 
            // processedFileViewLabel
            // 
            this.processedFileViewLabel.AutoSize = true;
            this.processedFileViewLabel.Location = new System.Drawing.Point(156, 42);
            this.processedFileViewLabel.MaximumSize = new System.Drawing.Size(350, 40);
            this.processedFileViewLabel.Name = "processedFileViewLabel";
            this.processedFileViewLabel.Size = new System.Drawing.Size(0, 13);
            this.processedFileViewLabel.TabIndex = 3;
            // 
            // processTimeLabel
            // 
            this.processTimeLabel.AutoSize = true;
            this.processTimeLabel.Location = new System.Drawing.Point(6, 128);
            this.processTimeLabel.Name = "processTimeLabel";
            this.processTimeLabel.Size = new System.Drawing.Size(82, 13);
            this.processTimeLabel.TabIndex = 2;
            this.processTimeLabel.Text = "Время поиска:";
            // 
            // processedFilesNumLabel
            // 
            this.processedFilesNumLabel.AutoSize = true;
            this.processedFilesNumLabel.Location = new System.Drawing.Point(6, 92);
            this.processedFilesNumLabel.Name = "processedFilesNumLabel";
            this.processedFilesNumLabel.Size = new System.Drawing.Size(113, 13);
            this.processedFilesNumLabel.TabIndex = 1;
            this.processedFilesNumLabel.Text = "Файлов обработано:";
            // 
            // processedFileLabel
            // 
            this.processedFileLabel.AutoSize = true;
            this.processedFileLabel.Location = new System.Drawing.Point(6, 42);
            this.processedFileLabel.Name = "processedFileLabel";
            this.processedFileLabel.Size = new System.Drawing.Size(143, 13);
            this.processedFileLabel.TabIndex = 0;
            this.processedFileLabel.Text = "Обрабатывающийся файл:";
            // 
            // closeAppButton
            // 
            this.closeAppButton.Location = new System.Drawing.Point(12, 319);
            this.closeAppButton.Name = "closeAppButton";
            this.closeAppButton.Size = new System.Drawing.Size(752, 23);
            this.closeAppButton.TabIndex = 5;
            this.closeAppButton.Text = "Закрыть приложение";
            this.closeAppButton.UseVisualStyleBackColor = true;
            this.closeAppButton.Click += new System.EventHandler(this.CloseAppButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(612, 91);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(152, 23);
            this.continueButton.TabIndex = 6;
            this.continueButton.Text = "Продолжить поиск";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 352);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.closeAppButton);
            this.Controls.Add(this.searchProgressGroupBox);
            this.Controls.Add(this.stopSearchButton);
            this.Controls.Add(this.start_continueSearchButton);
            this.Controls.Add(this.searchOptionsGroupBox);
            this.Controls.Add(this.searchedFilesTreeView);
            this.Name = "MainForm";
            this.Text = "Приложение для поиска файлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.searchOptionsGroupBox.ResumeLayout(false);
            this.searchOptionsGroupBox.PerformLayout();
            this.searchProgressGroupBox.ResumeLayout(false);
            this.searchProgressGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView searchedFilesTreeView;
        private System.Windows.Forms.GroupBox searchOptionsGroupBox;
        private System.Windows.Forms.Label searchingTxtLabel;
        private System.Windows.Forms.Label filePatternLabel;
        private System.Windows.Forms.Label startDirPathLabel;
        private System.Windows.Forms.TextBox searchingTxtTextBox;
        private System.Windows.Forms.Button openDirButton;
        private System.Windows.Forms.TextBox startDirPathTextBox;
        private System.Windows.Forms.Button start_continueSearchButton;
        private System.Windows.Forms.Button stopSearchButton;
        private System.Windows.Forms.GroupBox searchProgressGroupBox;
        private System.Windows.Forms.Button closeAppButton;
        private System.Windows.Forms.Label processTimeLabel;
        private System.Windows.Forms.Label processedFilesNumLabel;
        private System.Windows.Forms.Label processedFileLabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label processedTimeViewLabel;
        private System.Windows.Forms.Label processedFilesNumViewLabel;
        private System.Windows.Forms.Label processedFileViewLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox searchOptionComboBox;
        private System.Windows.Forms.TextBox filePatternTextBox;
    }
}

