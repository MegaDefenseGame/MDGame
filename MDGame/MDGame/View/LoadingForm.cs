using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDGame.View
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }
        private int eiei = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            eiei++;
            switch (eiei)
            {
                case 1:
                    pictureBox1.Image = MDGame.Properties.Resources.Load2;
                    break;
                case 2:
                    pictureBox1.Image = MDGame.Properties.Resources.Load3;
                    break;
                case 3:
                    pictureBox1.Image = MDGame.Properties.Resources.Load4;
                    break;
                case 4:
                    Form1 gameView = new Form1();
                    gameView.Show();
                    this.Hide();
                    timer1.Stop();
                    break;
                //case 5:
                //    Form1 gameView = new Form1();
                //    gameView.Show();
                //    this.Hide();
                //    timer1.Stop();
                //    break;

            }  
        }
    }
}
