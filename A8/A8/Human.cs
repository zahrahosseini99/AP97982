using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    public class Human
    {

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        private DateTime _BirthDate;
        public DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
            }
        }
        private double _Height;
        public double Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }

        public Human(string name, string lastname, DateTime birthDate, double height)
        {
            this._FirstName = name;
            this._LastName = lastname;
            this._BirthDate = birthDate;
            this._Height = height;
        }
        public static Human operator +(Human h1, Human h2)
        {
            Human h3 = new Human("ChildFirstName", "ChildLastName", DateTime.Today, 30);
            return h3;

        }
        public static bool operator ==(Human h1, Human h2)
        {
            return h1.BirthDate == h2.BirthDate;
        }
        public static bool operator !=(Human h1, Human h2)
        {
            return !(h1 == h2);

        }
        public static bool operator >=(Human h1, Human h2)
        {

            return h1.BirthDate.Year <= h2.BirthDate.Year;



        }
        public static bool operator <=(Human h1, Human h2)
        {
            return h1.BirthDate.Year >= h2.BirthDate.Year;

        }
        public static bool operator <(Human h1, Human h2)
        {
            return h1.BirthDate.Year > h2.BirthDate.Year;
        }
        public static bool operator >(Human h1, Human h2)
        {
            return h1.BirthDate.Year < h2.BirthDate.Year;

        }
        public override bool Equals(object human)
        {
            Human h1 = human as Human;
            if (h1 is null)
                return false;
            else
            {
                return h1.FirstName == this.FirstName && h1.LastName == this.LastName &&
                    h1.BirthDate == this.BirthDate && h1.Height == this.Height;
            }

        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^
                BirthDate.GetHashCode() ^ Height.GetHashCode();
        }
    }
}