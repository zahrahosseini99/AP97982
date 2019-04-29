using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Airplane : IFlyable
    {
        private string _Model;
       public  string Model
        {
            get
            {
                return _Model;
            }
            set
            {
                _Model = value;
            }
        }
        private double _SpeedRate;
        public double SpeedRate {
            get
            {
                return _SpeedRate;
            }
            set
            {
                _SpeedRate = value;
            }
        }

        public Airplane(double speedRate, string model)
        {
            this._SpeedRate = speedRate;
            
            this._Model = model;
        }

        public string Fly()
        {
            return $"{this.Model} with {this.SpeedRate} speed rate is flying";
        }
    }
}