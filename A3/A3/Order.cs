using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        private List<Product> _Products;
        public List<Product> Products
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products = value;
            }
        }
        private bool _IsDelivered;
        public bool IsDelivered
        {
            get
            {
                return _IsDelivered;
            }
            set
            {
                _IsDelivered = value;
            }
        }

        public Order(List<Product> products, bool isDelivered)
        {
          this._Products = products;
            this._IsDelivered = isDelivered;

        }


        public float CalculateTotalPrice()
        {
            float sum = 0;
            foreach(var product in Products)
            {
                sum += product.Price;
            }
          
            return sum;
        }
    } 
}