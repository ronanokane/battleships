using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BattleShipsClient
{
    public partial class frmGameCountdown : Form
    {
        int counter=10;

        public frmGameCountdown()
        {
            InitializeComponent();
        }

        private void frmGameCountdown_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;

            timer1.Tick += delegate
            {
                
                Graphics g = this.CreateGraphics();
                g.Clear(Color.FromKnownColor(KnownColor.Control));
                g.DrawString("" + counter, new Font("Arial", 138), Brushes.Black, 2, 2);

                counter--;

                if(counter==0)this.Hide();
            };

            timer1.Start();
        }

        private void btn_QuitGame_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btn_skipCountdown_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}