namespace MovieGuide
{
    partial class Main
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
            this.datagridview_filmler = new System.Windows.Forms.DataGridView();
            this.button_scan = new System.Windows.Forms.Button();
            this.button_deleteall = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_couldntfound = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.comboBox_column = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_filmler)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridview_filmler
            // 
            this.datagridview_filmler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_filmler.Location = new System.Drawing.Point(12, 35);
            this.datagridview_filmler.Name = "datagridview_filmler";
            this.datagridview_filmler.ReadOnly = true;
            this.datagridview_filmler.Size = new System.Drawing.Size(861, 509);
            this.datagridview_filmler.TabIndex = 1;
            this.datagridview_filmler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_filmler_CellClick);
            // 
            // button_scan
            // 
            this.button_scan.Location = new System.Drawing.Point(717, 550);
            this.button_scan.Name = "button_scan";
            this.button_scan.Size = new System.Drawing.Size(75, 23);
            this.button_scan.TabIndex = 2;
            this.button_scan.Text = "button1";
            this.button_scan.UseVisualStyleBackColor = true;
            this.button_scan.Click += new System.EventHandler(this.button_scan_Click);
            // 
            // button_deleteall
            // 
            this.button_deleteall.Location = new System.Drawing.Point(798, 550);
            this.button_deleteall.Name = "button_deleteall";
            this.button_deleteall.Size = new System.Drawing.Size(75, 23);
            this.button_deleteall.TabIndex = 3;
            this.button_deleteall.Text = "button2";
            this.button_deleteall.UseVisualStyleBackColor = true;
            this.button_deleteall.Click += new System.EventHandler(this.button_deleteall_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(12, 552);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(699, 20);
            this.textBox_path.TabIndex = 4;
            this.textBox_path.Click += new System.EventHandler(this.textBox_path_Click);
            this.textBox_path.DoubleClick += new System.EventHandler(this.textBox_path_DoubleClick);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(9, 575);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(35, 13);
            this.label_status.TabIndex = 5;
            this.label_status.Text = "label1";
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(610, 12);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(182, 20);
            this.textBox_search.TabIndex = 7;
            // 
            // button_couldntfound
            // 
            this.button_couldntfound.Location = new System.Drawing.Point(12, 10);
            this.button_couldntfound.Name = "button_couldntfound";
            this.button_couldntfound.Size = new System.Drawing.Size(113, 23);
            this.button_couldntfound.TabIndex = 8;
            this.button_couldntfound.Text = "button2";
            this.button_couldntfound.UseVisualStyleBackColor = true;

            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(798, 10);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 9;
            this.button_search.Text = "button1";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // comboBox_column
            // 
            this.comboBox_column.FormattingEnabled = true;
            this.comboBox_column.Location = new System.Drawing.Point(483, 11);
            this.comboBox_column.Name = "comboBox_column";
            this.comboBox_column.Size = new System.Drawing.Size(121, 21);
            this.comboBox_column.TabIndex = 10;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 597);
            this.Controls.Add(this.comboBox_column);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_couldntfound);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_deleteall);
            this.Controls.Add(this.button_scan);
            this.Controls.Add(this.datagridview_filmler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Main";
            this.Text = "MovieGuide";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_filmler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridview_filmler;
        private System.Windows.Forms.Button button_scan;
        private System.Windows.Forms.Button button_deleteall;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_couldntfound;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.ComboBox comboBox_column;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

