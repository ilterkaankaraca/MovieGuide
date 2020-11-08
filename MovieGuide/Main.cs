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
        DatabaseOperations database = new DatabaseOperations();
        NotFound notFound;
        public int s;
        DataGridViewCellEventArgs k;

        public Main()
        {
            InitializeComponent();
            pathTextBox.Text = StringLiterals.selecting_path;
            scanButton.Text = StringLiterals.scan;
            deleteAllButton.Text = StringLiterals.delete_all;
            statusLabel.Hide();
            notFoundButton.Text = StringLiterals.notfounds;
            database.List("MOVIES");
            moviesDataGridView.DataSource = DatabaseOperations.table;
            DatabaseOperations.table.AcceptChanges();
            searchByComboBox.Items.Add(StringLiterals.title);
            searchByComboBox.Items.Add(StringLiterals.year);
            searchByComboBox.Items.Add(StringLiterals.runtime);
            searchByComboBox.Items.Add(StringLiterals.genre);
            searchByComboBox.Items.Add(StringLiterals.actors);
            searchByComboBox.Items.Add(StringLiterals.director);
            searchByComboBox.Items.Add(StringLiterals.writer);
            searchByComboBox.Items.Add(StringLiterals.plot);
            searchByComboBox.Items.Add(StringLiterals.country);
            searchByComboBox.SelectedIndex = 0;
            searchButton.Text = StringLiterals.search;
        }
        private void ScanButtonClick(object sender, EventArgs e)
        {
            
            backgroundWorker1.RunWorkerAsync();
        }
        private void PathTextBoxDoubleClick(object sender, EventArgs e)
        {
            pathTextBox.Clear();
            browser.ShowDialog();
            pathTextBox.Text = browser.SelectedPath;
        }
        private void DeleteAllButtonClick(object sender, EventArgs e)
        {
            if (deleteAllButton.Text == StringLiterals.delete_all)
            {
                database.DeleteAll("Movies");
                database.List("Movies");
                moviesDataGridView.DataSource = DatabaseOperations.table;
                DatabaseOperations.table.AcceptChanges();
            }
            else
            {
                    database.Delete("Movies", moviesDataGridView.Rows[k.RowIndex].Cells[15].Value.ToString());
                    database.List("Movies");
                    moviesDataGridView.DataSource = DatabaseOperations.table;
                    DatabaseOperations.table.AcceptChanges();
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
            if (searchByComboBox.Text == StringLiterals.title)
                database.Search("Movies", searchTextBox.Text, "TITLE");
            else if (searchByComboBox.Text == StringLiterals.year)
                database.Search("Movies", searchTextBox.Text, "YEAR");
            else if (searchByComboBox.Text == StringLiterals.genre)
                database.Search("Movies", searchTextBox.Text, "GENRE");
            else if (searchByComboBox.Text == StringLiterals.actors)
                database.Search("Movies", searchTextBox.Text, "ACTORS");
            else if (searchByComboBox.Text == StringLiterals.director)
                database.Search("Movies", searchTextBox.Text, "DIRECTOR");
            else if (searchByComboBox.Text == StringLiterals.writer)
                database.Search("Movies", searchTextBox.Text, "WRITER");
            else if (searchByComboBox.Text == StringLiterals.plot)
                database.Search("Movies", searchTextBox.Text, "PLOT");
            else if (searchByComboBox.Text == StringLiterals.country)
                database.Search("Movies", searchTextBox.Text, "COUNTRY");
            else if (searchByComboBox.Text == StringLiterals.runtime)
                database.Search("Movies", searchTextBox.Text, "RUNTIME");
            moviesDataGridView.DataSource = DatabaseOperations.table;
            DatabaseOperations.table.AcceptChanges();
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
            if (pathTextBox.Text == StringLiterals.selecting_path)
            {
                pathTextBox.Clear();
            }
        }

        private void BackGroudWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            //Girilen stringin içinde :\ olup olmadığı kontrol ediliyor. Varsa dosya yolu yoksa film adı olarak işlem yapılıyor.
            if (browser.SelectedPath.IndexOf(":\\") != -1)
            {
                if (Directory.Exists(pathTextBox.Text))
                {
                    if (OMDb.isConnectionOK())
                    {
                        ombd.Scan(browser.SelectedPath);
                        statusLabel.Hide();
                        database.List("Movies");
                        moviesDataGridView.DataSource = DatabaseOperations.table;
                        DatabaseOperations.table.AcceptChanges();
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
            else if (pathTextBox.Text.Length != 0)
            {
                if (ombd.ScanviaID(pathTextBox.Text))
                {
                    pathTextBox.Clear();
                    statusLabel.Hide();
                    database.List("Movies");
                    moviesDataGridView.DataSource = DatabaseOperations.table;
                    DatabaseOperations.table.AcceptChanges();
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
