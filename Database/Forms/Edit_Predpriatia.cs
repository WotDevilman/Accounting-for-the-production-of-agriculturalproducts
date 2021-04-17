using Database.Script;
using Database.UsersControl;

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
    public partial class Edit_Predpriatia : Form
    {
        public Edit_Predpriatia()
        {
            InitializeComponent();
        }
        public int ID { get; set; }
        public string tname { get; set; }
        public string tdate { get; set; }
        public string tsobst { get; set; }
        public string tadress { get; set; }
        public string tusers { get; set; }
        public string tphone { get; set; }
        private void Edit_Predpriatia_Load(object sender, EventArgs e)
        {
            TName.Text = tname;
            TDate.Value = Convert.ToDateTime(tdate);
            TSobst.Text = tsobst;
            TAdress.Text = tadress;
            TUsers.Text = tusers;
            TPhone.Text = tphone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Databaseconnect db = new Databaseconnect();
        private void button1_Click(object sender, EventArgs e)
        {
            if (TPhone.Text.Length != 0 && TName.Text.Length != 0 && TAdress.Text.Length != 0 && TUsers.Text.Length != 0 && TSobst.Text.Length != 0)
            {
                string quest = $"UPDATE Предприятия SET Наименование = '{TName.Text}', ДатаРегистрации = '{TDate.Value.ToShortDateString()}', ВидСобственности = '{TSobst.Text}', Адрес = '{TAdress.Text}', КонтактноеЛицо = '{TUsers.Text}', Телефон = '{TPhone.Text}' where КодПредприятия = {ID}";
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

        private void TPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '\b');
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void TName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == (Char)Keys.Back || (char)e.KeyChar == '"') return;
            if (char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void TSobst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == (Char)Keys.Back || (char)e.KeyChar == '"') return;
            if (char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void TUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == (Char)Keys.Back || (char)e.KeyChar == '"') return;
            if (char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
