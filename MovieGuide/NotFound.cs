using System;
using System.Windows.Forms;

namespace MovieGuide
{
    public partial class NotFound : Form
    {
        DatabaseOperations Db = new DatabaseOperations();
        public int s;
        DataGridViewCellEventArgs k;
        public NotFound()
        {
            InitializeComponent();
            Db.SelectFrom("NotFound");
            dataGridView_notfound.DataSource = DatabaseOperations.table;
            DatabaseOperations.table.AcceptChanges();
            dataGridView_notfound.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            button_deleteall.Text = StringLiterals.deleteAll;
        }

        private void button_deleteall_Click(object sender, EventArgs e)
        {
            if (button_deleteall.Text == StringLiterals.deleteAll)
            {
                Db.DeleteAllFrom("NotFound");
                Db.SelectFrom("NotFound");
                dataGridView_notfound.DataSource = DatabaseOperations.table;
                DatabaseOperations.table.AcceptChanges();
            }
            else
            {
                Db.DeleteFrom("NotFound", dataGridView_notfound.Rows[k.RowIndex].Cells[0].Value.ToString());
                Db.SelectFrom("NotFound");
                dataGridView_notfound.DataSource = DatabaseOperations.table;
                DatabaseOperations.table.AcceptChanges();
                button_deleteall.Text = StringLiterals.deleteAll;
            }
        }

        private void dataGridView_notfound_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
