using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Proje
{
    public partial class Main : Form
    {
        private string id;
        OMDb ombd = new OMDb();
        FolderBrowserDialog browser = new FolderBrowserDialog();
        DatabaseOperations Db = new DatabaseOperations();
        NotFound nf;
        public int s;
        DataGridViewCellEventArgs k;

        public Main()
        {
            InitializeComponent();
            this.id = id;
            textBox_path.Text = StringLiterals.selecting_path;
            button_scan.Text = StringLiterals.scan;
            button_deleteall.Text = StringLiterals.delete_all;
            label_status.Hide();
            button_couldntfound.Text = StringLiterals.notfounds;
            Db.List("Movies");
            datagridview_filmler.DataSource = DatabaseOperations.table;
            DatabaseOperations.table.AcceptChanges();
            comboBox_column.Items.Add(StringLiterals.title);
            comboBox_column.Items.Add(StringLiterals.year);
            comboBox_column.Items.Add(StringLiterals.runtime);
            comboBox_column.Items.Add(StringLiterals.genre);
            comboBox_column.Items.Add(StringLiterals.actors);
            comboBox_column.Items.Add(StringLiterals.director);
            comboBox_column.Items.Add(StringLiterals.writer);
            comboBox_column.Items.Add(StringLiterals.plot);
            comboBox_column.Items.Add(StringLiterals.country);
            comboBox_column.SelectedIndex = 0;
            button_search.Text = StringLiterals.search;
        }
        private void button_scan_Click(object sender, EventArgs e)
        {
            
            backgroundWorker1.RunWorkerAsync();
        }
        private void textBox_path_DoubleClick(object sender, EventArgs e)
        {
            textBox_path.Clear();
            browser.ShowDialog();
            textBox_path.Text = browser.SelectedPath;
        }
        private void button_deleteall_Click(object sender, EventArgs e)
        {
            if (button_deleteall.Text == StringLiterals.delete_all)
            {
                Db.DeleteAll("Movies");
                Db.List("Movies");
                datagridview_filmler.DataSource = DatabaseOperations.table;
                DatabaseOperations.table.AcceptChanges();
            }
            else
            {
                    Db.Delete("Movies", datagridview_filmler.Rows[k.RowIndex].Cells[15].Value.ToString());
                    Db.List("Movies");
                    datagridview_filmler.DataSource = DatabaseOperations.table;
                    DatabaseOperations.table.AcceptChanges();
                    button_deleteall.Text = StringLiterals.delete_all;
                
            }
        }
        private void button_couldntfound_Click(object sender, EventArgs e)
        {
            nf = new NotFound();
            nf.Show();
        }
        private void button_search_Click(object sender, EventArgs e)
        {
            if (comboBox_column.Text == StringLiterals.title)
                Db.Search("Movies", textBox_search.Text, "TITLE");
            else if (comboBox_column.Text == StringLiterals.year)
                Db.Search("Movies", textBox_search.Text, "YEAR");
            else if (comboBox_column.Text == StringLiterals.genre)
                Db.Search("Movies", textBox_search.Text, "GENRE");
            else if (comboBox_column.Text == StringLiterals.actors)
                Db.Search("Movies", textBox_search.Text, "ACTORS");
            else if (comboBox_column.Text == StringLiterals.director)
                Db.Search("Movies", textBox_search.Text, "DIRECTOR");
            else if (comboBox_column.Text == StringLiterals.writer)
                Db.Search("Movies", textBox_search.Text, "WRITER");
            else if (comboBox_column.Text == StringLiterals.plot)
                Db.Search("Movies", textBox_search.Text, "PLOT");
            else if (comboBox_column.Text == StringLiterals.country)
                Db.Search("Movies", textBox_search.Text, "COUNTRY");
            else if (comboBox_column.Text == StringLiterals.runtime)
                Db.Search("Movies", textBox_search.Text, "RUNTIME");
            datagridview_filmler.DataSource = DatabaseOperations.table;
            DatabaseOperations.table.AcceptChanges();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void datagridview_filmler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (s == 0)
            {
                if (e.RowIndex >= 0)
                {
                    k = e;
                    button_deleteall.Text = StringLiterals.delete;

                }
            }
        }
        private void textBox_path_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == StringLiterals.selecting_path)
            {
                textBox_path.Clear();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Girilen stringin içinde :\ olup olmadığı kontrol ediliyor. Varsa dosya yolu yoksa film adı olarak işlem yapılıyor.
            if (browser.SelectedPath.IndexOf(":\\") != -1)
            {
                if (Directory.Exists(textBox_path.Text))
                {
                    if (OMDb.isConnectionOK())
                    {
                        ombd.Scan(browser.SelectedPath);
                        label_status.Hide();
                        Db.List("Movies");
                        datagridview_filmler.DataSource = DatabaseOperations.table;
                        DatabaseOperations.table.AcceptChanges();
                    }
                    else
                    {
                        label_status.Show();
                        label_status.ForeColor = Color.Red;
                        label_status.Text = StringLiterals.connection_issue;
                    }

                }
                else
                {
                    label_status.Show();
                    label_status.ForeColor = Color.Red;
                    label_status.Text = StringLiterals.path_incorrect;
                }
            }
            else if (textBox_path.Text.Length != 0)
            {
                if (ombd.ScanviaID(textBox_path.Text))
                {
                    textBox_path.Clear();
                    label_status.Hide();
                    Db.List("Movies");
                    datagridview_filmler.DataSource = DatabaseOperations.table;
                    DatabaseOperations.table.AcceptChanges();
                }
                else
                {
                    label_status.Show();
                    label_status.ForeColor = Color.Red;
                    label_status.Text = StringLiterals.notfound;
                }
            }
            else
            {
                label_status.Show();
                label_status.ForeColor = Color.Red;
                label_status.Text = StringLiterals.error_blank;
            }
        }
    }
}
