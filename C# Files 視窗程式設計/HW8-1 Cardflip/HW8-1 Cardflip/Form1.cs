using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW8_1_Cardflip
{
    public partial class Form1 : Form
    {
        string path = @"card.map";
        int row = 0, col = 0, round = 0, p1 = 0, p2 = 0, first = 1, c1 = 0, c2 = 0, total = 0;
        int cardFlip = 0;
        DialogResult result;
        Card[,] cards = new Card[2, 2];

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            StartBtn.Visible = true;
            P2L.Visible = false;
            P1L.Visible = false;
            RoundL.Visible = false;
            timer.Enabled = false;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(path);
            StartBtn.Visible = false;
            P2L.Visible = true;
            P1L.Visible = true;
            RoundL.Visible = true;
            string line;
            int tmp1 = 0, tmp2 = 0;
            line = sr.ReadLine();
            foreach (string s in line.Split(' '))
            {
                if (tmp1 == 0)
                {
                    row = int.Parse(s);
                }
                else
                {
                    col = int.Parse(s);
                }
                tmp1++;
            }
            tmp1 = 0;
            int[,] map = new int[row, col];
            this.total = row * col;
            do
            {
                line = sr.ReadLine();
                foreach (string s in line.Split(' '))
                {
                   map[tmp1, tmp2] = int.Parse(s);
                    tmp2++;
                }
                tmp2 = 0;
                tmp1++;
                if(tmp1 == this.row)
                {
                    tmp1 = 0;
                    break;
                }
            } while (true);
            sr.Close();

            this.cards = new Card[this.row, this.col];
            int width = 500 / this.row, height = 350 / this.col;
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                {
                    this.cards[i, j] = new Card();
                    this.cards[i, j].number = map[i, j];
                    this.cards[i, j].SetBounds(130 + width * j, 90 + height * i, width - 2, height - 2);
                    this.cards[i, j].showNumber();
                    this.cards[i, j].Click += new EventHandler(card_Click);
                    Controls.Add(this.cards[i, j]);
                    this.cards[i, j].Enabled = false;
                }
            }
            timer.Interval = 3000;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timer.Interval == 3000)
            {
                for (int i = 0; i < this.row; i++)
                {
                    for (int j = 0; j < this.col; j++)
                    {
                        this.cards[i, j].hideNumber();
                        this.cards[i, j].Enabled = true;
                    }
                }
                SetRound();
                timer.Enabled = false;
            }
            else if (timer.Interval == 2000)
            {
                if (this.c1 < this.c2)
                {
                    if (this.first == 1)
                    {
                        this.p1 += this.c2 - this.c1;
                        P1L.Text = "P1: " + this.p1.ToString() + "分";
                    }
                    else 
                    {
                        this.p2 += this.c2 - this.c1;
                        P2L.Text = "P2: " + this.p2.ToString() + "分";
                    }
                    for (int i = 0; i < this.row; i++)
                    {
                        for (int j = 0; j < this.col; j++)
                        {
                            if (this.cards[i, j].number == this.c1 || this.cards[i, j].number == this.c2)
                                this.cards[i, j].Dispose();
                        }
                    }
                    this.total -= 2;
                }
                else
                {
                    for (int i = 0; i < this.row; i++)
                    {
                        for (int j = 0; j < this.col; j++)
                        {
                            if (this.cards[i, j].number == this.c1 || this.cards[i, j].number == this.c2)
                                this.cards[i, j].hideNumber();
                        }
                    }
                }
                if (this.total <= this.row * this.col * 0.5)
                {
                    if (this.p1 > this.p2)
                    {
                        timer.Enabled = false;
                        this.result = MessageBox.Show("遊戲結束!! \n" + "P1 獲勝!", "", MessageBoxButtons.OK);
                    }
                    else if (this.p2 > this.p1)
                    {
                        timer.Enabled = false;
                        this.result = MessageBox.Show("遊戲結束!! \n" + "P2 獲勝!", "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        timer.Enabled = false;
                        this.result = MessageBox.Show("遊戲結束!! \n" + "P1 & P2 平手!", "", MessageBoxButtons.OK);
                    }
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    SetRound();
                    EnableCards(true);
                    this.c1 = 0;
                    this.c2 = 0;
                }
                timer.Enabled = false;
            }
        }

        private void card_Click(object sender, EventArgs e)
        {
            this.cardFlip++;
            if (this.cardFlip == 1)
            {
                Card cardRef = (Card)sender;
                cardRef.showNumber();
                this.c1 = cardRef.number;
                SetTurn(this.round % 2);
            }
            else if (this.cardFlip == 2)
            {
                Card cardRef = (Card)sender;
                cardRef.showNumber();
                this.c2 = cardRef.number;
                timer.Interval = 2000;
                timer.Enabled = true;
                this.cardFlip = 0;
                EnableCards(false);
            }
            
        }

        private void SetRound()
        {
            this.round++;
            if (this.round % 2 == 1)
            {
                RoundL.Text = "第" + this.round.ToString() + "回合 輪到P1";
                first = 1;
            }
            else
            {
                RoundL.Text = "第" + this.round.ToString() + "回合 輪到P2";
                first = 2;
            }
        }

        private void SetTurn(int t)
        {
            if (t == 0)
            {
                RoundL.Text = "第" + this.round.ToString() + "回合 輪到P1";
            }
            else
            {
                RoundL.Text = "第" + this.round.ToString() + "回合 輪到P2";
            }
        }

        private void EnableCards(bool b)
        {
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                {
                    this.cards[i, j].Enabled = b;
                }
            }
        }
    }
}
