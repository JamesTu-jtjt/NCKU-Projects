using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW4_2_Meme_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TextClass txt = new TextClass();
        int picState = 1;

        private void Form1_Load(object sender, EventArgs e)
        {

            MemePic.Image = Image.FromFile("pic_01.png");

            BiaoFont.Checked = true;
            Bold.Checked = false;
            Italic.Checked = false;
            TL.Checked = true;
            TextVal.Text = "早安";
            SizeVal.Text = "12";

            txt.Size = 12;
            txt.ChangeStyle(false, false);
            txt.ChangeFamily("標楷體");
            txt.ChangeAlignment("TL");
            txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void PrevPic_Click(object sender, EventArgs e)
        {
            if (picState == 1)
            {
                picState = 5;
            }
            else
            {
                picState--;
            }
            switch (picState)
            {
                case 1:
                    MemePic.Image = Image.FromFile("pic_01.png");
                    break;
                case 2:
                    MemePic.Image = Image.FromFile("pic_02.png");
                    break;
                case 3:
                    MemePic.Image = Image.FromFile("pic_03.png");
                    break;
                case 4:
                    MemePic.Image = Image.FromFile("pic_04.png");
                    break;
                case 5:
                    MemePic.Image = Image.FromFile("pic_05.png");
                    break;
            }
        }

        private void NextPic_Click(object sender, EventArgs e)
        {
            if (picState == 5)
            {
                picState = 1;
            }
            else
            {
                picState++;
            }
            switch (picState)
            {
                case 1:
                    MemePic.Image = Image.FromFile("pic_01.png");
                    break;
                case 2:
                    MemePic.Image = Image.FromFile("pic_02.png");
                    break;
                case 3:
                    MemePic.Image = Image.FromFile("pic_03.png");
                    break;
                case 4:
                    MemePic.Image = Image.FromFile("pic_04.png");
                    break;
                case 5:
                    MemePic.Image = Image.FromFile("pic_05.png");
                    break;
            }
        }

        private void BiaoFont_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeFamily("標楷體");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void XinFont_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeFamily("新細明體");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void WeiFont_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeFamily("微軟正黑體");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void TL_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeAlignment("TL");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void TM_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeAlignment("TM");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void TR_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeAlignment("TR");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void DL_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeAlignment("BL");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void DM_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeAlignment("BM");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void DR_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeAlignment("BR");
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void Bold_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeStyle(Bold.Checked, Italic.Checked);
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void Italic_CheckedChanged(object sender, EventArgs e)
        {
            this.txt.ChangeStyle(Bold.Checked, Italic.Checked);
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void SizeVal_TextChanged(object sender, EventArgs e)
        {
            int newSize = 12;
            try
            {
                newSize = int.Parse(SizeVal.Text);
            }
            catch (FormatException)
            {
                newSize = 12;
            }
            if (newSize < 1 || newSize > 32)
            {
                newSize = 12;
            }
            this.txt.Size = newSize; 
            this.txt.ChangeLabel(MemeText);
            MemeText.Text = TextVal.Text;
        }

        private void TextVal_TextChanged(object sender, EventArgs e)
        {
            MemeText.Text = TextVal.Text;
        }

    }
}
