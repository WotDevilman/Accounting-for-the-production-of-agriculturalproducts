using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Database.Script
{
    class Users
    {
        Databaseconnect con = new Databaseconnect();
        public List<string> getUsers()
        {
            List<string> opers = new List<string>();
            con.connect.Open();
            OleDbCommand cmd = con.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Users";
            cmd.ExecuteNonQuery();
            con.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                opers.Add(item[1].ToString());
            }
            return opers;
        }
        public void setpass(string name, string password)
        {
            con.connect.Open();
            OleDbCommand cmd = con.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Name = '" + name + "' AND Password = '" + password + "'";
            int a = int.Parse(cmd.ExecuteScalar().ToString());
            con.connect.Close();

            if (a == 0)
            {
                MessageBox.Show("Данный пароль не верный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                getAddition(name);

                con.Users = name;
                Form1 f1 = new Form1();
                Main main = new Main();

                main.db = con;

                main.Text = f1.Text;
                main.Owner = f1;
                main.Show();
                main.LUsers.Text = "Users: " + name;
            } 
        }
        public void getAddition(string nam)
        {
            List<string> opers = new List<string>();
            con.connect.Open();
            OleDbCommand cmd = con.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT [Addition].Add, [Addition].Reading, [Addition].Printing FROM Users INNER JOIN [Addition] ON Users.IdUsers = [Addition].IdUsers Where Users.Name = '{nam}'";
            cmd.ExecuteNonQuery();
            con.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                con.add = Convert.ToInt32(item[0]);
                con.read = Convert.ToInt32(item[1]);
                con.print = Convert.ToInt32(item[2]);
            }
        }
    }
}
