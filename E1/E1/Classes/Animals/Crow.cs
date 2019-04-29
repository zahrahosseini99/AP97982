using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals 
{
    public class Crow:IAnimal,IFlyable
    {
        public Crow(string name, int age, double health, double speedRate)
        {
        }

        public string Name { get; set; }
        public int Age { get ; set; }
        public double Health { get ; set; }
        public double SpeedRate { get ; set ; }

        public string EatFood()
        {
            return $"{this.Name} is a {typeof(Crow).Name} and is eating";
        }

        public string Fly()
        {
            return $"{this.Name} is a {typeof(Crow).Name} and is flying";
        }

        public string Move(Environment environment)
        {
            if (environment == Environment.Air)
                return Fly();
            if (environment == Environment.Watery)
                return $"{this.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment";
            else
                return
                     $"{this.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Land)} environment";
        }

        public string Reproduction(IAnimal animal)
        {
            return $"{this.Name} is a {typeof(Crow).Name} and reproductive with {animal.Name}";
        }
    }
}