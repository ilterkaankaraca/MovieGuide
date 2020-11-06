using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class NotFound : Form
    {
        Database Db = new Database();
        public int s;
        DataGridViewCellEventArgs k;
        public NotFound()
        {
            InitializeComponent();
            Db.List("NotFound");
            dataGridView_notfound.DataSource = Database.table;
            Database.table.AcceptChanges();
            dataGridView_notfound.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            button_deleteall.Text = StringLiterals.delete_all;
        }

        private void button_deleteall_Click(object sender, EventArgs e)
        {
            if (button_deleteall.Text == StringLiterals.delete_all)
            {
                Db.DeleteAll("NotFound");
                Db.List("NotFound");
                dataGridView_notfound.DataSource = Database.table;
                Database.table.AcceptChanges();
            }
            else
            {
                Db.Delete("NotFound", dataGridView_notfound.Rows[k.RowIndex].Cells[0].Value.ToString());
                Db.List("NotFound");
                dataGridView_notfound.DataSource = Database.table;
                Database.table.AcceptChanges();
                button_deleteall.Text = StringLiterals.delete_all;
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
