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
    public partial class UC_Home : UserControl
    {
        
        public UC_Home()
        {
            InitializeComponent();
            
        }

        List<string> nameChart = new List<string>();
        List<string> kolChart = new List<string>();
        private void UC_Home_Load(object sender, EventArgs e)
        {
            getchartItem();
            chart1.Series[0]["PieLabelStyle"] = "Disabled";
            for (int i = 0; i < nameChart.Count; i++)
            {
                chart1.Series[0].Points.AddXY(nameChart[i], kolChart[i]);
            }

            getpredTop();
            setToppred();
        }


        Databaseconnect db = new Databaseconnect();
        private void getchartItem()
        {
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Sum(Производство.Количество) AS Выражение1, ВидыПродукции.ВидПродукции FROM ВидыПродукции INNER JOIN Производство ON ВидыПродукции.КодВидыПродукции = Производство.ВидПродукции GROUP BY ВидыПродукции.ВидПродукции; ";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                kolChart.Add(item[0].ToString());
                nameChart.Add(item[1].ToString());
            }
        }

        List<string> namepred = new List<string>();
        List<int> colpred = new List<int>();
        private void getpredTop()
        {
            db.connect.Open();
            OleDbCommand cmd = db.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Предприятия.Наименование, Sum(Производство.Количество) AS [Sum-Колво] FROM Предприятия INNER JOIN Производство ON Предприятия.КодПредприятия = Производство.Предприятия GROUP BY Предприятия.Наименование;";
            cmd.ExecuteNonQuery();
            db.connect.Close();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                namepred.Add(item[0].ToString());
                colpred.Add(Convert.ToInt32(item[1]));
            }
        }

        async void setToppred()
        {
            await Task.Run(() => {

                int max = colpred[0];
                int idcol = 0; ;

                for (int i = 0; i < colpred.Count; i++)
                {
                        if (colpred[i] >= max)
                        {
                            max = colpred[i];
                            idcol = i;
                        }
                }
                label1.Text = $"Лучшее СХ по производству : {namepred[idcol]} || Всего : {colpred[idcol]}";
            });
            
        }
    }
}
