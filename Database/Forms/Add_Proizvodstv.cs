﻿using Database.Script;
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
    public partial class Add_Proizvodstv : Form
    {
        public Add_Proizvodstv()
        {
            InitializeComponent();
            string[] predpriatia = getPredpriatia().Select(n => n.ToString()).ToArray();
            TPredpriatia.Items.AddRange(predpriatia);
            string[] vidproducta = getVidProducta().Select(n => n.ToString()).ToArray();
            TVidProducta.Items.AddRange(vidproducta);
        }

        Databaseconnect db = new Databaseconnect();
        private void button1_Click(object sender, EventArgs e)
        {
            if (TPredpriatia.Text.Length != 0 && TVidProducta.Text.Length != 0 && TKol.Text.Length != 0) {
                int idpredpriatia = getPredpriatia(TPredpriatia.SelectedItem.ToString());
                int idvidproducta = getVidProducta(TVidProducta.SelectedItem.ToString());

                string quest = "INSERT INTO Производство (Предприятия, ВидПродукции, Количество) VALUES('" + idpredpriatia + "','" + idvidproducta + "','" + TKol.Text + "')";
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

        //ID Продукта по названию
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
        //ID предприятия по названию
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
        //Достаем из таблицы по столбцам
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
        //Достаем из таблицы по столбцам
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
        private void TKol_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '\b');
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
