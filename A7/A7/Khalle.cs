namespace A7
{
    public class Khalle : ICitizen, ITeacher
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
                if(TopDegree!=Degree.None)
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
        public Khalle(string nationalId,string name,string imgurl,Degree topdegree)
        {

            this._Name = name;
            this._NationalId = nationalId;
            this._ImgUrl = imgurl;
            this._TopDegree = topdegree;

        }
     public string Teach()
        {
            return ("Khalle" + " " + this.Name + " " + "is" + " " + "teaching");
        }
    }
}