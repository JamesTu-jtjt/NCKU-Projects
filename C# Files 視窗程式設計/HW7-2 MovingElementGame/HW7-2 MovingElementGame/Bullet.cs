using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_2_MovingElementGame
{
    class Bullet: GameComponent
    {
        private int speed;
        public Bullet(int r, int y, int rand) : base(r, y, rand)
        {
            if (rand == 1)
            {
                this.speed = -10;
            }
            else if (rand == 2)
            {
                this.speed = -20;
            }
            else if(rand == 3)
            {
                this.speed = -30;
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
    }
}
