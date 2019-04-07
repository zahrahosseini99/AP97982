using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class City
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                //if (string.IsNullOrEmpty(Name))
                //    throw new Exception("the city name is not valid.");
                //else
                _Name = value;
            }
        }

        public City(string name)
        {
            this._Name= name;
        }
    }
}