using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Submarine:ISwimable
    {
        private string _Model;
        public string Model
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
        private double _MaxDepthSupported;
        public double MaxDepthSupported
        {
            get
            {
                return _MaxDepthSupported;
            }
            set
            {
                _MaxDepthSupported = value;
            }
        }

        private double _SpeedRate;
        public double SpeedRate
        {
            get
            {
                return _SpeedRate;
            }
            set
            {
                _SpeedRate = value;
            }
        }

        public Submarine(string model, double maxDepthSupported, double speedRate)
        {
            this._Model = model;
            this._MaxDepthSupported = maxDepthSupported;
            this.SpeedRate = speedRate;
        }

        public string Swim()
        {
            return $"{this.Model} is a {typeof(Submarine).Name} and is swimming in {this.MaxDepthSupported} meter depth";
    }   }
}