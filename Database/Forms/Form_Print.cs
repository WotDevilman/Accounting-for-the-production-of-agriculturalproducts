using Database.Script;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Word = Microsoft.Office.Interop.Word;

namespace Database.Forms
{
    public partial class Form_Print : Form
    {
        public Form_Print()
        {
            InitializeComponent();
            string[] array2 = getPredpriatia().Select(n => n.ToString()).ToArray();
            TPredpriatia.Items.AddRange(array2);
        }

        private readonly string TemplateFileName = Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Result.docx");
        private void button1_Click(object sender, EventArgs e)
        {
            infapred.Clear();
            ZemelYch.Clear();
            Proiz.Clear();
            OsnPred.Clear();

            getPredpriati(TPredpriatia.Text);

            int idpred = getPredpriatia(TPredpriatia.Text);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Document (*.docx) | *.docx";

            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var newpathdoc = sfd.FileName;

                    //TODO
                    var wordAPP = new Word.Application();
                    wordAPP.Visible = false;

                    var worddocument = wordAPP.Documents.Open(TemplateFileName);

                    ReplateWordDocument("{Predpriatia}", infapred[0], worddocument);
                    ReplateWordDocument("{DataTime}", infapred[1], worddocument);
                    ReplateWordDocument("{VidSobs}", infapred[2], worddocument);
                    ReplateWordDocument("{Adres}", infapred[3], worddocument);
                    ReplateWordDocument("{Users}", infapred[4], worddocument);
                    ReplateWordDocument("{Phone}", infapred[5], worddocument);

                    //Таблица 1
                    var n = 0;
                    getOsnPred(idpred.ToString());
                    Word.Table tab = worddocument.Tables[1];
                    for (int i = 2; i <= (OsnPred.Count / 3) + 1; i++)
                    {
                        tab.Rows.Add(Missing.Value);
                        tab.Cell(i, 1).Range.Text = OsnPred[n];
                        n++;
                        tab.Cell(i, 2).Range.Text = OsnPred[n];
                        n++;
                        tab.Cell(i, 3).Range.Text = OsnPred[n];
                        n++;
                    }

                    //Таблица 2
                    n = 0;
                    getZemelYch(idpred.ToString());
                    tab = worddocument.Tables[2];
                    for (int i = 2; i <= (ZemelYch.Count / 3) + 1; i++)
                    {
                        tab.Rows.Add(Missing.Value);
                        tab.Cell(i, 1).Range.Text = ZemelYch[n];
                        n++;
                        tab.Cell(i, 2).Range.Text = ZemelYch[n];
                        n++;
                        tab.Cell(i, 3).Range.Text = ZemelYch[n];
                        n++;
                    }

                    //Таблица 3
                    n = 0;
                    getProiz(idpred.ToString());
                    tab = worddocument.Tables[3];
                    for (int i = 2; i <= (Proiz.Count / 2) + 1; i++)
                    {
                        tab.Rows.Add(Missing.Value);
                        tab.Cell(i, 1).Range.Text = Proiz[n];
                        n++;
                        tab.Cell(i, 2).Range.Text = Proiz[n];
                        n++;
                    }

                    worddocument.SaveAs(newpathdoc);
                    wordAPP.Visible = true;

                    MessageBox.Show("Документ сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
        }
                catch
                {
                    MessageBox.Show("Произошла ошибка.", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
}

        private void ReplateWordDocument(string stupToReplate, string text, Word.Document worddoc)
        {
            var range = worddoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText:stupToReplate, ReplaceWith:text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Databaseconnect db = new Databaseconnect();
        List<string> infapred = new List<string>();
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
        private void getPredpriati(string nameZakazchik)
        {
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM Предприятия WHERE Наименование = '{nameZakazchik}'";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                infapred.Add(item[1].ToString());
                infapred.Add(item[2].ToString());
                infapred.Add(item[3].ToString());
                infapred.Add(item[4].ToString());
                infapred.Add(item[5].ToString());
                infapred.Add(item[6].ToString());
            }
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

        List<string> OsnPred = new List<string>();
        private void getOsnPred(string id)
        {
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT ВидыПродукции.ВидПродукции, ОсновныеПоказатели.ЧислоРаботников, ОсновныеПоказатели.Прибыль FROM ВидыПродукции INNER JOIN ОсновныеПоказатели ON ВидыПродукции.КодВидыПродукции = ОсновныеПоказатели.ОсновнойВидПродукции WHERE ОсновныеПоказатели.Предприятия = {id}";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                OsnPred.Add(item[0].ToString());
                OsnPred.Add(item[1].ToString());
                OsnPred.Add(item[2].ToString());
            }
        }
        List<string> ZemelYch = new List<string>();
        private void getZemelYch(string id)
        {
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT ЗемельныеУчастки.Местонахождение, ЗемельныеУчастки.Площадь, ЗемельныеУчастки.Право FROM ЗемельныеУчастки WHERE ЗемельныеУчастки.Предприятия = {id}";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                ZemelYch.Add(item[0].ToString());
                ZemelYch.Add(item[1].ToString());
                ZemelYch.Add(item[2].ToString());
            }
        }
        List<string> Proiz = new List<string>();
        private void getProiz(string id)
        {
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT ВидыПродукции.ВидПродукции, Производство.Количество, Производство.Предприятия FROM ВидыПродукции INNER JOIN Производство ON ВидыПродукции.КодВидыПродукции = Производство.ВидПродукции WHERE Производство.Предприятия = {id}";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Proiz.Add(item[0].ToString());
                Proiz.Add(item[1].ToString());
            }
        }
    }
}
