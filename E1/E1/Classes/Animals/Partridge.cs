﻿using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Partridge:IWalkable,IFlyable,IAnimal
    {
        public Partridge(string name, int age, double speedRate, double health)
        {
            this.Name = name;
            this.Age = age;
            this.SpeedRate = speedRate;
            this.Health = health;
            
        }

        public double SpeedRate { get; set; }
        public string Name { get ; set; }
        public int Age { get; set; }
        public double Health { get; set; }

        public string EatFood()
        {
           return $"{this.Name} is a {typeof(Partridge).Name} and is eating";
        }

        public string Fly()
        {
            return $"{this.Name} is a {typeof(Partridge).Name} and is flying";
        }

        public string Move(Environment environment)
        {
            if (Environment.Air == environment)
                return Fly();
            if (environment == Environment.Land)
                return Walk();
            else
                return $"{this.Name} is a {typeof(Partridge).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Watery)} environment";
        }

        public string Reproduction(IAnimal animal)
        {
            return $"{this.Name} is a {typeof(Partridge).Name} and reproductive with {animal.Name}";
        }
            public string Walk()
        {
            return $"{this.Name} is a {typeof(Partridge).Name} and is walking";
        }
    }
}