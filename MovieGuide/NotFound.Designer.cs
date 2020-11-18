namespace MovieGuide
{
    partial class NotFound
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
            this.dataGridView_notfound = new System.Windows.Forms.DataGridView();
            this.button_deleteall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_notfound)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_notfound
            // 
            this.dataGridView_notfound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_notfound.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_notfound.Name = "dataGridView_notfound";
            this.dataGridView_notfound.ReadOnly = true;
            this.dataGridView_notfound.Size = new System.Drawing.Size(430, 384);
            this.dataGridView_notfound.TabIndex = 0;
            this.dataGridView_notfound.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_notfound_CellClick);
            // 
            // button_deleteall
            // 
            this.button_deleteall.Location = new System.Drawing.Point(335, 402);
            this.button_deleteall.Name = "button_deleteall";
            this.button_deleteall.Size = new System.Drawing.Size(107, 23);
            this.button_deleteall.TabIndex = 1;
            this.button_deleteall.Text = "button1";
            this.button_deleteall.UseVisualStyleBackColor = true;
            this.button_deleteall.Click += new System.EventHandler(this.button_deleteall_Click);
            // 
            // NotFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 429);
            this.Controls.Add(this.button_deleteall);
            this.Controls.Add(this.dataGridView_notfound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NotFound";
            this.Text = "NotFound";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_notfound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_notfound;
        private System.Windows.Forms.Button button_deleteall;
    }
}