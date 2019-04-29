using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Snake:IAnimal,ICrawlable
    {
        
        public Snake(string name, int age, double health, double speedRate)
        {
            this.Name = name;
            this.Age = age;
            this.Health = health;
            this.SpeedRate = speedRate;
        }

        public string Name { get ; set ; }
        public int Age { get; set; }
        public double Health { get ; set ; }
        public double SpeedRate { get; set ; }

        public string Crawl()
        {
            return this.Name + " is a " + "Snake" + " and is crawling";
        }

        public string EatFood()
        {
            return this.Name + " is a " + "Snake" + " and is eating";
        }

        public string Move(Environment environment)
        {

            if (environment == Environment.Land)
                return Crawl();
            if (environment == Environment.Air)
                return $"{this.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Air)} environment";
            else
                return $"{this.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Watery)} environment";
        }

        public string Reproduction(IAnimal animal)
        {
            return this.Name + " is a " + "Snake" + " and reproductive with " +animal.Name;
        }
    }
}