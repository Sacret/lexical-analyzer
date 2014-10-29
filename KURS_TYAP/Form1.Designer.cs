namespace KURS_TYAP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Bleks = new System.Windows.Forms.Button();
            this.DGVleks = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RTBtext = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LBpr = new System.Windows.Forms.ListBox();
            this.Bpr = new System.Windows.Forms.Button();
            this.DGVpr = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVleks)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpr)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 415);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Bleks);
            this.tabPage1.Controls.Add(this.DGVleks);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.RTBtext);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Лексический разбор";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Bleks
            // 
            this.Bleks.Location = new System.Drawing.Point(24, 346);
            this.Bleks.Name = "Bleks";
            this.Bleks.Size = new System.Drawing.Size(517, 23);
            this.Bleks.TabIndex = 5;
            this.Bleks.Text = "РАЗБОР";
            this.Bleks.UseVisualStyleBackColor = true;
            this.Bleks.Click += new System.EventHandler(this.Bleks_Click);
            // 
            // DGVleks
            // 
            this.DGVleks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVleks.Location = new System.Drawing.Point(241, 96);
            this.DGVleks.Name = "DGVleks";
            this.DGVleks.Size = new System.Drawing.Size(300, 232);
            this.DGVleks.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Лексический анализ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Фрагмент программы";
            // 
            // RTBtext
            // 
            this.RTBtext.Location = new System.Drawing.Point(24, 96);
            this.RTBtext.Name = "RTBtext";
            this.RTBtext.Size = new System.Drawing.Size(181, 232);
            this.RTBtext.TabIndex = 1;
            this.RTBtext.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(192, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "~Курсовая работа~";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LBpr);
            this.tabPage2.Controls.Add(this.Bpr);
            this.tabPage2.Controls.Add(this.DGVpr);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(570, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Правый анализатор";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LBpr
            // 
            this.LBpr.FormattingEnabled = true;
            this.LBpr.HorizontalScrollbar = true;
            this.LBpr.Location = new System.Drawing.Point(24, 96);
            this.LBpr.Name = "LBpr";
            this.LBpr.Size = new System.Drawing.Size(181, 225);
            this.LBpr.TabIndex = 11;
            // 
            // Bpr
            // 
            this.Bpr.Location = new System.Drawing.Point(24, 346);
            this.Bpr.Name = "Bpr";
            this.Bpr.Size = new System.Drawing.Size(517, 23);
            this.Bpr.TabIndex = 10;
            this.Bpr.Text = "РАЗБОР";
            this.Bpr.UseVisualStyleBackColor = true;
            this.Bpr.Click += new System.EventHandler(this.Bpr_Click);
            // 
            // DGVpr
            // 
            this.DGVpr.AllowUserToAddRows = false;
            this.DGVpr.AllowUserToDeleteRows = false;
            this.DGVpr.AllowUserToResizeColumns = false;
            this.DGVpr.AllowUserToResizeRows = false;
            this.DGVpr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVpr.Location = new System.Drawing.Point(241, 96);
            this.DGVpr.Name = "DGVpr";
            this.DGVpr.ReadOnly = true;
            this.DGVpr.RowHeadersWidth = 45;
            this.DGVpr.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVpr.Size = new System.Drawing.Size(300, 232);
            this.DGVpr.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Матрица операторного предшествования";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Разбор цепочки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(192, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "~Курсовая работа~";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 415);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "~Курсовая работа~";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVleks)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RTBtext;
        private System.Windows.Forms.DataGridView DGVleks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Bleks;
        private System.Windows.Forms.Button Bpr;
        private System.Windows.Forms.DataGridView DGVpr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox LBpr;
    }
}

