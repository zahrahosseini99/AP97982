using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Cartesian : ILine
    {
        public Canvas Draw_canvas;
        public Grid Draw_Grid;
     
        public double centerX;
        public double centerY;
        public double minX;
        public double minY;
        public double maxX;
        public double maxY ;
        public Cartesian(Canvas canvas,Grid grid,double minx, double miny, double maxx, double maxy)
        {
            Draw_canvas = canvas;
            Draw_Grid = grid;
            minX = minx;
            minY=miny;
            maxX = maxx;
            maxY=maxy;

    }
      
        public virtual void DrawLine(Canvas grid, double x1, double y1, double x2, double y2, SolidColorBrush color, float thick)
        {
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = color;
            grid.Children.Add(line);
        }
        public virtual double Unit(Grid c, Canvas d)
        {
            
            double heightY = Draw_Grid.Height;
            double widthX = Draw_Grid.Width;
            
            double difX = maxX - minX;
            double difY = maxY - minY;
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
            if (minX <= 0 && maxX >= 0)
            {
                for(double i = 0; i <=difX; i++)
                {
                    if ((minX + i) == 0)
                    {
                        centerX = i;
                        break;
                    }
                    else
                    {
                        centerX = -1;
                    }  
                }
            }
            else
            {
                centerX = -1;
            }
            
            if (minY<= 0 && maxY >= 0)
            {
                for (double i = minY; i <=difY; i++)
                {
                    if ((minY + i) == 0)
                    {
                        centerY = i;
                        break;
                    }
                    else
                    {
                        centerY = -1;
                    }
                        
                }
            }
            else
            {
                centerY = -1;
            }

            return unit;
        }
        public virtual void DrawCartesian()
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
                if ((Math.Ceiling(i / unit)== centerX))
                    DrawLine(Draw_canvas, x1, y1, x2, y2, Brushes.LightPink, 3);

            }
            double k = maxY;
            for (double j = 0; j <= Draw_canvas.Height; j += unit)
            {
                double y1 = j;
                double y2 = j;
                double x1 = 0;
                double x2 = Draw_canvas.Width;
                Canvas.SetTop(nums, j);
                Canvas.SetLeft(nums, (centerY + 0.4)* unit);
                if (k != 0)
                  nums.Text = $"{k--}";
                if (centerY != -1)
                {

                   
                }
                    
                        
                DrawLine(Draw_canvas, x1, y1, x2, y2, Brushes.LightBlue, 1);
                double d = Math.Floor((maxY - minY) - j / unit);
                if (d== centerY)
                    DrawLine(Draw_canvas, x1, y1, x2, y2, Brushes.LightPink, 3);
               
            }

           
        }
    }
}