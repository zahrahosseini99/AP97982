
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace P1
{
    public
        class Equations
    {
        public static TextBox Equation { get; set; }
        public static List<double> RightEquation;
        public static List<double[]> LeftEquation;
        public static List<string> Chars;


        public Equations(TextBox e)
        {
            Equation = e;
        }
        public static void equation(TextBox Equation)
        {
            string text = Equation.Text;
            string[] equations = text.Split(',');
            List<double[]> data = new List<double[]>();
            RightEquation = new List<double>();
            LeftEquation = new List<double[]>();
            Chars = new List<string>();
            foreach (var t in equations)
            {
                string[] e1 = t.Split('=');
                RightEquation.Add(double.Parse(e1[1]));

                LeftEquation.Add(ToData(e1[0]));
                Chars.AddRange(characters(e1[0]));

            }
        }
        public static SquareMatrix<double> Matrixproducer(List<double[]> vectors)
        {
            SquareMatrix<double> factor = new SquareMatrix<double>(vectors.Count);
            foreach (var data in vectors)
            {

                Vector<double> vector = new Vector<double>(data);
                factor.Add(vector);

            }
            return factor;
        }
        public static Matrix<double> Numberproducer(List<double> data)
        {
            Matrix<double> constnumbers = new Matrix<double>(data.Count, 1);
            foreach (var d in data)
            {
                List<double> nums = new List<double>();
                nums.Add(d);
                Vector<double> vector = new Vector<double>(nums.ToArray());
                constnumbers.Add(vector);
                nums.Remove(d);
            }
            return constnumbers;
        }
        public static double[] ToData(string digit)
        {
            digit.ToCharArray();
            string res = null;
            if (char.IsLetter(digit[0]))
                res += "1";
            if (digit[0]=='-')
                res += "-1";
            List<string> result = new List<string>();
            for (int i = 0; i < digit.Length; i++)
            {
                if (digit[i]=='-' && char.IsLetter(digit[i+1]))
                {
                    res += "-1";
                }

                if (!(char.IsLetter(digit[i])) &&(digit[i]!='-' 
                    && (char.IsLetter(digit[i+1]))))
                {
                    res += digit[i];
                }
                if (i != 0)
                {
                    if ((char.IsLetter(digit[i])) && (digit[i - 1] == '+' ))
                    {
                        res += 1;
                    }
                   
                }

                result.Add(res);
                result.Remove(string.Empty);
                res = null;
            }
            List<double> data = new List<double>();
            foreach (var s in result)
            {
                if (s != "+" && s != null)
                    data.Add(double.Parse(s));
            }

            return data.ToArray();
        }
        public static string[] characters(string digit)
        {
            digit.ToCharArray();
            string res = null;


            List<string> result = new List<string>();
            foreach (var c in digit)
            {

                if (char.IsLetter(c))
                {
                    res += c;
                }

                result.Add(res);
                res = null;
            }
            List<string> data = new List<string>();
            foreach (var s in result)
            {
                if (s != null)
                    data.Add(s);
            }

            return data.ToArray();
        }
        public   string solve()
        {
            try {
                equation(Equation);
                Matrix<double> inverse = new Matrix<double>(RightEquation.Count, 1);
                Matrix<double> inverse1 = new Matrix<double>(RightEquation.Count, 1);
                inverse1 = Matrixproducer(LeftEquation).inverse(Matrixproducer(LeftEquation), inverse)
                * Numberproducer(RightEquation);


                string[] j = new string[inverse1.Count()];
                for (int i = 0; i < inverse1.Count(); i++)
                {
                    inverse1[i].ToString().TrimEnd(']').TrimStart('[');
                    j[i] = Chars[i] + "=" + inverse1[i];
                }
                return string.Join(",", j);

            }
            catch
            {
                return "No Solution";
            }
               
          
            

             
        }
    }
}