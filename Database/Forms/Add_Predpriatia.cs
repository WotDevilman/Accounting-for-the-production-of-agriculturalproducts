using Database.Script;

using System;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.Forms
{
    public partial class Add_Predpriatia : Form
    {
        public Add_Predpriatia()
        {
            InitializeComponent();

        }
        Databaseconnect db = new Databaseconnect();
        private void button1_Click(object sender, EventArgs e)
        {
            if (TPhone.Text.Length != 0 && TName.Text.Length != 0 && TAdress.Text.Length != 0 && TUsers.Text.Length != 0 && TSobst.Text.Length != 0)
            {
                string quest = "INSERT INTO Предприятия (Наименование, ДатаРегистрации, ВидСобственности, Адрес, КонтактноеЛицо, Телефон) VALUES('" + TName.Text + "','" + TDate.Value.ToShortDateString() + "','" + TSobst.Text + "','" + TAdress.Text + "','" + TUsers.Text + "'," + TPhone.Text + ")";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
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
            if ((char)e.KeyChar == (Char)Keys.Back) return;
            if ((char)e.KeyChar == (Char)Keys.Space) return;
            if (char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
