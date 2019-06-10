
namespace E2
{
    public class MyString
    {
        private string _input;
        public string input
        {
            get
            {
                return _input;
            }
            set
            {
                value = _input;
            }
        }
        public MyString(string s)
        {
            input = s;

        }
        //public static operator System.String(MyString s1)
        //{

        //}
    }
}