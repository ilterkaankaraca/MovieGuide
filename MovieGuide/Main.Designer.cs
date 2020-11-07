namespace Proje
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
            this.scanButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.pathTextBoxPath = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
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
            this.datagridview_filmler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagridViewMoviesCellClick);
            this.datagridview_filmler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_filmler_CellContentClick);
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(717, 550);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(75, 23);
            this.scanButton.TabIndex = 2;
            this.scanButton.Text = "button1";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.ScanButtonClick);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Location = new System.Drawing.Point(798, 550);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAllButton.TabIndex = 3;
            this.deleteAllButton.Text = "button2";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            this.deleteAllButton.Click += new System.EventHandler(this.DeleteAllButtonClick);
            // 
            // pathTextBoxPath
            // 
            this.pathTextBoxPath.Location = new System.Drawing.Point(12, 552);
            this.pathTextBoxPath.Name = "pathTextBoxPath";
            this.pathTextBoxPath.Size = new System.Drawing.Size(699, 20);
            this.pathTextBoxPath.TabIndex = 4;
            this.pathTextBoxPath.Click += new System.EventHandler(this.textBox_path_Click);
            this.pathTextBoxPath.DoubleClick += new System.EventHandler(this.PathTextBoxDoubleClick);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(9, 575);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "label1";
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
            this.button_couldntfound.Click += new System.EventHandler(this.NotFoundButtonClick);
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
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.pathTextBoxPath);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.datagridview_filmler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Main";
            this.Text = "MovieGuide";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_filmler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridview_filmler;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox pathTextBoxPath;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_couldntfound;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.ComboBox comboBox_column;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

