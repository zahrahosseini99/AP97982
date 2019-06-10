namespace E2
{
    public abstract class Person
    {

        private string _Name;
        public virtual string Name
        {
             get
            {
                if (IsFemale)
                    return "خانم" + this._Name;
                else
                    return "آقای " + this._Name;
            }
        }
        public bool IsFemale;
       
        public Person(string name,bool isfemale)
        {
            this._Name = name;
            IsFemale = isfemale;
        }
      
        private int _LunchRate;
        public abstract int LunchRate
        {
            get;
        }
    }

    public class Student : Person
    {
        public Student(string name, bool isfemale) : base(name, isfemale)
        {
        }

        public override int LunchRate => 2000;
    }

    public class Employee : Person
    {
        public Employee(string name, bool isfemale) : base(name, isfemale)
        {
        }
      public virtual int CalculateSalary(int hours)
        {
            return 5000 * hours;
        }
        public override int LunchRate => 5000;
    }

    public class Teacher : Employee
    {
        public override string Name
        {
            get
            {
                if (IsFemale)
                    return "خانم" + this.Name;
                else
                {

                }
                    return "استاد محمد رضا شجریان";
            }
        }
        public Teacher(string _name, bool isfemale) : base(_name, isfemale)
        {
        }
         public override int CalculateSalary(int hours)
        {
            return 20000 * hours;
        }
        public override int LunchRate => 10000;
    }
}