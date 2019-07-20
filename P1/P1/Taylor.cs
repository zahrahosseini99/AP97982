using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Taylor :
        ILine
    {
        public static double Number { get; set; }
        public static Canvas Draw_t { get; set; }
        public static Grid Draw_Taylor { get; set; }
        public static double StartInput { get; set; }
        public static string Input { get; set; }
       private static double MinX;
       private const double MinY=-2;
       private static  double MaxX;
       private const double MaxY=2;
       private double Y_Taylor;
       private double Y_Sin;
       private static double CenterX;
       private static double CenterY;
        
        //constructor
        public Taylor(Canvas Draw_Canvas, Grid Draw_Grid, double startInput, double n,string input)
        {
            Number = n;
            Draw_t = Draw_Canvas;
            Draw_Taylor = Draw_Grid;
            StartInput = startInput;
            Input = input;
        }
        //calculat taylor
        public static double ETaylor(double x, double n)

        {

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += (  (double)Math.Pow(x,i)) / (double)fact(i);
            }
            return sum;
        }
        public static double coshTaylor(double x, double n)

        {

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += ((double)Math.Pow(x, 2*i)) / (double)fact(2*i);
            }
            return sum;
        }
        public static double sinhTaylor(double x, double n)

        {

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += ((double)Math.Pow(x, 2 * i+1)) / (double)fact(2 * i+1);
            }
            return sum;
        }
        public static  double CosTaylor(double x, double n)

        {

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += (((double)Math.Pow(-1, i)) * (double)Math.Pow(x, 2 * i )) / (double)fact(2 * i);
            }
            return sum;
        }
        public static double SinTaylor(double x, double n)

        {

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += (((double)Math.Pow(-1, i)) * (double)Math.Pow(x, 2 * i + 1)) / (double)fact(2 * i + 1);
            }
            return sum;
        }
        public static double fact(double n)
        {
            if (n <= 1)
                return 1;
            else
                return n * fact(n - 1);
        }
        public static double SelectTaylor(double x, double n)
        {
            if (Input.Contains("sin"))
                return SinTaylor(x, n);
            if (Input.Contains("cos"))
                return SinTaylor(x, n);
            if (Input.Contains("e"))
                return ETaylor(x, n);
            else
                return 0;
        }
        //find x bounding
        public  static void FindX(double startinput, double n)
        {
            double yTaylor = 0;
            double ySin = 0;
            double untilX = 0;
            double minuntilX = 0;
            for (double i = startinput; i <= untilX; i += 0.1)
            {
                yTaylor = SelectTaylor(i, 4);
                ySin = Math.Sin(i);
                if (Math.Abs(yTaylor - ySin) / 2 > 0.01)
                {
                    untilX =  i;
                    break;
                }
                else
                    untilX += 0.1;
            }
            for (double i = startinput; i >= minuntilX; i -= 0.1)
            {
                yTaylor = SelectTaylor(i, 4);
                ySin = Math.Sin(i);
                if (Math.Abs(yTaylor - ySin) / 2 > 0.01)
                {
                    minuntilX = i;
                    break;
                }
                else
                    minuntilX -= 0.1;
            }
            MaxX =Math.Ceiling( 2 * untilX)+startinput;
            MinX = Math.Floor( 2*minuntilX)-startinput;
        }
        //find unit of cartesian
       
        public static double Unit(Grid c, Canvas d)
        {
            FindX(StartInput, Number);
            double heightY = Draw_Taylor.Height;
            double widthX = Draw_Taylor.Width;
           
            double difX = MaxX-MinX;
            double difY = MaxY - MinY;
            double unit;
            if (difX < difY)
            {
                if (heightY < widthX)
                    unit = heightY / difY;
                else
                    unit = widthX / difY;
            }
            else
            {
                if (heightY < widthX)
                    unit = heightY / difX;
                else
                    unit = widthX / difX;

            }
            d.Height = unit * difY;
            d.Width = unit * difX;
            if (MinX <= 0 && MaxX >= 0)
            {
                for (double i = 0; i <= difX; i++)
                {
                    if ( (MinX + i) == 0)
                    {
                        CenterX = i;
                        break;
                    }
                    else
                    {
                        CenterX = -1;
                    }
                }
            }
            else
            {
                CenterX = -1;
            }


            for (double i = MinY; i <= difY; i++)
            {
                if ((MinY + i) == 0)
                {
                    CenterY = i;
                    break;
                }
                else
                {
                    CenterY = -1;
                }

            }


            return unit;
        }
        //Draw cartesain and taylor
        public void DrawTaylor()
        {



            double unit = Unit(Draw_Taylor, Draw_t);



            for (double i = 0; i <= Draw_t.Width; i += unit)
            {
                double y1 = 0;
                double y2 = Draw_t.Height;
                double x1 = i;
                double x2 = i;



                DrawLine(Draw_t, x1, y1, x2, y2, Brushes.LightBlue, 1);
                if (((i / unit) == CenterX))
                    DrawLine(Draw_t, x1, y1, x2, y2, Brushes.DarkBlue, 3);

            }

            for (double j = 0; j <= Draw_t.Height; j += unit)
            {
                double y1 = j;
                double y2 = j;
                double x1 = 0;
                double x2 = Draw_t.Width;



                DrawLine(Draw_t, x1, y1, x2, y2, Brushes.LightBlue, 1);
                double d = Math.Floor((MaxY-MinY) - j / unit);
                if (d == CenterY)
                    DrawLine(Draw_t, x1, y1, x2, y2, Brushes.DarkBlue, 3);

            }

            //find which taylor

            if (Input.Contains("sin"))
            {
                double lastY = SinTaylor(MinX, Number) * unit;
                double lastX = 0;
                for (double i = MinX; i <= MaxX; i += 0.01)
                {
                    Y_Taylor = SinTaylor(i, Number) * unit;
                    if (Y_Taylor / unit < MaxY && Y_Taylor / unit > MinY)
                    {
                        DrawLine(Draw_t
                           , lastX * unit
                           , lastY
                           , (i - MinX) * unit
                           , -Y_Taylor + 2 * unit
                           , Brushes.DarkRed, 4);
                    }
                    lastX = i - MinX;
                    lastY = -Y_Taylor + 2 * unit;

                }
                Function sin = new Function(Draw_t, Draw_Taylor, MinX, -2, MaxX, 2, "sinx");
                sin.DrawCartesian();
            }
            if (Input.Contains("cos"))
            {
                double lastY = CosTaylor(MinX, Number) * unit;
                double lastX = 0;
                for (double i = MinX; i <= MaxX; i += 0.01)
                {
                    Y_Taylor = CosTaylor(i, Number) * unit;
                    if (Y_Taylor / unit < MaxY && Y_Taylor / unit > MinY)
                    {
                        DrawLine(Draw_t
                           , lastX * unit
                           , lastY
                           , (i - MinX) * unit
                           , -Y_Taylor + 2 * unit
                           , Brushes.DarkRed, 4);
                    }
                    lastX = i - MinX;
                    lastY = -Y_Taylor + 2 * unit;

                }
                Function cos = new Function(Draw_t, Draw_Taylor, MinX, -2, MaxX, 2, "cosx");
                cos.DrawCartesian();
            }
            if (Input.Contains("e"))
            {
                double lastY = ETaylor(MinX, Number) * unit;
                double lastX = 0;
                for (double i = MinX; i <= MaxX; i += 0.01)
                {
                    Y_Taylor = ETaylor(i, Number) * unit;
                    if (Y_Taylor / unit < MaxY && Y_Taylor / unit > MinY)
                    {
                        DrawLine(Draw_t
                           , lastX * unit
                           , lastY
                           , (i - MinX) * unit
                           , -Y_Taylor + 2 * unit
                           , Brushes.DarkRed, 4);
                    }
                    lastX = i - MinX;
                    lastY = -Y_Taylor + 2 * unit;

                }
                Function neper = new Function(Draw_t, Draw_Taylor, MinX, -2, MaxX, 2, "e^x");
                neper.DrawCartesian();
            }





        }

        public void DrawLine(Canvas grid, double x1, double y1, double x2, double y2, SolidColorBrush color, float thick)
        {
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = color;
            grid.Children.Add(line);
        }
    }


}
