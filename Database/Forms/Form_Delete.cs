using Database.UsersControl;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.Forms
{
    public partial class Form_Delete : Form
    {
        public Form_Delete()
        {
            InitializeComponent();
        }

       public int ii;
        private void button1_Click(object sender, EventArgs e)
        {
            ii = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ii = 0;
            this.Close();
        }
    }
}
