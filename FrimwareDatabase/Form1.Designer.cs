namespace FrimwareDatabase
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
            this.buttonOpenBinFile = new System.Windows.Forms.Button();
            this.buttonOpenHexFile = new System.Windows.Forms.Button();
            this.textBoxFileContent = new System.Windows.Forms.TextBox();
            this.textBoxCheckSum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCreateDataBase = new System.Windows.Forms.Button();
            this.buttonAddToDataBase = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // buttonOpenBinFile
            // 
            this.buttonOpenBinFile.Location = new System.Drawing.Point(208, 182);
            this.buttonOpenBinFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOpenBinFile.Name = "buttonOpenBinFile";
            this.buttonOpenBinFile.Size = new System.Drawing.Size(99, 43);
            this.buttonOpenBinFile.TabIndex = 0;
            this.buttonOpenBinFile.Text = ".bin file";
            this.buttonOpenBinFile.UseVisualStyleBackColor = true;
            this.buttonOpenBinFile.Click += new System.EventHandler(this.buttonOpenBinFile_Click);
            // 
            // buttonOpenHexFile
            // 
            this.buttonOpenHexFile.Location = new System.Drawing.Point(336, 182);
            this.buttonOpenHexFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOpenHexFile.Name = "buttonOpenHexFile";
            this.buttonOpenHexFile.Size = new System.Drawing.Size(99, 43);
            this.buttonOpenHexFile.TabIndex = 1;
            this.buttonOpenHexFile.Text = ".hex file";
            this.buttonOpenHexFile.UseVisualStyleBackColor = true;
            this.buttonOpenHexFile.Click += new System.EventHandler(this.buttonOpenHexFile_Click);
            // 
            // textBoxFileContent
            // 
            this.textBoxFileContent.Location = new System.Drawing.Point(208, 37);
            this.textBoxFileContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFileContent.Multiline = true;
            this.textBoxFileContent.Name = "textBoxFileContent";
            this.textBoxFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFileContent.Size = new System.Drawing.Size(227, 140);
            this.textBoxFileContent.TabIndex = 2;
            // 
            // textBoxCheckSum
            // 
            this.textBoxCheckSum.Location = new System.Drawing.Point(461, 37);
            this.textBoxCheckSum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCheckSum.Multiline = true;
            this.textBoxCheckSum.Name = "textBoxCheckSum";
            this.textBoxCheckSum.Size = new System.Drawing.Size(146, 52);
            this.textBoxCheckSum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Содержимое файла:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Контрольная сумма:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Для .bin файлов: \r\nАлгоритм хэширования MD5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Для .hex файлов: \r\nАлгоритм вычисления CRC32\r\n";
            // 
            // buttonCreateDataBase
            // 
            this.buttonCreateDataBase.Location = new System.Drawing.Point(12, 37);
            this.buttonCreateDataBase.Name = "buttonCreateDataBase";
            this.buttonCreateDataBase.Size = new System.Drawing.Size(188, 44);
            this.buttonCreateDataBase.TabIndex = 12;
            this.buttonCreateDataBase.Text = "Создать новую базу данных";
            this.buttonCreateDataBase.UseVisualStyleBackColor = true;
            this.buttonCreateDataBase.Click += new System.EventHandler(this.buttonCreateDataBase_Click);
            // 
            // buttonAddToDataBase
            // 
            this.buttonAddToDataBase.Location = new System.Drawing.Point(461, 182);
            this.buttonAddToDataBase.Name = "buttonAddToDataBase";
            this.buttonAddToDataBase.Size = new System.Drawing.Size(155, 43);
            this.buttonAddToDataBase.TabIndex = 14;
            this.buttonAddToDataBase.Text = "Добавить в базу данных";
            this.buttonAddToDataBase.UseVisualStyleBackColor = true;
            this.buttonAddToDataBase.Visible = false;
            this.buttonAddToDataBase.Click += new System.EventHandler(this.buttonAddToDataBase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(627, 240);
            this.Controls.Add(this.buttonCreateDataBase);
            this.Controls.Add(this.buttonAddToDataBase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCheckSum);
            this.Controls.Add(this.textBoxFileContent);
            this.Controls.Add(this.buttonOpenHexFile);
            this.Controls.Add(this.buttonOpenBinFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Firmware database program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenBinFile;
        private System.Windows.Forms.Button buttonOpenHexFile;
        private System.Windows.Forms.TextBox textBoxFileContent;
        private System.Windows.Forms.TextBox textBoxCheckSum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCreateDataBase;
        private System.Windows.Forms.Button buttonAddToDataBase;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

