using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_2_5inaRow
{
    class Magician: Character
    {
        public Magician(int p)
        {
            this.p = p;
            this.numB = 1;
            this.numC = 2;
            this.numD = 2;
            if (p == 1)
            {
                this.color = Color.DarkBlue;
            }
            else
            {
                this.color = Color.DarkOrange;
                this.numD++;
            }
        }
    }
}
