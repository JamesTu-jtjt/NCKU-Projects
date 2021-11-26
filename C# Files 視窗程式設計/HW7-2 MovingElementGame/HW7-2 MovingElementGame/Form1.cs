using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW7_2_MovingElementGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int element = 1;
        int state = 1, p = 0, t = 60, tick = 0, cooldown = 0;
        bool canShoot = true;
        Button[] bA = new Button[4], eB = new Button[4], bB = new Button[4];
        Enemy[] enemies = new Enemy[4];
        Bullet[] bullets = new Bullet[4];
        Random rnd = new Random();
        int rand = 2;
        DialogResult r;

        private void Form1_Load(object sender, EventArgs e)
        {
            ElementL.Visible = false;
            PointsL.Visible = false;
            TimeL.Visible = false;
            EVal.Visible = false;
            PVal.Visible = false;
            TVal.Visible = false;
            this.KeyPreview = false;
            timer.Enabled = false;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            ElementL.Visible = true;
            PointsL.Visible = true;
            TimeL.Visible = true;
            EVal.Visible = true;
            PVal.Visible = true;
            TVal.Visible = true;
            Choose.Visible = false;
            WaterRb.Visible = false;
            FireRb.Visible = false;
            WoodRb.Visible = false;
            StartBtn.Visible = false;
            PVal.Text = this.p.ToString();
            TVal.Text = this.t.ToString();
            for (int i = 0; i < 4; i++)
            {
                this.bA[i] = new Button();
                this.bA[i].SetBounds(100 + 50 * i, 300, 40, 40);
                this.bA[i].Text = "你";
                this.Controls.Add(bA[i]);
                this.bA[i].ForeColor = Color.White;
                this.bA[i].Visible = false;
                SpawnEnemy(i);
            }
            if (WaterRb.Checked)
            {
                SetElement("水");
            }
            else if (FireRb.Checked)
            {
                SetElement("火");
            }
            else if (WoodRb.Checked)
            {
                SetElement("木");
            }
            bA[state].Visible = true;
            this.KeyPreview = true;
            timer.Enabled = true;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (this.state > 0)
                    {
                        bA[this.state].Visible = false;
                        this.state--;
                        bA[this.state].Visible = true;
                    }
                    break;
                case Keys.D:
                    if (this.state < 3)
                    {
                        bA[this.state].Visible = false;
                        this.state++;
                        bA[this.state].Visible = true;
                    }
                    break;
                case Keys.W:
                    if (this.canShoot)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (this.bullets[i] == null)
                            {
                                this.bullets[i] = new Bullet(state, 300, this.element);
                                this.bB[i] = new Button();
                                this.bB[i].SetBounds(110 + 50 * state, 300, 20, 20);
                                this.Controls.Add(bB[i]);
                                SetElement(this.bullets[i].GetE(), ref this.bB[i]);
                                this.bB[i].Text = "";
                                break;
                            }
                        }
                        this.canShoot = false;
                    }
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.tick += 1;
            if (!this.canShoot)
            {
                this.cooldown += 1;
                if (this.cooldown == 10)
                {
                    this.canShoot = true;
                    this.cooldown = 0;
                }
            }
            if (this.tick == 10)
            {
                this.t -= 1;
                TVal.Text = this.t.ToString();
                this.tick = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                this.enemies[i].Move();
                if(this.enemies[i].GetY() <= 400)
                {
                    this.eB[i].Top += this.enemies[i].GetSpeed();
                }
                else
                {
                    this.eB[i].Dispose();
                    this.rand = rnd.Next(1, 4);
                    SpawnEnemy(i);
                }
                if (this.bullets[i] != null)
                {
                    this.bullets[i].Move();
                    this.bB[i].Top += this.bullets[i].GetSpeed();
                    for (int j = 0; j < 4; j++)
                    {
                        if (this.enemies[j].isHit(this.bullets[i]))
                        {
                            switch (this.enemies[j].HitResult(this.bullets[i].GetE()))
                            {
                                case 0:
                                    this.eB[j].Dispose();
                                    this.bB[i].Dispose();
                                    this.bullets[i] = null;
                                    SpawnEnemy(j);
                                    break;
                                case 1:
                                    this.p += 2;
                                    PVal.Text = this.p.ToString();
                                    this.eB[j].Dispose();
                                    this.bB[i].Dispose();
                                    this.bullets[i] = null;
                                    SpawnEnemy(j);
                                    break;
                                case -1:
                                    this.p -= 2;
                                    PVal.Text = this.p.ToString();
                                    this.eB[j].Dispose();
                                    this.bB[i].Dispose();
                                    this.bullets[i] = null;
                                    SpawnEnemy(j);
                                    break;
                            }
                            break;
                        }
                    }
                }
                if (this.enemies[i].isHit(state, 300))
                {
                    switch (this.enemies[i].HitResult(EVal.Text))
                    {
                        case 0:
                            break;
                        case 1:
                            this.p += 5;
                            PVal.Text = this.p.ToString();
                            this.eB[i].Dispose();
                            SetElement(this.enemies[i].GetE());
                            SpawnEnemy(i);
                            break;
                        case -1:
                            this.p -= 5;
                            PVal.Text = this.p.ToString();
                            this.eB[i].Dispose();
                            SpawnEnemy(i);
                            break;
                    }
                }
            }
            if (this.p < 0)
            {
                timer.Enabled = false;
                PVal.Text = "0";
                string endText = "";
                switch (this.element)
                {
                    case 1:
                        endText = "你枯竭了!";
                        break;
                    case 2:
                        endText = "你被熄滅了!";
                        break;
                    case 3:
                        endText = "你燒起來了!";
                        break;
                }
                this.r = MessageBox.Show(endText + "\n" + "你的分數: 0", "", MessageBoxButtons.OK);
                if (this.r == DialogResult.OK)
                {
                    this.Close();
                }
            }
            if (this.t <= 0)
            {
                this.t = 0;
                TVal.Text = this.t.ToString();
                timer.Enabled = false;
                this.r = MessageBox.Show("遊戲結束!\n" + "你的分數: " + this.p.ToString(), "", MessageBoxButtons.OK);
                if (this.r == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        public void SetElement(string element, ref Button b)
        {
            switch (element)
            {
                case "水":
                    b.Text = "水";
                    b.BackColor = Color.Blue;
                    break;
                case "火":
                    b.Text = "火";
                    b.BackColor = Color.Red;
                    break;
                case "木":
                    b.Text = "木";
                    b.BackColor = Color.Green;
                    break;
            }
        }

        public void SetElement(string element)
        {
            switch (element)
            {
                case "水":
                    this.element = 1;
                    for (int i = 0; i < 4; i++)
                    {
                        this.bA[i].BackColor = Color.Blue;
                    }
                    EVal.Text = "水";
                    break;
                case "火":
                    this.element = 2;
                    for (int i = 0; i < 4; i++)
                    {
                        this.bA[i].BackColor = Color.Red;
                    }
                    EVal.Text = "火";
                    break;
                case "木":
                    this.element = 3;
                    for (int i = 0; i < 4; i++)
                    {
                        this.bA[i].BackColor = Color.Green;
                    }
                    EVal.Text = "木";
                    break;
            }
        }

        public void SpawnEnemy(int i)
        {
            this.rand = this.rnd.Next(1, 4);
            this.enemies[i] = new Enemy(i, 10, this.rand);
            this.eB[i] = new Button();
            this.eB[i].SetBounds(100 + 50 * i, 10, 40, 40);
            this.Controls.Add(eB[i]);
            this.eB[i].ForeColor = Color.White;
            SetElement(enemies[i].GetE(), ref this.eB[i]);
        }
    }
}
