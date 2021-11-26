using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_2_MovingElementGame
{
    class Enemy: GameComponent
    {
        private int speed;
        public Enemy(int r, int y, int rand) : base(r, y, rand)
        {
            if (rand == 1)
            {
                this.speed = 10;
            }
            else if(rand == 2)
            {
                this.speed = 20;
            }
            else if(rand == 3)
            {
                this.speed = 30;
            }
        }
        public int GetSpeed()
        {
            return this.speed;
        }

        public void Move()
        {
            this.PosYChange(this.GetSpeed());
        }

        public bool isHit(int r, int y)
        {
            if (r == this.GetR() && y < this.GetY() + 40 && !(y + 30 < this.GetY()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isHit(Bullet b)
        {
            if (b.GetR() == this.GetR() && b.GetY() <= this.GetY() + 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int HitResult(string element)
        {
            if ((this.GetE() == "水" && element == "火") || (this.GetE() == "火" && element == "木") || (this.GetE() == "木" && element == "水"))
            {
                return -1;
            }
            else if ((this.GetE() == "火" && element == "水") || (this.GetE() == "水" && element == "木") || (this.GetE() == "木" && element == "火"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
