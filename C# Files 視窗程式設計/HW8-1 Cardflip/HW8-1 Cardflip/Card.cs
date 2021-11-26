using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_1_Cardflip
{
    class Card: System.Windows.Forms.Button
    {
        public int number;
        public bool isShow;
        public void hideNumber()
        {
            this.Text = "";
            this.BackColor = Color.LightSlateGray;
            this.isShow = false;
        }
        public void showNumber()
        {
            this.Text = this.number.ToString();
            this.BackColor = Color.DeepSkyBlue;
            this.isShow = true;
        }
    }
}
