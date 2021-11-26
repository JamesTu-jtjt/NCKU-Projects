using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW9_1_MusicPlayer
{
    public partial class Form2 : Form
    {
        Button[,] btnArray = new Button[4, 10];

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            trackBar.Value = 10;
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    this.btnArray[i, j] = new Button();
                    this.btnArray[i, j].SetBounds(150 + i * 130, 50 + j * 40, 80, 20);
                    this.btnArray[i, j].TextAlign = ContentAlignment.TopLeft;
                    this.btnArray[i, j].Text = i.ToString() + ", " + j.ToString();
                    Controls.Add(this.btnArray[i, j]);
                }
            }
            SetSpectrum(trackBar.Value);
            timer1.Interval = 500;
            timer1.Enabled = true;
        }

        private void SetSpectrum(int v)
        {
            int tmp = 0;
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                tmp = r.Next(0, v + 1);
                for (int j = 9; j >= 0; j--)
                {
                    if (tmp > 0)
                    {
                        this.btnArray[i, j].BackColor = Color.Blue;
                        tmp--;
                    }
                    else{
                        this.btnArray[i, j].BackColor = Color.Transparent;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetSpectrum(trackBar.Value);
        }
    }

}
