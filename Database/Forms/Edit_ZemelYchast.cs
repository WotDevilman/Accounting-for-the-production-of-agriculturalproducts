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

namespace Database.Forms
{
    public partial class Edit_ZemelYchast : Form
    {
        public Edit_ZemelYchast()
        {
            InitializeComponent();
            string[] array2 = getPredpriatia().Select(n => n.ToString()).ToArray();
            TPredpriatia.Items.AddRange(array2);
        }
        public int ID { get; set; }
        public string tpredpriatia { get; set; }
        public string tmestoPol { get; set; }
        public string tploshad { get; set; }
        public string tpravo { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Databaseconnect db = new Databaseconnect();
        private void button1_Click(object sender, EventArgs e)
        {
            if (TPredpriatia.Text.Length != 0 && TPravo.Text.Length != 0 && TMestoPol.Text.Length != 0 && TPloshad.Text.Length != 0)
            {
                int idpredpriatia = getPredpriatia(TPredpriatia.SelectedItem.ToString());

                string quest = $"UPDATE ЗемельныеУчастки SET Предприятия = '{idpredpriatia}', Местонахождение = '{TMestoPol.Text}', Площадь = '{TPloshad.Text}', Право = '{TPravo.Text}' where КодЗемельныеУчастки = {ID}";
                db.connect.Open();
                OleDbCommand dataAdapter = new OleDbCommand(quest, db.connect);
                dataAdapter.ExecuteNonQuery();
            }
            else
            {
                Form_Messange form_Messange = new Form_Messange();
                form_Messange.ShowDialog();
            }
        }
        private int getPredpriatia(string nameZakazchik)
        {
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT КодПредприятия FROM Предприятия where Наименование = '" + nameZakazchik + "'";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            return int.Parse(dt.Rows[0][0].ToString());
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

        private void Edit_ZemelYchast_Load(object sender, EventArgs e)
        {
            TPredpriatia.Text = tpredpriatia;
            TMestoPol.Text = tmestoPol;
            TPloshad.Text = tploshad;
            TPravo.Text = tpravo;
        }

        private void TPloshad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '\b');
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
