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
    public partial class Edit_OsnovnoePocazatel : Form
    {
        public Edit_OsnovnoePocazatel()
        {
            InitializeComponent();
            string[] predpriatia = getPredpriatia().Select(n => n.ToString()).ToArray();
            TPredpriatia.Items.AddRange(predpriatia);
            string[] vidproducta = getVidProducta().Select(n => n.ToString()).ToArray();
            TVidProduct.Items.AddRange(vidproducta);
        }
        public int ID { get; set; }
        public string tpredpriatia { get; set; }
        public string tvidproducta { get; set; }
        public string trabot { get; set; }
        public string tpribil { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Databaseconnect db = new Databaseconnect();
        private void button1_Click(object sender, EventArgs e)
        {
            if (TPredpriatia.Text.Length != 0 && TVidProduct.Text.Length != 0 && TRabot.Text.Length != 0 && TPribil.Text.Length != 0)
            {
                int idpredpriatia = getPredpriatia(TPredpriatia.SelectedItem.ToString());
                int idvidproducta = getVidProducta(TVidProduct.SelectedItem.ToString());

                string quest = $"UPDATE ОсновныеПоказатели SET Предприятия = '{idpredpriatia}', ОсновнойВидПродукции = '{idvidproducta}', ЧислоРаботников = '{TRabot.Text}', Прибыль = '{TPribil.Text}' where КодОсновныеПоказатели = {ID}";
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
        private int getVidProducta(string nameZakazchik)
        {
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT КодВидыПродукции FROM ВидыПродукции where ВидПродукции = '" + nameZakazchik + "'";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            return int.Parse(dt.Rows[0][0].ToString());
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
        private List<string> getVidProducta()
        {
            List<string> opers = new List<string>();
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ВидыПродукции";
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

        private void Edit_OsnovnoePocazatel_Load(object sender, EventArgs e)
        {
            TPredpriatia.Text = tpredpriatia;
            TVidProduct.Text = tvidproducta;
            TRabot.Text = trabot;
            TPribil.Text = tpribil;
        }

        private void TRabot_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '\b');
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void TPribil_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '\b' || c == '.');
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
