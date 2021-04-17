
namespace Database
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnInform = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LTime = new System.Windows.Forms.Label();
            this.btnOsnovnoePocazatel = new System.Windows.Forms.Button();
            this.btnGlavnai = new System.Windows.Forms.Button();
            this.btnProizvodstv = new System.Windows.Forms.Button();
            this.btnZemelYchast = new System.Windows.Forms.Button();
            this.btnPredpriatia = new System.Windows.Forms.Button();
            this.panelProgram = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTide = new System.Windows.Forms.Panel();
            this.LUsers = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelProgram.SuspendLayout();
            this.panelTide.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelMenu.Controls.Add(this.btnInform);
            this.panelMenu.Controls.Add(this.button3);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.btnOsnovnoePocazatel);
            this.panelMenu.Controls.Add(this.btnGlavnai);
            this.panelMenu.Controls.Add(this.btnProizvodstv);
            this.panelMenu.Controls.Add(this.btnZemelYchast);
            this.panelMenu.Controls.Add(this.btnPredpriatia);
            this.panelMenu.Controls.Add(this.panelProgram);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 720);
            this.panelMenu.TabIndex = 0;
            // 
            // btnInform
            // 
            this.btnInform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnInform.FlatAppearance.BorderSize = 0;
            this.btnInform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInform.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(124)))), ((int)(((byte)(229)))));
            this.btnInform.Location = new System.Drawing.Point(-1, 562);
            this.btnInform.Name = "btnInform";
            this.btnInform.Size = new System.Drawing.Size(200, 46);
            this.btnInform.TabIndex = 11;
            this.btnInform.Text = "Помочь";
            this.btnInform.UseVisualStyleBackColor = false;
            this.btnInform.Click += new System.EventHandler(this.btnInform_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(124)))), ((int)(((byte)(229)))));
            this.button3.Location = new System.Drawing.Point(0, 510);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 46);
            this.button3.TabIndex = 10;
            this.button3.Text = "Печать";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TDate);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 639);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 81);
            this.panel1.TabIndex = 6;
            // 
            // TDate
            // 
            this.TDate.AutoSize = true;
            this.TDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TDate.ForeColor = System.Drawing.Color.White;
            this.TDate.Location = new System.Drawing.Point(61, 48);
            this.TDate.Name = "TDate";
            this.TDate.Size = new System.Drawing.Size(97, 20);
            this.TDate.TabIndex = 4;
            this.TDate.Text = "DD:MM:YY";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Database.Properties.Resources.icons8_clock_26px;
            this.pictureBox2.Location = new System.Drawing.Point(29, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Database.Properties.Resources.icons8_event_26px;
            this.pictureBox1.Location = new System.Drawing.Point(28, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LTime
            // 
            this.LTime.AutoSize = true;
            this.LTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LTime.ForeColor = System.Drawing.Color.White;
            this.LTime.Location = new System.Drawing.Point(61, 16);
            this.LTime.Name = "LTime";
            this.LTime.Size = new System.Drawing.Size(97, 20);
            this.LTime.TabIndex = 0;
            this.LTime.Text = "HH:MM:SS";
            // 
            // btnOsnovnoePocazatel
            // 
            this.btnOsnovnoePocazatel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnOsnovnoePocazatel.FlatAppearance.BorderSize = 0;
            this.btnOsnovnoePocazatel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOsnovnoePocazatel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOsnovnoePocazatel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(124)))), ((int)(((byte)(229)))));
            this.btnOsnovnoePocazatel.Location = new System.Drawing.Point(0, 302);
            this.btnOsnovnoePocazatel.Name = "btnOsnovnoePocazatel";
            this.btnOsnovnoePocazatel.Size = new System.Drawing.Size(200, 46);
            this.btnOsnovnoePocazatel.TabIndex = 5;
            this.btnOsnovnoePocazatel.Text = "Основные Показатели";
            this.btnOsnovnoePocazatel.UseVisualStyleBackColor = false;
            this.btnOsnovnoePocazatel.Click += new System.EventHandler(this.btnOsnovnoePocazatel_Click);
            // 
            // btnGlavnai
            // 
            this.btnGlavnai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnGlavnai.FlatAppearance.BorderSize = 0;
            this.btnGlavnai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGlavnai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGlavnai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(124)))), ((int)(((byte)(229)))));
            this.btnGlavnai.Location = new System.Drawing.Point(0, 100);
            this.btnGlavnai.Name = "btnGlavnai";
            this.btnGlavnai.Size = new System.Drawing.Size(200, 46);
            this.btnGlavnai.TabIndex = 4;
            this.btnGlavnai.Text = "Главная";
            this.btnGlavnai.UseVisualStyleBackColor = false;
            this.btnGlavnai.Click += new System.EventHandler(this.btnGlavnai_Click);
            // 
            // btnProizvodstv
            // 
            this.btnProizvodstv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnProizvodstv.FlatAppearance.BorderSize = 0;
            this.btnProizvodstv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProizvodstv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProizvodstv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(124)))), ((int)(((byte)(229)))));
            this.btnProizvodstv.Location = new System.Drawing.Point(0, 250);
            this.btnProizvodstv.Name = "btnProizvodstv";
            this.btnProizvodstv.Size = new System.Drawing.Size(200, 46);
            this.btnProizvodstv.TabIndex = 3;
            this.btnProizvodstv.Text = "Производсвто";
            this.btnProizvodstv.UseVisualStyleBackColor = false;
            this.btnProizvodstv.Click += new System.EventHandler(this.btnProizvodstv_Click);
            // 
            // btnZemelYchast
            // 
            this.btnZemelYchast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnZemelYchast.FlatAppearance.BorderSize = 0;
            this.btnZemelYchast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZemelYchast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZemelYchast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(124)))), ((int)(((byte)(229)))));
            this.btnZemelYchast.Location = new System.Drawing.Point(0, 198);
            this.btnZemelYchast.Name = "btnZemelYchast";
            this.btnZemelYchast.Size = new System.Drawing.Size(200, 46);
            this.btnZemelYchast.TabIndex = 2;
            this.btnZemelYchast.Text = "Земельные Участки";
            this.btnZemelYchast.UseVisualStyleBackColor = false;
            this.btnZemelYchast.Click += new System.EventHandler(this.ZemelYchast_Click);
            // 
            // btnPredpriatia
            // 
            this.btnPredpriatia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnPredpriatia.FlatAppearance.BorderSize = 0;
            this.btnPredpriatia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPredpriatia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPredpriatia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(124)))), ((int)(((byte)(229)))));
            this.btnPredpriatia.Location = new System.Drawing.Point(0, 148);
            this.btnPredpriatia.Name = "btnPredpriatia";
            this.btnPredpriatia.Size = new System.Drawing.Size(200, 46);
            this.btnPredpriatia.TabIndex = 1;
            this.btnPredpriatia.Text = "Предприятия";
            this.btnPredpriatia.UseVisualStyleBackColor = false;
            this.btnPredpriatia.Click += new System.EventHandler(this.btnPredpriatia_Click);
            // 
            // panelProgram
            // 
            this.panelProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProgram.Controls.Add(this.label1);
            this.panelProgram.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProgram.Location = new System.Drawing.Point(0, 0);
            this.panelProgram.Name = "panelProgram";
            this.panelProgram.Size = new System.Drawing.Size(200, 100);
            this.panelProgram.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 98);
            this.label1.TabIndex = 0;
            this.label1.Text = "СХ\r\nАнализ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTide
            // 
            this.panelTide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(73)))));
            this.panelTide.Controls.Add(this.LUsers);
            this.panelTide.Controls.Add(this.panel4);
            this.panelTide.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTide.Location = new System.Drawing.Point(200, 0);
            this.panelTide.Name = "panelTide";
            this.panelTide.Size = new System.Drawing.Size(1080, 100);
            this.panelTide.TabIndex = 1;
            // 
            // LUsers
            // 
            this.LUsers.AutoSize = true;
            this.LUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LUsers.ForeColor = System.Drawing.Color.White;
            this.LUsers.Location = new System.Drawing.Point(25, 59);
            this.LUsers.Name = "LUsers";
            this.LUsers.Size = new System.Drawing.Size(61, 20);
            this.LUsers.TabIndex = 1;
            this.LUsers.Text = "Users:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(63)))));
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1080, 41);
            this.panel4.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1020, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 41);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(63)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 100);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1080, 620);
            this.panelContent.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTide);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelProgram.ResumeLayout(false);
            this.panelTide.ResumeLayout(false);
            this.panelTide.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTide;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label LTime;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnProizvodstv;
        private System.Windows.Forms.Button btnZemelYchast;
        private System.Windows.Forms.Button btnPredpriatia;
        public System.Windows.Forms.Label LUsers;
        private System.Windows.Forms.Button btnGlavnai;
        private System.Windows.Forms.Button btnOsnovnoePocazatel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnInform;
        private System.Windows.Forms.Button button3;
    }
}