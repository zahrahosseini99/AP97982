using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Function:Cartesian,ILine
    {
        public static string Input
        { get; set; }

        public Function(Canvas canvas, Grid grid, double minx,
            double miny, double maxx, double maxy,string input)
           : base(canvas, grid,  minx,  miny,maxx,  maxy)
        {
            Input = input;
        }
        public  static Func<double, double> Parser(string func)
        {
            if (func.Contains("sinh"))
            {
                return x => Math.Cosh(x);
            }
            if (func.Contains("cosh"))
            {
                return x => Math.Cosh(x);
            }
            if (func.Contains("e^x"))
            {
                return x => Math.Pow(Math.E, x);
            }
            if (func.Contains("log"))
            {
                return x => Math.Log(x);
            }
            if (func.Contains("sin"))
            {
                return x => Math.Sin(x);
            }
            if (func.Contains("cos"))
            {
                return x => Math.Cos(x);
            }
            

            //plus
            if (func.Contains("+"))
            {
                int index = func.IndexOf('+');
                return Plus(index, func);
            }
            //sub
            if (func.Contains("-"))
            {
                int index = func.IndexOf('-');
                return Subtract(index, func);
            }
            //prod
            for (int j = 0; j < func.Length; j++)
            {
                if (func.Contains("*"))
                {
                    int index = func.IndexOf('*');
                    return x => Parser(func.Substring(0, index))(x) * Parser(func.Substring(index + 1))(x);
                }
                if (j != func.Length - 1 )
                {
                    if (char.IsDigit(func[j]) && char.IsLetter(func[j+1]))
                    {
                        return x => double.Parse(func.Substring(0, j+1)) * Parser(func.Substring(j + 1))(x);
                    }
                }
              
               
            }
            //power
            if (func.Contains("^"))
            {
                int i = func.IndexOf('^');
                return x => Math.Pow(x, double.Parse(func[i+1].ToString()));
            }
            for(int i = 0; i < func.Length; i++)
            {
                if (char.IsDigit(func[i]))
                    return x => double.Parse(func[i].ToString());
                else if (char.IsLetter(func[i]))
                    return x => x;
            }
           
            return x => x;

        }

        public  static Func<double, double> Subtract(int index, string function)
        {
            return x =>
                       Parser(function.Substring(0, index))(x) - Parser(function.Substring(index + 1))(x);
        }

      
        public  static Func<double, double> Plus(int index, string function)
        {
            return x =>
                       Parser(function.Substring(0, index))(x) + Parser(function.Substring(index + 1))(x);

        }

        public override void DrawLine(Canvas grid, double x1, double y1, double x2, double y2, SolidColorBrush color, float thick)
        {
            base.DrawLine( grid,  x1,  y1,  x2,  y2,  color,  thick);
        }
       
        public override void DrawCartesian()
        {
            double unit = Unit(Draw_Grid, Draw_canvas);


            var nums = new TextBlock();
            for (double i = 0; i <= Draw_canvas.Width; i += unit)
            {
                double y1 = 0;
                double y2 = Draw_canvas.Height;
                double x1 = i;
                double x2 = i;



                DrawLine(Draw_canvas, x1, y1, x2, y2, Brushes.LightBlue, 1);
                if ((Math.Ceiling(i / unit) == centerX))
                    DrawLine(Draw_canvas, x1, y1, x2, y2, Brushes.Purple, 3);

            }
            double k = maxY;
            for (double j = 0; j <= Draw_canvas.Height; j += unit)
            {
                double y1 = j;
                double y2 = j;
                double x1 = 0;
                double x2 = Draw_canvas.Width;
                Canvas.SetTop(nums, j);
                Canvas.SetLeft(nums, (centerY + 0.4) * unit);
                if (k != 0)
                    nums.Text = $"{k--}";
                if (centerY != -1)
                {


                }


                DrawLine(Draw_canvas, x1, y1, x2, y2, Brushes.LightBlue, 1);
                double d = Math.Floor((maxY - minY) - j / unit);
                if (d == centerY)
                    DrawLine(Draw_canvas, x1, y1, x2, y2, Brushes.DarkBlue, 3);

            }
          
            double lastX = 0;
            double lastY = (Parser(Input)(minX )) * unit;
             for (double i = minX; i <= maxX; i += 0.01)
                {

                  double  y = (Parser(Input)(i ))*unit;
                if(y/unit<=maxY && y / unit >= minY)
                {
                    DrawLine(Draw_canvas
                       , lastX * unit
                       , lastY
                       , (i - minX) * unit
                       , -y + maxY * unit
                       , Brushes.Yellow, 4);
                }
                   


                lastY = -y+maxY*unit;
                    lastX = i-minX;

                }
            
        }
    }
}