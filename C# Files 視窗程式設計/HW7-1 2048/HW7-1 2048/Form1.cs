using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW7_1_2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[] b = new Button[24];
        bool normal = false, gameOver = false;
        int p = 0, n = 2, t = 3;
        DialogResult result;

        private void Form1_Load(object sender, EventArgs e)
        {
            Points.Visible = false;
            Num.Visible = false;
            Time.Visible = false;
            pVal.Visible = false;
            nVal.Visible = false;
            tVal.Visible = false;
            EasyBtn.Visible = true;
            NormalBtn.Visible = true;
            timer.Enabled = false;
            EasyBtn.Text = "簡單模式";
            NormalBtn.Text = "普通模式";
            this.KeyPreview = false;
        }

        private void EasyBtn_Click(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.n = Rand();
            this.normal = false;
            Points.Visible = true;
            Num.Visible = true;
            Time.Visible = false;
            pVal.Visible = true;
            nVal.Visible = true;
            tVal.Visible = false;
            EasyBtn.Visible = false;
            NormalBtn.Visible = false;
            timer.Enabled = false;
            pVal.Text = this.p.ToString();
            nVal.Text = this.n.ToString();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    b[i * 4 + j] = new Button();
                    b[i * 4 + j].SetBounds(10 + 52 * j, 100 + 52 * i, 50, 50);
                    b[i * 4 + j].Visible = false;
                    Controls.Add(b[i * 4 + j]);
                }
            }
        }


        private void NormalBtn_Click(object sender, EventArgs e)
        {
            this.normal = true;
            this.KeyPreview = true;
            this.n = Rand();
            Points.Visible = true;
            Num.Visible = true;
            Time.Visible = true;
            pVal.Visible = true;
            nVal.Visible = true;
            tVal.Visible = true;
            EasyBtn.Visible = false;
            NormalBtn.Visible = false;
            timer.Enabled = true;
            pVal.Text = this.p.ToString();
            nVal.Text = this.n.ToString();
            tVal.Text = this.t.ToString();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    b[i * 4 + j] = new Button();
                    b[i * 4 + j].SetBounds(10 + 52 * j, 100 + 52 * i, 50, 50);
                    b[i * 4 + j].Visible = false;
                    Controls.Add(b[i * 4 + j]);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameOver)
            {
                switch (e.KeyCode)
                {
                    case Keys.Q:
                        for (int i = 5; i >= 0; i--)
                        {
                            if (this.b[4 * i].Visible == false)
                            {
                                this.b[4 * i].Visible = true;
                                this.b[4 * i].Text = nVal.Text;
                                this.n = Rand();
                                nVal.Text = this.n.ToString();
                                if (i == 0 && this.b[4 * i].Text != this.b[4 * (i + 1)].Text)
                                {
                                    this.gameOver = true;
                                    timer.Enabled = false;
                                    this.result = MessageBox.Show("遊戲結束!!! \n" + Points.Text + pVal.Text, "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        this.Close();
                                    }
                                }
                                break;
                            }
                        }
                        if (normal)
                        {
                            this.t = 3;
                            tVal.Text = this.t.ToString();
                            timer.Enabled = false;
                            timer.Enabled = true;
                        }
                        break;
                    case Keys.W:
                        for (int i = 5; i >= 0; i--)
                        {
                            if (this.b[4 * i + 1].Visible == false)
                            {
                                this.b[4 * i + 1].Visible = true;
                                this.b[4 * i + 1].Text = nVal.Text;
                                this.n = Rand();
                                nVal.Text = this.n.ToString();
                                if (i == 0 && this.b[4 * i + 1].Text != this.b[4 * (i + 1) + 1].Text)
                                {
                                    timer.Enabled = false;
                                    this.gameOver = true;
                                    this.result = MessageBox.Show("遊戲結束!!! \n" + Points.Text + pVal.Text, "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        this.Close();
                                    }
                                }
                                break;
                            }
                        }
                        if (normal)
                        {
                            this.t = 3;
                            tVal.Text = this.t.ToString();
                            timer.Enabled = false;
                            timer.Enabled = true;
                        }
                        break;
                    case Keys.E:
                        for (int i = 5; i >= 0; i--)
                        {
                            if (this.b[4 * i + 2].Visible == false)
                            {
                                this.b[4 * i + 2].Visible = true;
                                this.b[4 * i + 2].Text = nVal.Text;
                                this.n = Rand();
                                timer.Enabled = false;
                                nVal.Text = this.n.ToString();
                                if (i == 0 && this.b[4 * i + 2].Text != this.b[4 * (i + 1) + 2].Text)
                                {

                                    this.gameOver = true;
                                    timer.Enabled = false;
                                    this.result = MessageBox.Show("遊戲結束!!! \n" + Points.Text + pVal.Text, "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        this.Close();
                                    }
                                }
                                break;
                            }
                        }
                        if (normal)
                        {
                            this.t = 3;
                            tVal.Text = this.t.ToString();
                            timer.Enabled = false;
                            timer.Enabled = true;
                        }
                        break;
                    case Keys.R:
                        for (int i = 5; i >= 0; i--)
                        {
                            if (this.b[4 * i + 3].Visible == false)
                            {
                                this.b[4 * i + 3].Visible = true;
                                this.b[4 * i + 3].Text = nVal.Text;
                                this.n = Rand();
                                nVal.Text = this.n.ToString();
                                if (i == 0 && this.b[4 * i + 3].Text != this.b[4 * (i + 1) + 3].Text)
                                {
                                    timer.Enabled = false;
                                    this.gameOver = true;
                                    this.result = MessageBox.Show("遊戲結束!!! \n" + Points.Text + pVal.Text, "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        this.Close();
                                    }
                                }
                                break;
                            }
                        }
                        if (normal)
                        {
                            this.t = 3;
                            tVal.Text = this.t.ToString();
                            timer.Enabled = false;
                            timer.Enabled = true;
                        }
                        break;
                    case Keys.A:
                        if (!this.normal)
                        {
                            this.n = 2;
                            nVal.Text = this.n.ToString();
                        }
                        break;

                    case Keys.S:
                        if (!this.normal)
                        {
                            this.n = 4;
                            nVal.Text = this.n.ToString();
                        }
                        break;
                    case Keys.D:
                        if (!this.normal)
                        {
                            this.n = 8;
                            nVal.Text = this.n.ToString();
                        }
                        break;
                }
                Merge(ref this.b);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.t -= 1;
            if (this.t <= 0)
            {
                this.t = 3;
                for (int i = 5; i >= 0; i--)
                {
                    if (this.b[4 * i + 1].Visible == false)
                    {
                        this.b[4 * i + 1].Visible = true;
                        this.b[4 * i + 1].Text = nVal.Text;
                        this.n = Rand();
                        nVal.Text = this.n.ToString();
                        if (i == 0 && this.b[4 * i + 1].Text != this.b[4 * (i + 1) + 1].Text)
                        {
                            this.gameOver = true;
                            timer.Enabled = false;
                            this.t = 0;
                            tVal.Text = this.t.ToString();
                            this.result = MessageBox.Show("遊戲結束!!! \n" + Points.Text + pVal.Text, "", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                this.Close();
                            } 
                        }
                        break;
                    }
                }
                Merge(ref this.b);
            }
            tVal.Text = this.t.ToString();
        }

        private int Rand()
        {
            Random r = new Random();
            int n = r.Next(0, 3);
            if (n == 0)
            {
                return 2;
            }
            else if (n == 1)
            {
                return 4;
            }
            else
            {
                return 8;
            }
        }

        private void Merge(ref Button[] b)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (b[i * 4 + j].Visible == true)
                        {
                            if (b[i * 4 + j].Text == b[(i + 1) * 4 + j].Text)
                            {
                                flag = true;
                                b[i * 4 + j].Visible = false;
                                b[(i + 1) * 4 + j].Text = (int.Parse(b[(i + 1) * 4 + j].Text) * 2).ToString();
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
            }
            Delete(ref b);
        }

        private void Delete (ref Button[] b)
        {
            bool d = false, flag = true;
            for (int i = 0; i < 6; i++)
            {
                if (b[i * 4 + 0].Visible && b[i * 4 + 1].Visible && b[i * 4 + 2].Visible && b[i * 4 + 3].Visible && 
                    b[i * 4 + 0].Text == b[i * 4 + 1].Text && b[i * 4 + 0].Text == b[i * 4 + 2].Text && b[i * 4 + 0].Text == b[i * 4 + 3].Text)
                {
                    d = true;
                    pVal.Text = (int.Parse(pVal.Text) + int.Parse(b[i * 4].Text) * int.Parse(b[i * 4].Text)).ToString();
                    for (int j = 0; j < 4; j++)
                    {
                        b[i * 4 + j].Visible = false;
                    }
                    while (flag)
                    {
                        flag = false;
                        for (int i2 = 0; i2 < 5; i2++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (b[i2 * 4 + j].Visible)
                                {
                                    if (!b[(i2 + 1) * 4 + j].Visible)
                                    {
                                        flag = true;
                                        b[(i2 + 1) * 4 + j].Visible = true;
                                        b[(i2 + 1) * 4 + j].Text = b[i2 * 4 + j].Text;
                                        b[i2 * 4 + j].Visible = false;
                                    }
                                } 
                            }
                        }
                    }
                }
            }
            if (d)
            {
                Merge(ref b);
            }
        }
    }
}
