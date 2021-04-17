using Database.UsersControl;
using Database.Script;
using Database.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class Main : Form
    {
        public Databaseconnect db = new Databaseconnect();
        public Main()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Time()
        {
            DateTime dt = DateTime.Now;
            LTime.Text = dt.ToString("hh:mm:ss");
            TDate.Text = dt.ToString("dd:MM:yy");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time();
        }

        private void addControll(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }
        


        private void btnPredpriatia_Click(object sender, EventArgs e)
        {
            if (db.read != 0)
            {

                btnGlavnai.BackColor = Color.FromArgb(25, 30, 54);
                btnOsnovnoePocazatel.BackColor = Color.FromArgb(25, 30, 54);
                btnProizvodstv.BackColor = Color.FromArgb(25, 30, 54);
                btnZemelYchast.BackColor = Color.FromArgb(25, 30, 54);
                //Отображение контроля
                UC_Predpriatia uC_Predpriatia = new UC_Predpriatia();

                uC_Predpriatia.db = db;

                addControll(uC_Predpriatia);
                btnPredpriatia.BackColor = Color.FromArgb(37, 42, 63);
            }
        }

        private void ZemelYchast_Click(object sender, EventArgs e)
        {
            if (db.read != 0)
            {
                btnGlavnai.BackColor = Color.FromArgb(25, 30, 54);
                btnOsnovnoePocazatel.BackColor = Color.FromArgb(25, 30, 54);
                btnProizvodstv.BackColor = Color.FromArgb(25, 30, 54);
                btnPredpriatia.BackColor = Color.FromArgb(25, 30, 54);
                //Отображение контроля
                UC_ZemelYchast uC_ZemelYchast = new UC_ZemelYchast();

                uC_ZemelYchast.db = db;

                addControll(uC_ZemelYchast);
                btnZemelYchast.BackColor = Color.FromArgb(37, 42, 63);
            }
        }

        private void btnProizvodstv_Click(object sender, EventArgs e)
        {
            if (db.read != 0)
            {
                btnGlavnai.BackColor = Color.FromArgb(25, 30, 54);
                btnOsnovnoePocazatel.BackColor = Color.FromArgb(25, 30, 54);
                btnZemelYchast.BackColor = Color.FromArgb(25, 30, 54);
                btnPredpriatia.BackColor = Color.FromArgb(25, 30, 54);
                //Отображение контроля
                UC_Proizvodstv uC_Proizvodstv = new UC_Proizvodstv();

                uC_Proizvodstv.db = db;

                addControll(uC_Proizvodstv);
                btnProizvodstv.BackColor = Color.FromArgb(37, 42, 63);
            }
        }

        private void btnOsnovnoePocazatel_Click(object sender, EventArgs e)
        {
            if (db.read != 0)
            {
                btnGlavnai.BackColor = Color.FromArgb(25, 30, 54);
                btnProizvodstv.BackColor = Color.FromArgb(25, 30, 54);
                btnZemelYchast.BackColor = Color.FromArgb(25, 30, 54);
                btnPredpriatia.BackColor = Color.FromArgb(25, 30, 54);
                //Отображение контроля
                UC_OsnovnoePocazatel uC_OsnovnoePocazatel = new UC_OsnovnoePocazatel();

                uC_OsnovnoePocazatel.db = db;

                addControll(uC_OsnovnoePocazatel);
                btnOsnovnoePocazatel.BackColor = Color.FromArgb(37, 42, 63);
            }
        }

        private void btnGlavnai_Click(object sender, EventArgs e)
        {
            btnOsnovnoePocazatel.BackColor = Color.FromArgb(25, 30, 54);
            btnProizvodstv.BackColor = Color.FromArgb(25, 30, 54);
            btnZemelYchast.BackColor = Color.FromArgb(25, 30, 54);
            btnPredpriatia.BackColor = Color.FromArgb(25, 30, 54);
            UC_Home uC_Home = new UC_Home();
            addControll(uC_Home);
            btnGlavnai.BackColor = Color.FromArgb(37, 42, 63);
        }

        private void btnInform_Click(object sender, EventArgs e)
        {
            using(Form_Infotmation form_Infotmation = new Form_Infotmation())
            {
                form_Infotmation.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UC_Home uC_Home = new UC_Home();
            addControll(uC_Home);
            btnGlavnai.BackColor = Color.FromArgb(37, 42, 63);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (db.print != 0)
            {
                using (Form_Print form_Print = new Form_Print())
                {
                    form_Print.ShowDialog();
                    this.OnLoad(e);
                }
            }
        }
    }
}
