using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Frog :IWalkable,ISwimable,IAnimal
    {
        public Frog(string name, int age, double health, double speedRate)
        {
            this.Name = name;
            this.Age = age;
            this.Health = health;
            this.SpeedRate = speedRate;
        }

        public double SpeedRate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }

        public string EatFood()
        {
            return $"{this.Name} is a {typeof(Frog).Name} and is eating";
        }

        public string Move(Environment environment)
        {
            if (Environment.Watery == environment)
                return Swim();
            if (environment == Environment.Land)
                return Walk();
            else
               return $"{this.Name} is a {typeof(Frog).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Air)} environment";
        }

        public string Reproduction(IAnimal animal)
        {
           return $"{this.Name} is a {typeof(Frog).Name} and reproductive with {animal.Name}";
        }

        public string Swim()
        {
            return $"{this.Name} is a {typeof(Frog).Name} and is swimming";
        }

        public string Walk()
        {
            return $"{this.Name} is a {typeof(Frog).Name} and is walking";
        }
    }
}