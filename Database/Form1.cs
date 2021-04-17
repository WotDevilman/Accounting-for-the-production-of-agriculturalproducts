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

namespace Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Users users = new Users();
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] array = users.getUsers().Select(n => n.ToString()).ToArray();
            TName.Items.AddRange(array);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string pass = "";
            if (TPassword.Text == "")
            {
                pass = "Null";
                users.setpass(TName.Text, pass);
            }
            else
            {
                pass = TPassword.Text;
                users.setpass(TName.Text, pass);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create.Visible = !Create.Visible;
        }
        Databaseconnect db = new Databaseconnect();
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {
                string quest = "INSERT INTO Users (Name, Password) VALUES ('" + textBox2.Text +"', '"+ textBox1.Text +"');";
                quest = $@"INSERT INTO Users([Name], [Password]) VALUES('{textBox2.Text}', '{textBox1.Text}');";
                db.connect.Open();
                OleDbCommand dataAdapter = new OleDbCommand(quest, db.connect);
                dataAdapter.ExecuteNonQuery();
                db.connect.Close();

                int edit;
                int print;
                int riding;
                if(Edit.Checked != false)
                {
                    edit = 1;
                }
                else
                {
                    edit = 0;
                }
                if(Riding.Checked != false)
                {
                    riding = 1;
                }
                else
                {
                    riding = 0;
                }
                if(Print.Checked != false)
                {
                    print = 1;
                }
                else
                {
                    print = 0;
                }

                int IDPOL = getID(textBox2.Text);

                quest = $@"INSERT INTO Addition(IdUsers, [Add], [Reading], [Printing]) VALUES({IDPOL}, {edit}, {riding}, {print});";
                db.connect.Open();
                dataAdapter = new OleDbCommand(quest, db.connect);
                dataAdapter.ExecuteNonQuery();
                db.connect.Close();

                TName.Items.Add(textBox2.Text);
            }
        }
        
        private int getID(string user)
        {
            int id = 0;
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM Users WHERE [Name] = '{user}'";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                id = Convert.ToInt32(item[0].ToString());
            }
            return id;
        }
    }
}
