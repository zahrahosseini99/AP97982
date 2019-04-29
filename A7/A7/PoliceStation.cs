using System;
using System.Collections.Generic;

namespace A7
{
    public static class PoliceStation
    {
        private static string _BlackList;
        public static string BlackList
        {
            get
            {
                return _BlackList;
            }
            set
            {
                _BlackList = value;
            }
        }
        public static bool BackgroundCheck(ICitizen citizen)
        {
            if (BlackList == citizen.Name)
                return true;
            return false;
        }
    }
}