namespace A7
{
    public class Dabir : ICitizen, ITeacher
    {
        private Degree _TopDegree;
        public Degree TopDegree
        {
            get
            {
                return _TopDegree;
            }
            set
            {
                if (TopDegree != Degree.None)
                    _TopDegree = value;
            }
        }
        private string _ImgUrl;
        public string ImgUrl
        {
            get
            {
                return _ImgUrl;
            }
            set
            {
                _ImgUrl = value;
            }
        }
        private string _NationalId;
        public string NationalId
        {
            get
            {
                return _NationalId;
            }
            set
            {
                _NationalId = value;
            }
        }
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
        private int _Under100StudentCount;
        public int Under100StudentCount
        {
            get
            {
                return _Under100StudentCount;
            }
            set
            {
                _Under100StudentCount = value;
            }
        }
        public Dabir(string nationalId, string name, string imgurl, Degree topdegree, int under100StudentCount)
        {

            this._Name = name;
            this._NationalId = nationalId;
            this._ImgUrl = imgurl;
            this._TopDegree = topdegree;
            this._Under100StudentCount = under100StudentCount;

        }

        public string Teach()
        {
            return $"Dabir {this.Name} is teaching";
        }
    }
}