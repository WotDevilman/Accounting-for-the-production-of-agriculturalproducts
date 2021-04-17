using Database.Forms;
using Database.Script;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.UsersControl
{
    public partial class UC_Predpriatia : UserControl
    {
        public UC_Predpriatia()
        {
            InitializeComponent();
        }
        public List<string> EditItems = new List<string>();

        private void button4_Click(object sender, EventArgs e)
        {
            if (db.add != 0)
            {
                using (Add_Predpriatia add_Predpriatia = new Add_Predpriatia())
                {
                    add_Predpriatia.ShowDialog();
                    this.OnLoad(e);
                }
            }
        }
        public Databaseconnect db = new Databaseconnect();
        private void UC_Predpriatia_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(db.selectPredpriatia, db.connect);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DGVDate.DataSource = ds.Tables[0].DefaultView;

            CountZap.Text = "Количество записей: " + DGVDate.RowCount;

            DGVDate.Columns[0].Visible = false;

            if (DGVDate.RowCount > 0)
            {
                EditItems.Clear();
                for (int i = 0; i < DGVDate.ColumnCount; i++)
                {
                    EditItems.Add(DGVDate.Rows[0].Cells[i].Value.ToString());
                }
            }
        }

        private void TSearh_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < DGVDate.RowCount; i++)
            {
                DGVDate.Rows[i].Selected = false;
                for (int j = 0; j < DGVDate.ColumnCount; j++)
                    if (DGVDate.Rows[i].Cells[j].Value != null)
                        if (DGVDate.Rows[i].Cells[j].Value.ToString().ToLower().Contains(TSearh.Text.ToLower()))
                        {
                            DGVDate.Rows[i].Selected = true;
                            break;
                        }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (db.add != 0)
            {
                if (DGVDate.RowCount != 0)
                {
                    int iddel = Convert.ToInt32(DGVDate[0, DGVDate.CurrentCell.RowIndex].Value);
                    Form_Delete form_Delete = new Form_Delete();
                    form_Delete.ShowDialog();
                    this.OnLoad(e);

                    int i = form_Delete.ii;
                    if (i == 1)
                    {
                        string quest = $"DELETE  FROM Предприятия WHERE КодПредприятия = {iddel}";
                        db.connect.Open();
                        OleDbCommand dataCommander = new OleDbCommand(quest, db.connect);
                        dataCommander.ExecuteNonQuery();

                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(db.selectPredpriatia, db.connect);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        DGVDate.DataSource = ds.Tables[0].DefaultView;

                        DGVDate.Columns[0].Visible = false;
                    }
                    form_Delete.ii = 0;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (db.add != 0) {
                if (DGVDate.RowCount != 0)
                {
                    using (Edit_Predpriatia edit_Predpriatia = new Edit_Predpriatia())
                    {
                        if (EditItems.Count > 0)
                        {
                            edit_Predpriatia.ID = Convert.ToInt32(EditItems[0]);
                            edit_Predpriatia.tname = EditItems[1];
                            edit_Predpriatia.tdate = EditItems[2];
                            edit_Predpriatia.tsobst = EditItems[3];
                            edit_Predpriatia.tadress = EditItems[4];
                            edit_Predpriatia.tusers = EditItems[5];
                            edit_Predpriatia.tphone = EditItems[6];
                            edit_Predpriatia.ShowDialog();
                            this.OnLoad(e);
                        }
                        else
                        {
                            edit_Predpriatia.ShowDialog();
                            this.OnLoad(e);
                        }
                    }
                }
            }
        }
        private void DGVDate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int mSelectedRowIndex = DGVDate.SelectedCells[0].RowIndex;
            DataGridViewRow mSelectedRow = DGVDate.Rows[mSelectedRowIndex];
            
            EditItems.Clear();

            for (int i = 0; i < DGVDate.ColumnCount; i++)
            {
            EditItems.Add(Convert.ToString(mSelectedRow.Cells[i].Value));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TFilter.Text.Length != 0)
            {
                string filter = TFilter.Text;
                string quest = "SELECT Предприятия.КодПредприятия, Предприятия.Наименование, Предприятия.ДатаРегистрации, Предприятия.ВидСобственности, Предприятия.Адрес, Предприятия.КонтактноеЛицо, Предприятия.Телефон FROM Предприятия WHERE Предприятия.ВидСобственности = '" + filter + "'";

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(quest, db.connect);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                DGVDate.DataSource = ds.Tables[0].DefaultView;
            }
            else
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(db.selectPredpriatia, db.connect);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                DGVDate.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void TFilter_TextChanged(object sender, EventArgs e)
        {
            if (TFilter.Text.Length == 0)
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(db.selectPredpriatia, db.connect);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                DGVDate.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void TFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == (Char)Keys.Back) return;
            if (char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
