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
            this.moviesDataGridView = new System.Windows.Forms.DataGridView();
            this.scanButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.notFoundButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchByComboBox = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.moviesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // moviesDataGridView
            // 
            this.moviesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moviesDataGridView.Location = new System.Drawing.Point(12, 35);
            this.moviesDataGridView.Name = "moviesDataGridView";
            this.moviesDataGridView.ReadOnly = true;
            this.moviesDataGridView.Size = new System.Drawing.Size(861, 509);
            this.moviesDataGridView.TabIndex = 1;
            this.moviesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagridViewMoviesCellClick);
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
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 552);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(699, 20);
            this.pathTextBox.TabIndex = 4;
            this.pathTextBox.Click += new System.EventHandler(this.PathTextBoxClick);
            this.pathTextBox.DoubleClick += new System.EventHandler(this.PathTextBoxDoubleClick);
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
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(610, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(182, 20);
            this.searchTextBox.TabIndex = 7;
            // 
            // notFoundButton
            // 
            this.notFoundButton.Location = new System.Drawing.Point(12, 10);
            this.notFoundButton.Name = "notFoundButton";
            this.notFoundButton.Size = new System.Drawing.Size(113, 23);
            this.notFoundButton.TabIndex = 8;
            this.notFoundButton.Text = "button2";
            this.notFoundButton.UseVisualStyleBackColor = true;
            this.notFoundButton.Click += new System.EventHandler(this.NotFoundButtonClick);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(798, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "button1";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button_search_Click);
            // 
            // searchByComboBox
            // 
            this.searchByComboBox.FormattingEnabled = true;
            this.searchByComboBox.Location = new System.Drawing.Point(483, 11);
            this.searchByComboBox.Name = "searchByComboBox";
            this.searchByComboBox.Size = new System.Drawing.Size(121, 21);
            this.searchByComboBox.TabIndex = 10;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackGroudWorker1DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 597);
            this.Controls.Add(this.searchByComboBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.notFoundButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.moviesDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Main";
            this.Text = "MovieGuide";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.moviesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView moviesDataGridView;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button notFoundButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox searchByComboBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

