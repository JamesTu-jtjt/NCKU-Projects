using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW3_1_Substitution_Cipher
{
    public partial class Form1 : Form
    {
        SubstitutionCipher cipher = new SubstitutionCipher();
        string history = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            plaintextLabel.Visible = true;
            keyBox.Visible = true;
            conBtn.Visible = true;
            rndBtn.Visible = true;
            errorMes.Visible = true;
            labelDown.Visible = false;
            labelUp.Visible = false;
            textBoxUp.Visible = false;
            textBoxDown.Visible = false;
            historyTxt.Visible = false;

            this.cipher.Generate();
            plaintextLabel.Text = this.cipher.alphabet;
            keyBox.Text = this.cipher.key;
            this.history += "新的替換表 \n" + this.cipher.key + "\n" + "\n";
            Head.Text = "替換表";

        }


        private void rndBtn_Click(object sender, EventArgs e)
        {
            this.cipher.Generate();
            keyBox.Text = "";
            keyBox.Text = this.cipher.key;
        }

        private void conBtn_Click(object sender, EventArgs e)
        {
            if (keyBox.Visible)
            {
                errorMes.Text = this.cipher.IsValid(keyBox.Text) ? "替換表合法" : "替換表不合法，請重新輸入";
                if (this.cipher.IsValid(keyBox.Text))
                {
                    this.cipher.key = keyBox.Text;
                    this.history += "新的替換表 \n" + this.cipher.key + "\n" + "\n";
                }
            }
            else if(Head.Text == "加密")
            {
                textBoxDown.Text = this.cipher.GetEncryption(textBoxUp.Text);
                this.history += "加密 \n" + "明文: " + textBoxUp.Text + "\n" + "密文: " + textBoxDown.Text + "\n" + "\n";
            }
            else if (Head.Text == "解密")
            {
                textBoxDown.Text = this.cipher.GetDecryption(textBoxUp.Text);
                this.history += "解密 \n" + "密文: " + textBoxUp.Text + "\n" + "明文: " + textBoxDown.Text + "\n" + "\n";
            }

        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            plaintextLabel.Visible = true;
            keyBox.Visible = true;
            conBtn.Visible = true;
            rndBtn.Visible = true;
            errorMes.Visible = true;
            labelDown.Visible = false;
            labelUp.Visible = false;
            textBoxUp.Visible = false;
            textBoxDown.Visible = false;
            historyTxt.Visible = false;

            plaintextLabel.Text = this.cipher.alphabet;
            keyBox.Text = this.cipher.key;
            Head.Text = "替換表";
        }

        private void enBtn_Click(object sender, EventArgs e)
        {
            plaintextLabel.Visible = false;
            keyBox.Visible = false;
            conBtn.Visible = true;
            rndBtn.Visible = false;
            errorMes.Visible = false;
            labelDown.Visible = true;
            labelUp.Visible = true;
            textBoxUp.Visible = true;
            textBoxDown.Visible = true;
            historyTxt.Visible = false;

            Head.Text = "加密";
            labelUp.Text = "輸入字串";
            labelDown.Text = "加密結果";
            textBoxUp.Text = "";
            textBoxDown.Text = "";
        }

        private void deBtn_Click(object sender, EventArgs e)
        {
            plaintextLabel.Visible = false;
            keyBox.Visible = false;
            conBtn.Visible = true;
            rndBtn.Visible = false;
            errorMes.Visible = false;
            labelDown.Visible = true;
            labelUp.Visible = true;
            textBoxUp.Visible = true;
            textBoxDown.Visible = true;
            historyTxt.Visible = false;

            Head.Text = "解密";
            labelUp.Text = "輸入密文";
            labelDown.Text = "解密結果";
            textBoxUp.Text = "";
            textBoxDown.Text = "";
        }

        private void hisBtn_Click(object sender, EventArgs e)
        {
            plaintextLabel.Visible = false;
            keyBox.Visible = false;
            conBtn.Visible = false;
            rndBtn.Visible = false;
            errorMes.Visible = false;
            labelDown.Visible = false;
            labelUp.Visible = false;
            textBoxUp.Visible = false;
            textBoxDown.Visible = false;
            historyTxt.Visible = true;

            Head.Text = "歷史紀錄";
            historyTxt.Text = this.history;
        }
    }
}
