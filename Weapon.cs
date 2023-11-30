using System;

namespace WPfF_Turn_based_Game
{
    public class Weapon
    {
        public string Type { get; private set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }


        //constructors
        public Weapon(string name, int damage, int defence, int speed)
        {
            Type = name;
            Damage = damage;
            Defence = defence;
            Speed = speed;
        }

        // Methods 

        public int Attack()
        {
            Random roll = new Random();
            int hitDamage = roll.Next(1, Damage);

            return hitDamage;

        }
        public int Defend()
        {
            Random roll = new Random();
            int hitDefend = roll.Next(0, Defence);
            return hitDefend;
        }

        // static methods to create individual weapons

        public static Weapon CreateSword()
        {
            Random roll = new Random();

            string type = "Sword";
            int damage = roll.Next(1, 18);
            int defence = roll.Next(1, 10);
            int speed = roll.Next(1, 15);

            return new Weapon(type, damage, defence, speed);

        }
        public static Weapon CreateHammer()
        {
            Random roll = new Random();

            string type = "Hammer";
            int damage = roll.Next(1, 25);
            int defence = roll.Next(1, 8);
            int speed = roll.Next(1, 10);

            return new Weapon(type, damage, defence, speed);

        }
        public static Weapon CreateDagger()
        {
            Random roll = new Random();

            string type = "Dagger";
            int damage = roll.Next(1, 14);
            int defence = roll.Next(1, 7);
            int speed = roll.Next(1, 25);

            return new Weapon(type, damage, defence, speed);
        }
        public static Weapon CreateAxe()
        {
            Random roll = new Random();

            string type = "Axe";
            int damage = roll.Next(1, 14);
            int defence = roll.Next(1, 7);
            int speed = roll.Next(1, 25);

            return new Weapon(type, damage, defence, speed);
        }
    }
}
