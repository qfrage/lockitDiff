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
            this.connectToSheetButton.Location = new System.Drawing.Point(346, 36);
            this.connectToSheetButton.Name = "connectToSheetButton";
            this.connectToSheetButton.Size = new System.Drawing.Size(75, 23);
            this.connectToSheetButton.TabIndex = 4;
            this.connectToSheetButton.Text = "Connect";
            this.connectToSheetButton.UseVisualStyleBackColor = true;
            this.connectToSheetButton.Click += new System.EventHandler(this.connectToSheetButton_Click);
            // 
            // browseDirectoryButton
            // 
            this.browseDirectoryButton.Location = new System.Drawing.Point(346, 82);
            this.browseDirectoryButton.Name = "browseDirectoryButton";
            this.browseDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.browseDirectoryButton.TabIndex = 5;
            this.browseDirectoryButton.Text = "Browse";
            this.browseDirectoryButton.UseVisualStyleBackColor = true;
            this.browseDirectoryButton.Click += new System.EventHandler(this.browseDirectoryButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 671);
            this.Controls.Add(this.browseDirectoryButton);
            this.Controls.Add(this.connectToSheetButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spreadsheetIDLabel);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.sheetIDTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

