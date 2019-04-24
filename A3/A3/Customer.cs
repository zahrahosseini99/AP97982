using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        private string  _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (string.IsNullOrEmpty(Name))
                    throw new Exception("the customer name is not valid.");
                else
                _Name = value;
            }
        }
        private City _City;
        public City City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        private List<Order> _Orders;
        public List<Order> Orders
        {
            get
            {
                return _Orders;
            }
            set
            {
                _Orders = value;
            }
        }

        public Customer(string name, City city, List<Order> orders)
        {
           this._Name = name;
           this._City = city;
           this._Orders = orders;
        }
        //first foreach:check order in order's list
        //second foreach:check product in product's list
        //third foreach :check product[i](i++) in order[j]...(j++)
        public Product MostOrderedProduct()
        {
            var pro = new List<Product>();
            var pro1 = new List<Product>();
            var capacity = 0;
            var max = 0;
            foreach (var or in Orders)
            {
                foreach (var pr in or.Products)
                {
                    foreach (var ord in Orders)
                    {
                        pro.AddRange(or.Products.FindAll(x => x == pr));
                        capacity += pro.Capacity;
                    }
                    if (capacity > max)
                    {
                        pro1 = pro;
                    }
                }

            }
            return pro1.First();

        }

        public List<Order> UndeliveredOrders()
        {
            var result = new List<Order>();
           foreach(var order in Orders)
            {
                if (order.IsDelivered == false)
                {
                    result.Add(order);
                    //تو یه لیستی اسم کالاهایی که تحویل داده نشدن رو ادد کنه
                }
            }
            return result;
        }
    }
}