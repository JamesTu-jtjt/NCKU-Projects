using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_2_5inaRow
{
    class Archer: Character
    {
        public Archer(int p)
        {
            this.p = p;
            this.numB = 1;
            this.numC = 1;
            this.numD = 3;
            if (p == 1)
            {
                this.color = Color.BlueViolet;
            }
            else
            {
                this.color = Color.OrangeRed;
                this.numD++;
            }
        }
    }
}
