using System;
using System.Collections.Generic;

namespace A7
{
    public class PoliceStation:ICitizen
    {

        public static List<ICitizen> BlackList
        {
            get;set;
        }
       
       public string NationalId { get; set; }
        public string Name { get ; set; }

       
        public static bool BackgroundCheck(ICitizen citizen)
        {
            if (BlackList.Contains(citizen))
                return true;
            return false;
        }
    }
}