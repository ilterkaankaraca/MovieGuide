using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovieGuide
{
    public partial class Main : Form
    {
        FolderBrowserDialog browser = new FolderBrowserDialog();
        DatabaseOperations database = new DatabaseOperations();
        NotFound notFound;
        private readonly int s;
        DataGridViewCellEventArgs selectedRow;

        public Main()
        {
            InitializeComponent();
            pathTextBox.Text = StringLiterals.selectPath;
            scanButton.Text = StringLiterals.scan;
            deleteAllButton.Text = StringLiterals.deleteAll;
            statusLabel.Hide();
            notFoundButton.Text = StringLiterals.notFound;
            database.SelectFrom("MOVIES");
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
        private void PathTextBoxDoubleClick(object sender, EventArgs e)
        {
            pathTextBox.Clear();
            browser.ShowDialog();
            pathTextBox.Text = browser.SelectedPath;
            pathTextBox.SelectionStart = pathTextBox.Text.Length;
            pathTextBox.SelectionLength = 0;
        }
        private void DeleteAllButtonClick(object sender, EventArgs e)
        {
            if (deleteAllButton.Text == StringLiterals.deleteAll)
            {
                database.DeleteAllFrom("MOVIES");
                database.SelectFrom("MOVIES");
                moviesDataGridView.DataSource = DatabaseOperations.table;
                DatabaseOperations.table.AcceptChanges();
            }
            else
            {
                database.DeleteFrom("MOVIES", moviesDataGridView.Rows[selectedRow.RowIndex].Cells[15].Value.ToString());
                database.SelectFrom("MOVIES");
                moviesDataGridView.DataSource = DatabaseOperations.table;
                DatabaseOperations.table.AcceptChanges();
                deleteAllButton.Text = StringLiterals.deleteAll;

            }
        }
        private void NotFoundButtonClick(object sender, EventArgs e)
        {
            notFound = new NotFound();
            notFound.Show();
        }
        private void SearchButtonClick(object sender, EventArgs e)
        {
            // bunu daha dinamik hale getirmek lazim
            if (searchByComboBox.Text == StringLiterals.title)
                database.Search("MOVIES", searchTextBox.Text, "TITLE");
            else if (searchByComboBox.Text == StringLiterals.year)
                database.Search("MOVIES", searchTextBox.Text, "YEAR");
            else if (searchByComboBox.Text == StringLiterals.genre)
                database.Search("MOVIES", searchTextBox.Text, "GENRE");
            else if (searchByComboBox.Text == StringLiterals.actors)
                database.Search("MOVIES", searchTextBox.Text, "ACTORS");
            else if (searchByComboBox.Text == StringLiterals.director)
                database.Search("MOVIES", searchTextBox.Text, "DIRECTOR");
            else if (searchByComboBox.Text == StringLiterals.writer)
                database.Search("MOVIES", searchTextBox.Text, "WRITER");
            else if (searchByComboBox.Text == StringLiterals.plot)
                database.Search("MOVIES", searchTextBox.Text, "PLOT");
            else if (searchByComboBox.Text == StringLiterals.country)
                database.Search("MOVIES", searchTextBox.Text, "COUNTRY");
            else if (searchByComboBox.Text == StringLiterals.runtime)
                database.Search("MOVIES", searchTextBox.Text, "RUNTIME");
            moviesDataGridView.DataSource = DatabaseOperations.table;
            DatabaseOperations.table.AcceptChanges();
        }
        private void DatagridViewMoviesCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (s == 0 && e.RowIndex >= 0)
            {
                selectedRow = e;
                deleteAllButton.Text = StringLiterals.delete;
            }
        }
        private void PathTextBoxClick(object sender, EventArgs e)
        {
            if (pathTextBox.Text == StringLiterals.selectPath)
            {
                pathTextBox.Clear();
            }
        }
        private void ScanButtonClick(object sender, EventArgs e)
        {

            if (pathTextBox.Text.Length != 0)
            {
                if (OMDb.Start(pathTextBox.Text) == 1)
                {
                    pathTextBox.Clear();
                    statusLabel.Hide();
                    database.SelectFrom("MOVIES");
                    moviesDataGridView.DataSource = DatabaseOperations.table;
                    DatabaseOperations.table.AcceptChanges();
                }
                else
                {
                    statusLabel.Show();
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = StringLiterals.notFound;
                }
            }
            else
            {
                statusLabel.Show();
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = StringLiterals.errorBlank;
            }
        }
        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
