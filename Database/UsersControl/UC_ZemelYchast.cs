using Database.Script;
using Database.Forms;

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
    public partial class UC_ZemelYchast : UserControl
    {
        public UC_ZemelYchast()
        {
            InitializeComponent(); 
            string[] array2 = getPredpriatia().Select(n => n.ToString()).ToArray();
            TPredpriatia.Items.AddRange(array2);
        }
        private List<string> getPredpriatia()
        {
            List<string> opers = new List<string>();
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Предприятия";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                opers.Add(item[1].ToString());
            }
            return opers;
        }
        public List<string> EditItems = new List<string>();
        public Databaseconnect db = new Databaseconnect();
        private void UC_ZemelYchast_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(db.selectZemelYchast, db.connect);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (db.add != 0)
            {
                using (Add_ZemelYchast add_ZemelYchast = new Add_ZemelYchast())
                {
                    add_ZemelYchast.ShowDialog();
                    this.OnLoad(e);
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
                        string quest = $"DELETE  FROM ЗемельныеУчастки WHERE КодЗемельныеУчастки = {iddel}";
                        db.connect.Open();
                        OleDbCommand dataCommander = new OleDbCommand(quest, db.connect);
                        dataCommander.ExecuteNonQuery();

                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(db.selectZemelYchast, db.connect);
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
                    using (Edit_ZemelYchast edit_ZemelYchast = new Edit_ZemelYchast())
                    {
                        if (EditItems.Count > 0)
                        {
                            edit_ZemelYchast.ID = Convert.ToInt32(EditItems[0]);
                            edit_ZemelYchast.tpredpriatia = EditItems[1];
                            edit_ZemelYchast.tmestoPol = EditItems[2];
                            edit_ZemelYchast.tploshad = EditItems[3];
                            edit_ZemelYchast.tpravo = EditItems[4];
                            edit_ZemelYchast.ShowDialog();
                            this.OnLoad(e);
                        }
                        else
                        {
                            edit_ZemelYchast.ShowDialog();
                            this.OnLoad(e);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PFilter.Visible = true;
        }

        private void TFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == (Char)Keys.Back) return;
            if (char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TPredpriatia.Text = " ";
            TMestoPol.Text = "";
            TPloshad.Text = "";
            TPravo.Text = " ";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(db.selectZemelYchast, db.connect);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DGVDate.DataSource = ds.Tables[0].DefaultView;
        }
        string predpriatia = "";
        string mestopol = "";
        string ploshad = "";
        string pravo = "";
        private void TPredpriatia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TPredpriatia.Text != " ")
            {
                predpriatia = $"Предприятия.Наименование = '{TPredpriatia.Text}'";
            }
            else
            {
                predpriatia = "";
            }
        }

        private void TMestoPol_TextChanged(object sender, EventArgs e)
        {
            if (TMestoPol.Text.Length != 0)
            {
                mestopol = $"ЗемельныеУчастки.Местонахождение = '{TMestoPol.Text}'";
            }
            else
            {
                mestopol = "";
            }
        }

        private void TPloshad_TextChanged(object sender, EventArgs e)
        {
            if (TPloshad.Text.Length != 0)
            {
                ploshad = $"ЗемельныеУчастки.Площадь = '{TPloshad.Text}'";
            }
            else
            {
                ploshad = "";
            }
        }

        private void TPravo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TPravo.Text != " ")
            {
                pravo = $"ЗемельныеУчастки.Право = '{TPravo.Text}'";
            }
            else
            {
                pravo = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<string> tex = new List<string>();
            List<string> te = new List<string>();
            string quest = " WHERE ";

            tex.Clear();
            te.Clear();

            if (mestopol.Length != 0) tex.Add(mestopol);
            if (predpriatia.Length != 0) tex.Add(predpriatia);
            if (ploshad.Length != 0) tex.Add(ploshad);
            if (pravo.Length != 0) tex.Add(pravo);
            if (tex.Count() != 0)
            {
                if (tex.Count == 1)
                {
                    te.Add(tex[0]);
                }
                if (tex.Count == 2)
                {
                    te.Add(tex[0]);
                    te.Add(" and ");
                    te.Add(tex[1]);
                }
                else if (tex.Count == 3)
                {
                    te.Add(tex[0]);
                    te.Add(" and ");
                    te.Add(tex[1]);
                    te.Add(" and ");
                    te.Add(tex[2]);
                }
                else if (tex.Count == 4)
                {
                    te.Add(tex[0]);
                    te.Add(" and ");
                    te.Add(tex[1]);
                    te.Add(" and ");
                    te.Add(tex[2]);
                    te.Add(" and ");
                    te.Add(tex[3]);
                }
                for (int i = 0; i < te.Count; i++)
                {
                    quest += te[i];
                }
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(db.selectZemelYchast + quest, db.connect);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                DGVDate.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PFilter.Visible = false;
        }

        private void TPloshad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '\b');
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
