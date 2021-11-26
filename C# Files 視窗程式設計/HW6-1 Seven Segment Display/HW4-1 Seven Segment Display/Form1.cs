using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW4_1_Seven_Segment_Display
{
    public partial class Form1 : Form
    {
        int h = 0, w = 0, state = 100;
        Button[] btnArray10, btnArray1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            input.Enabled = false;
        } 

        private void input_TextChanged(object sender, EventArgs e)
        {
            Display_Input(input.Text);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int hnew = 0, wnew = 0;
            bool newSize = true;
            DialogResult result;
            try
            {
                hnew = int.Parse(height.Text);
                wnew = int.Parse(width.Text);
                if (hnew < 7 || hnew > 15 || wnew < 5 || wnew > 10)
                {
                    result = MessageBox.Show("請輸入範圍內的數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    newSize = false;
                }
                else if (hnew % 2 == 0)
                {
                    result = MessageBox.Show("高不能為偶數", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    newSize = false;
                }
                if (newSize)
                {
                    for (int i = 0; i < h * w; i++)
                    {
                        this.btnArray10[i].Dispose();
                        this.btnArray1[i].Dispose();
                    }
                    h = hnew;
                    w = wnew;
                    this.btnArray10 = new Button[h * w];
                    this.btnArray1 = new Button[h * w];
                    Create_btnDisplay();
                    input.Enabled = true;
                    Display_Input(input.Text);
                }
            }
            catch(FormatException)
            {
                result = MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                newSize = false;
            }
        }

        private void Create_btnDisplay()
        {
            int width = 300 / this.w, height = 400 / this.h;
            for (int i = 0; i < this.h; i++)
            {
                for (int j = 0; j < this.w; j++)
                {
                    this.btnArray10[i * this.w + j] = new Button();
                    this.btnArray10[i * this.w + j].SetBounds(200 + width * j, 50 + height * i, width - 2, height - 2);
                    this.btnArray10[i * this.w + j].BackColor = Color.White;
                    Controls.Add(this.btnArray10[i * this.w + j]);

                    this.btnArray1[i * this.w + j] = new Button();
                    this.btnArray1[i * this.w + j].SetBounds(600 + width * j, 50 + height * i, width - 2, height - 2);
                    this.btnArray1[i * this.w + j].BackColor = Color.White;
                    Controls.Add(this.btnArray1[i * this.w + j]);
                }
            }
        }

        private void Display_Input(string input)
        {
            string num10, num1;
            try
            {
                this.state = int.Parse(input);
            }
            catch (FormatException)
            {
                this.state = 100;
            }
            if(this.state >= 100 || this.state < -9)
            {
                for (int i = 0; i < this.h * this.w; i++)
                {
                    this.btnArray10[i].BackColor = Color.White;
                    this.btnArray1[i].BackColor = Color.White;
                }
            }
            else
            {
                if(this.state < 0)
                {
                    num10 = "-";
                    num1 = (this.state * - 1).ToString();
                }
                else
                {
                    num10 = (this.state / 10).ToString();
                    num1 = (this.state % 10).ToString();
                }
                Seven_Segment(num10, ref this.btnArray10);
                Seven_Segment(num1, ref this.btnArray1);
            }
        }

        private void Seven_Segment(string s, ref Button[] BtnArray)
        {
            switch (s)
            {
                case "0":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i == 0 || i == this.h - 1)
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else if (i != this.h / 2)
                            {
                                if (j == 0 || j == this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else
                            {
                                BtnArray[i * this.w + j].BackColor = Color.White;
                            }
                        }
                    }
                    break;
                case "1":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (j == this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else
                            {
                                BtnArray[i * this.w + j].BackColor = Color.White;
                            }
                        }
                    }
                    break;
                case "2":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (i < this.h / 2)
                                {
                                    if (j == this.w - 1)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                            }
                            else
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                        }
                    }
                    break;
                case "3":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (j == this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                        }
                    }
                    break;
                case "4":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (i < this.h / 2)
                                {
                                    if (j == 0 || j == this.w - 1)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                                else
                                {

                                    if (j == this.w - 1)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                            }
                            else if (i == this.h / 2)
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else
                            {
                                BtnArray[i * this.w + j].BackColor = Color.White;
                            }
                        }
                    }
                    break;
                case "5":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (i > this.h / 2)
                                {
                                    if (j == this.w - 1)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                            }
                            else
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                        }
                    }
                    break;
                case "6":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (i < this.h / 2)
                                {
                                    if (j == 0)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                                else
                                {
                                    if (j == 0 || j == this.w - 1)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                            }
                            else
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                        }
                    }
                    break;
                case "7":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (j == this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else if (i == 0)
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else
                            {
                                BtnArray[i * this.w + j].BackColor = Color.White;
                            }
                        }
                    }
                    break;
                case "8":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (j == 0 || j == this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                        }
                    }
                    break;
                case "9":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i != 0 && i != this.h - 1 && i != this.h / 2)
                            {
                                if (i < this.h / 2)
                                {
                                    if (j == 0 || j == this.w - 1)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                                else
                                {
                                    if (j == this.w - 1)
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        BtnArray[i * this.w + j].BackColor = Color.White;
                                    }
                                }
                            }
                            else
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                        }
                    }
                    break;
                case "-":
                    for (int i = 0; i < this.h; i++)
                    {
                        for (int j = 0; j < this.w; j++)
                        {
                            if (i == this.h / 2)
                            {
                                if (j != 0 && j != this.w - 1)
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.Blue;
                                }
                                else
                                {
                                    BtnArray[i * this.w + j].BackColor = Color.White;
                                }
                            }
                            else
                            {
                                BtnArray[i * this.w + j].BackColor = Color.White;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
