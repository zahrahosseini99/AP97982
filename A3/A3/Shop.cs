using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Shop
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
                
                    _Name = value;
            }
        }
        private List<Customer> _Customers;
        public List<Customer> Customers
        {
            get
            {
                return _Customers;
            }
            set
            {
                _Customers = value;
            }
        }

        public Shop(string name, List<Customer> customers)
        {
            this._Name = name;
            this._Customers = customers;
        }


        public List<City> CitiesCustomersAreFrom()
        {
            var result = new List<City>();
            foreach (var cstmr in Customers)
            {
                result.Add(cstmr.City);
            }
            
            return result.Distinct().ToList();
        }

        public List<Customer> CustomersFromCity(City city)
        {
            var res = new List<Customer>();
            foreach (var customer in Customers)
                if (customer.City == city)
                    res.Add(customer);
            return res;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            var res = new List<Customer>();
            var res1 = new List<Customer>();
            res.Add(Customers.OrderByDescending(x => x.Orders.Count).First());
            int[] size = new int[Customers.Count];
            for (int i = 0; i < Customers.Count; i++)
            {
                foreach (var person in Customers)
                {
                    foreach (var or in person.Orders)
                    {
                        size[i] += or.Products.Count;
                    }
                    if (size[i] == res[0].Orders.Count)
                        res.Add(person);
                }
                

            }



            return res;
        }
    }
}