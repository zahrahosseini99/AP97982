using System;
using System.Collections.Generic;
using System.Linq;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
        
    {
        public List<IAnimal> Animals = new List<IAnimal>();
        private List<IAnimal> _Animals = new List<IAnimal>();
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            //foreach(if.)
        }

       // public List<IAnimal> Animals { get; set; }

        public string[] MoveAnimals()
        {
			return null;
        }
    }
}