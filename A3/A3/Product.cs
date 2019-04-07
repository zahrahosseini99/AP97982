using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Product
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
                //    throw new Exception("the product name is not valid.");
                _Name = value;
            }
        }
        private float _Price;
        public float Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if (Price > 0)
                    _Price = value;
            }
        }

        public Product(string name, float price)
        {
           this._Name = name;
           this._Price = price;
        }
    }
}