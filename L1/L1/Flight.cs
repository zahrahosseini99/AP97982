using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Flight
    {

        public string Flightid;
       

        public Airline Airline;
       
        public int Capacity;
       
        public string Source;
         
        public string Destination;
        
        public DateTime FlyDate;


        /// <summary>
        /// set properties and add the object to DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="airline"></param>
        /// <param name="capacity"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="dateTime"></param>
        public Flight(string id, Airline airline, int capacity, string source, string dest,
            DateTime dateTime)
        {
            Flightid = id;
            Airline = airline;
            Capacity = capacity;
            Source = source;
            Destination = dest;
            DB.AddFlight(this);
        }

        public bool IsFull()
        {
            if (Capacity == 0)
                return true;
            else
                return false;
        }
    }
}
