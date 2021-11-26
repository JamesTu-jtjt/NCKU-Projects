using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_2_Electronic_Chicken
{
    class Chicken
    {
        public String Name = "電子雞";
        public int Age = 1;
        public int Health
        {
            get
            {
                if (health > 100)
                {
                    health = 100;
                }
                else if (health < 0)
                {
                    health = 0;
                }
                return health;
            }
            set
            {
                health = value;
            }
        }
        private int health = 70;
        public int Weight
        {
            get
            {
                if (weight > 4000)
                {
                    weight = 4000;
                }
                else if (weight < 0)
                {
                    weight = 0;
                }
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        private int weight = 700;
        
        public int Satisfaction
        {
            get
            {
                if (satisfaction > 100)
                {
                    satisfaction = 100;
                }
                else if (satisfaction < 0)
                {
                    satisfaction = 0;
                }
                return satisfaction;
            }
            set
            {
                satisfaction = value;
            }
        }
        private int satisfaction = 70;
        public int Mood
        {
            get
            {
                if (mood > 100)
                {
                    mood = 100;
                }
                else if (mood < 0)
                {
                    mood = 0;
                }
                return mood;
            }
            set
            {
                mood = value;
            }
        }
        private int mood = 50;
        public bool IsDirty = false;
        public bool IsSick = false;
        public bool IsDead = false;

        public void Feed(ref int money)
        {
            Random rnd = new Random();
            money -= 10;
            this.satisfaction += rnd.Next(0, 21);
            this.weight += rnd.Next(50, 101);
            if (IsDirty)
            {
                this.health -= 10;
            }
        }
        public void Play(ref int money)
        {
            Random rnd = new Random();
            money -= 5;
            this.health += rnd.Next(0, 21);
            this.mood += rnd.Next(0, 21);
            this.satisfaction -= rnd.Next(0, 21);
            if (this.satisfaction > 100)
            {
                this.satisfaction = 100;
            }
            else if (this.satisfaction < 0)
            {
                this.satisfaction = 0;
            }
        }
        public void Clean(ref int money)
        {
            money -= 5;
            this.IsDirty = false;
        }
        public void GoToDoctor(ref int money)
        {
            money -= 20;
            this.health += 30;
            this.mood -= 20;
            this.IsSick = false;
        }
        public void Grow(ref int money)
        {
            if(this.satisfaction == 0)
            {
                this.weight -= 200;
            }
            else
            {
                this.satisfaction -= 20;
            }
            if(this.Age >= 10)
            {
                this.health -= 10;
            }

            if (this.satisfaction >= 50)
            {
                this.IsDirty = true;
            }
            if (this.health <= 50 && this.mood <= 50)
            {
                Random rnd = new Random();
                int randomNum = rnd.Next(1, 101);
                if (randomNum <= 100 - this.health)
                {
                    this.IsSick = true;
                }
            }
            if (this.health < 10 && this.weight <= 1000)
            {
                Random rnd = new Random();
                int randomNum = rnd.Next(1, 101);
                if (randomNum <= 100 - this.mood)
                {
                    this.IsDead = true;
                }
            }

            if (IsDirty)
            {
                this.health -= 30;
            }
            if (IsSick)
            {
                this.weight -= 150;
                this.mood -= 20;
            }
            this.Age += 1;
        }
    }
}
