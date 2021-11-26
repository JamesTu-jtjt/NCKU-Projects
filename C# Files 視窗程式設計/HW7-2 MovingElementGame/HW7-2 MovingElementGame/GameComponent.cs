using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_2_MovingElementGame
{
    class GameComponent
    {
        private string element;
        private int row, posY;
        public GameComponent(int r, int y, int rand)
        {
            if (rand == 1)
            {
                this.element = "水";
            }
            else if (rand == 2)
            {
                this.element = "火";
            }
            else if (rand == 3)
            {
                this.element = "木";
            }
            this.row = r;
            this.posY = y;
        }

        public string GetE()
        {
            return this.element;
        }

        public int GetR()
        {
            return this.row;
        }

        public int GetY()
        {
            return this.posY;
        }

        public void SetElement(string newElement)
        {
            this.element = newElement;
        }

        public void PosYChange(int m)
        {
            this.posY += m;
        }
    }
}
