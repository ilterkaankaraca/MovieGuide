using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proje
{
    public partial class Main : Form
    {
        private string id;
        OMDb ombd = new OMDb();
        FolderBrowserDialog browser = new FolderBrowserDialog();
        Database database = new Database();
        NotFound notFound;
        public int s;
        DataGridViewCellEventArgs k;

        public Main()
        {
            InitializeComponent();
            pathTextBoxPath.Text = StringLiterals.selecting_path;
            scanButton.Text = StringLiterals.scan;
            deleteAllButton.Text = StringLiterals.delete_all;
            statusLabel.Hide();
            button_couldntfound.Text = StringLiterals.notfounds;
            database.List("Movies");
            datagridview_filmler.DataSource = Database.table;
            Database.table.AcceptChanges();
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
        private void ScanButtonClick(object sender, EventArgs e)
        {
            
            backgroundWorker1.RunWorkerAsync();
        }
        private void PathTextBoxDoubleClick(object sender, EventArgs e)
        {
            pathTextBoxPath.Clear();
            browser.ShowDialog();
            pathTextBoxPath.Text = browser.SelectedPath;
        }
        private void DeleteAllButtonClick(object sender, EventArgs e)
        {
            if (deleteAllButton.Text == StringLiterals.delete_all)
            {
                database.DeleteAll("Movies");
                database.List("Movies");
                datagridview_filmler.DataSource = Database.table;
                Database.table.AcceptChanges();
            }
            else
            {
                    database.Delete("Movies", datagridview_filmler.Rows[k.RowIndex].Cells[15].Value.ToString());
                    database.List("Movies");
                    datagridview_filmler.DataSource = Database.table;
                    Database.table.AcceptChanges();
                    deleteAllButton.Text = StringLiterals.delete_all;
                
            }
        }
        private void NotFoundButtonClick(object sender, EventArgs e)
        {
            notFound = new NotFound();
            notFound.Show();
        }
        private void button_search_Click(object sender, EventArgs e)
        {
            if (comboBox_column.Text == StringLiterals.title)
                database.Search("Movies", textBox_search.Text, "TITLE");
            else if (comboBox_column.Text == StringLiterals.year)
                database.Search("Movies", textBox_search.Text, "YEAR");
            else if (comboBox_column.Text == StringLiterals.genre)
                database.Search("Movies", textBox_search.Text, "GENRE");
            else if (comboBox_column.Text == StringLiterals.actors)
                database.Search("Movies", textBox_search.Text, "ACTORS");
            else if (comboBox_column.Text == StringLiterals.director)
                database.Search("Movies", textBox_search.Text, "DIRECTOR");
            else if (comboBox_column.Text == StringLiterals.writer)
                database.Search("Movies", textBox_search.Text, "WRITER");
            else if (comboBox_column.Text == StringLiterals.plot)
                database.Search("Movies", textBox_search.Text, "PLOT");
            else if (comboBox_column.Text == StringLiterals.country)
                database.Search("Movies", textBox_search.Text, "COUNTRY");
            else if (comboBox_column.Text == StringLiterals.runtime)
                database.Search("Movies", textBox_search.Text, "RUNTIME");
            datagridview_filmler.DataSource = Database.table;
            Database.table.AcceptChanges();
        }
        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void DatagridViewMoviesCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (s == 0)
            {
                if (e.RowIndex >= 0)
                {
                    k = e;
                    deleteAllButton.Text = StringLiterals.delete;

                }
            }
        }
        private void PathTextBoxClick(object sender, EventArgs e)
        {
            if (pathTextBoxPath.Text == StringLiterals.selecting_path)
            {
                pathTextBoxPath.Clear();
            }
        }

        private void BackGroudWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            //Girilen stringin içinde :\ olup olmadığı kontrol ediliyor. Varsa dosya yolu yoksa film adı olarak işlem yapılıyor.
            if (browser.SelectedPath.IndexOf(":\\") != -1)
            {
                if (Directory.Exists(pathTextBoxPath.Text))
                {
                    if (OMDb.isConnectionOK())
                    {
                        ombd.Scan(browser.SelectedPath);
                        statusLabel.Hide();
                        database.List("Movies");
                        datagridview_filmler.DataSource = Database.table;
                        Database.table.AcceptChanges();
                    }
                    else
                    {
                        statusLabel.Show();
                        statusLabel.ForeColor = Color.Red;
                        statusLabel.Text = StringLiterals.connection_issue;
                    }

                }
                else
                {
                    statusLabel.Show();
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = StringLiterals.path_incorrect;
                }
            }
            else if (pathTextBoxPath.Text.Length != 0)
            {
                if (ombd.ScanviaID(pathTextBoxPath.Text))
                {
                    pathTextBoxPath.Clear();
                    statusLabel.Hide();
                    database.List("Movies");
                    datagridview_filmler.DataSource = Database.table;
                    Database.table.AcceptChanges();
                }
                else
                {
                    statusLabel.Show();
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = StringLiterals.notfound;
                }
            }
            else
            {
                statusLabel.Show();
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = StringLiterals.error_blank;
            }
        }
    }
}
