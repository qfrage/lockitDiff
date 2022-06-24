namespace lockitDiff
{
    partial class Form1
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
            this.sheetIDTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.spreadsheetIDLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.connectToSheetButton = new System.Windows.Forms.Button();
            this.browseDirectoryButton = new System.Windows.Forms.Button();
            this.rangeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.currentSheetLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.allLanguageCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sheetIDTextBox
            // 
            this.sheetIDTextBox.Location = new System.Drawing.Point(12, 36);
            this.sheetIDTextBox.Name = "sheetIDTextBox";
            this.sheetIDTextBox.Size = new System.Drawing.Size(308, 22);
            this.sheetIDTextBox.TabIndex = 0;
            this.sheetIDTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(12, 84);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(308, 22);
            this.directoryTextBox.TabIndex = 1;
            this.directoryTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // spreadsheetIDLabel
            // 
            this.spreadsheetIDLabel.AutoSize = true;
            this.spreadsheetIDLabel.Location = new System.Drawing.Point(12, 17);
            this.spreadsheetIDLabel.Name = "spreadsheetIDLabel";
            this.spreadsheetIDLabel.Size = new System.Drawing.Size(100, 16);
            this.spreadsheetIDLabel.TabIndex = 2;
            this.spreadsheetIDLabel.Text = "SpreadSheetID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Directory";
            // 
            // connectToSheetButton
            // 
            this.connectToSheetButton.Location = new System.Drawing.Point(434, 35);
            this.connectToSheetButton.Name = "connectToSheetButton";
            this.connectToSheetButton.Size = new System.Drawing.Size(75, 23);
            this.connectToSheetButton.TabIndex = 4;
            this.connectToSheetButton.Text = "Connect";
            this.connectToSheetButton.UseVisualStyleBackColor = true;
            this.connectToSheetButton.Click += new System.EventHandler(this.connectToSheetButton_Click);
            // 
            // browseDirectoryButton
            // 
            this.browseDirectoryButton.Location = new System.Drawing.Point(328, 83);
            this.browseDirectoryButton.Name = "browseDirectoryButton";
            this.browseDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.browseDirectoryButton.TabIndex = 5;
            this.browseDirectoryButton.Text = "Browse";
            this.browseDirectoryButton.UseVisualStyleBackColor = true;
            this.browseDirectoryButton.Click += new System.EventHandler(this.browseDirectoryButton_Click);
            // 
            // rangeTextBox
            // 
            this.rangeTextBox.Location = new System.Drawing.Point(328, 36);
            this.rangeTextBox.Name = "rangeTextBox";
            this.rangeTextBox.Size = new System.Drawing.Size(100, 22);
            this.rangeTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Диапазон";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(824, 477);
            this.dataGridView1.TabIndex = 8;
            // 
            // currentSheetLabel
            // 
            this.currentSheetLabel.AutoSize = true;
            this.currentSheetLabel.Location = new System.Drawing.Point(582, 113);
            this.currentSheetLabel.Name = "currentSheetLabel";
            this.currentSheetLabel.Size = new System.Drawing.Size(0, 16);
            this.currentSheetLabel.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(585, 58);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(333, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 10;
            // 
            // allLanguageCheckBox
            // 
            this.allLanguageCheckBox.AutoSize = true;
            this.allLanguageCheckBox.Location = new System.Drawing.Point(15, 108);
            this.allLanguageCheckBox.Name = "allLanguageCheckBox";
            this.allLanguageCheckBox.Size = new System.Drawing.Size(95, 20);
            this.allLanguageCheckBox.TabIndex = 11;
            this.allLanguageCheckBox.Text = "Все языки";
            this.allLanguageCheckBox.UseVisualStyleBackColor = true;
            this.allLanguageCheckBox.CheckedChanged += new System.EventHandler(this.allLanguageCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 671);
            this.Controls.Add(this.allLanguageCheckBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.currentSheetLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeTextBox);
            this.Controls.Add(this.browseDirectoryButton);
            this.Controls.Add(this.connectToSheetButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spreadsheetIDLabel);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.sheetIDTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sheetIDTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Label spreadsheetIDLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button connectToSheetButton;
        private System.Windows.Forms.Button browseDirectoryButton;
        private System.Windows.Forms.TextBox rangeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label currentSheetLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox allLanguageCheckBox;
    }
}

