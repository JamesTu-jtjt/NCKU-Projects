using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW3_2_Electronic_Chicken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Chicken chicken = new Chicken();
        int money = 100;

        private void Form1_Load(object sender, EventArgs e)
        {
            feedBtn.Enabled = false;
            playBtn.Enabled = false;
            cleanBtn.Enabled = false;
            docBtn.Enabled = false;
            endDayBtn.Enabled = false;
        }

        private void nameBtn_Click(object sender, EventArgs e)
        {
            if(nameBox.Text != "")
            {
                this.chicken.Name = nameBox.Text;
            }
            nameBox.Enabled = false;
            nameBtn.Enabled = false;
            feedBtn.Enabled = true;
            playBtn.Enabled = true;
            cleanBtn.Enabled = true;
            docBtn.Enabled = true;
            endDayBtn.Enabled = true;
            log.AppendText("你開始養了" + this.chicken.Name + "\n");
            log.AppendText("第 " + this.chicken.Age + " 天" + "\n");
            healthVal.Text = this.chicken.Health.ToString() + "%";
            weightVal.Text = this.chicken.Weight.ToString() + "g";
            satisVal.Text = this.chicken.Satisfaction.ToString() + "%";
            moodVal.Text = this.chicken.Mood.ToString() + "%";
            moneyVal.Text = this.money.ToString() + " 元";
            eventVal.Text = this.chicken.Name + "出生了";

        }

        private void feedBtn_Click(object sender, EventArgs e)
        {
            if (this.money >= 10)
            {
                this.chicken.Feed(ref this.money);
                log.AppendText("餵食了" + this.chicken.Name + "\n");
            }
            else
            {
                log.AppendText("金額不足無法餵食\n");
            }
            healthVal.Text = this.chicken.Health.ToString() + "%";
            weightVal.Text = this.chicken.Weight.ToString() + "g";
            satisVal.Text = this.chicken.Satisfaction.ToString() + "%";
            moodVal.Text = this.chicken.Mood.ToString() + "%";
            moneyVal.Text = this.money.ToString() + " 元";
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (this.money >= 5)
            {
                this.chicken.Play(ref this.money);
                log.AppendText("與" + this.chicken.Name + "玩耍了\n");
            }
            else
            {
                log.AppendText("金額不足無法玩耍\n");
            }
            healthVal.Text = this.chicken.Health.ToString() + "%";
            weightVal.Text = this.chicken.Weight.ToString() + "g";
            satisVal.Text = this.chicken.Satisfaction.ToString() + "%";
            moodVal.Text = this.chicken.Mood.ToString() + "%";
            moneyVal.Text = this.money.ToString() + " 元";
        }

        private void cleanBtn_Click(object sender, EventArgs e)
        {
            if (this.money >= 5)
            {
                this.chicken.Clean(ref this.money);
                log.AppendText("清理了" + this.chicken.Name + "\n");
            }
            else
            {
                log.AppendText("金額不足無法打掃\n");
            }
            healthVal.Text = this.chicken.Health.ToString() + "%";
            weightVal.Text = this.chicken.Weight.ToString() + "g";
            satisVal.Text = this.chicken.Satisfaction.ToString() + "%";
            moodVal.Text = this.chicken.Mood.ToString() + "%";
            moneyVal.Text = this.money.ToString() + " 元";
        }

        private void docBtn_Click(object sender, EventArgs e)
        {
            if (this.money >= 20)
            {
                this.chicken.Feed(ref this.money);
                log.AppendText("帶" + this.chicken.Name + "去看醫生\n");
            }
            else
            {
                log.AppendText("金額不足無法看醫生\n");
            }
            healthVal.Text = this.chicken.Health.ToString() + "%";
            weightVal.Text = this.chicken.Weight.ToString() + "g";
            satisVal.Text = this.chicken.Satisfaction.ToString() + "%";
            moodVal.Text = this.chicken.Mood.ToString() + "%";
            moneyVal.Text = this.money.ToString() + " 元";
        }

        private void endDayBtn_Click(object sender, EventArgs e)
        {
            log.AppendText("\n");
            this.chicken.Grow(ref money);
            log.AppendText("第" + this.chicken.Age + "天\n");
            if (this.chicken.IsDead)
            {
                feedBtn.Enabled = false;
                playBtn.Enabled = false;
                cleanBtn.Enabled = false;
                docBtn.Enabled = false;
                endDayBtn.Enabled = false;

                log.AppendText("死掉了，遊戲結束\n");
                eventVal.Text = this.chicken.Name + "死了\n";
            }
            else
            {
                bool nothing = true;
                if(this.chicken.IsDirty || this.chicken.IsSick)
                {
                    nothing = false;
                    eventVal.Text = "";
                    if (this.chicken.IsDirty)
                    {
                        log.AppendText("牠大便了\n");
                        eventVal.Text += this.chicken.Name + "大便了 ";
                    }
                    if (this.chicken.IsSick)
                    {
                        log.AppendText(this.chicken.Name + "生病了\n");
                        eventVal.Text += this.chicken.Name + "生病了 ";
                    }
                }
                if(this.chicken.Weight > 1000 && this.chicken.Health > 60)
                {
                    Random rnd = new Random();
                    int randomNum = rnd.Next(1, 101);
                    int sell = rnd.Next(15, 26);
                    if(randomNum <= this.chicken.Mood)
                    {
                        nothing = false;
                        this.chicken.Health -= 5;
                        log.AppendText(this.chicken.Name + "下蛋了，賣掉後獲得" + sell.ToString() + "元");
                        this.money += sell;
                    }
                }
                if (nothing)
                {
                    log.AppendText("一天平安的過去了\n");
                    eventVal.Text = this.chicken.Name + "今天很乖";
                    nothing = true;
                }
            }
            healthVal.Text = this.chicken.Health.ToString() + "%";
            weightVal.Text = this.chicken.Weight.ToString() + "g";
            satisVal.Text = this.chicken.Satisfaction.ToString() + "%";
            moodVal.Text = this.chicken.Mood.ToString() + "%";
            moneyVal.Text = this.money.ToString() + " 元";
        }
    }
}
