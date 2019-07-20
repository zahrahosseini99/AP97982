using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace P1
{
    public class Clock:ILine
    {
        public DateTime datetime;
       public Canvas canvas;
        public Ellipse circle;
        public Clock(DateTime _datetime, Canvas _canvas,Ellipse _circle)
        {
            datetime = _datetime;
            canvas = _canvas;
            circle = _circle;
        }
       public void DrawClock(bool miniLines)
        {

            float clockRadius = 75;
            float clockHeight = 84;
            float secThinkness = 1;
            float minThinkness = 5;
            float hourThinkness = 10;

            float hourLength = clockHeight / 3 / 1.65F;
            float minLength = clockHeight / 2.8F;
            float secLength = 1.85F * clockHeight / 3 / 1.15F;

            float hourThickness = clockHeight / 15;
            float minThickness = clockHeight / 25;
            float secThickness = clockHeight / 50;
            const float PI = 3.141592654F;

            datetime = DateTime.Now;
            int sec = datetime.Second;
            int min = datetime.Minute;
            float hour = datetime.Hour % 12 + (float)datetime.Minute / 60;
            float hourRadian = hour * 360 / 12 * PI / 180;
            float minRadian = min * 360 / 60 * PI / 180;
            float secRadian = sec * 360 / 60 * PI / 180;
            float hourEndPointX = hourLength * (float)Math.Sin(hourRadian);
            float hourEndPointY = hourLength * (float)Math.Cos(hourRadian);
            Point center = new Point(circle.Width / 2F, circle.Height / 2F);
            double Xc = center.X;
            double Yc = center.Y;
            //ساعت
            DrawLine(canvas, Xc, Yc, Xc + hourEndPointX, Yc - hourEndPointY, Brushes.Black, 10*hourThinkness);
            //دقیقه
            if (miniLines)
            {
                for (int i = 0; i < 60; i++)
                {
                  
                    if (i % 5 == 0)
                    {
                        DrawLine(canvas,
                        Xc + (float)(clockRadius / 1.50F * Math.Sin(i * 6 * PI / 180)),
                            Yc - (float)(clockRadius / 1.50F * Math.Cos(i * 6 * PI / 180)),
                        Xc + (float)(clockRadius / 1.65F * Math.Sin(i * 6 * PI / 180)),
                        Yc - (float)(clockRadius / 1.65F * Math.Cos(i * 6 * PI / 180)), Brushes.DarkRed, hourThinkness);

                    }
                    else
                    {
                        DrawLine(canvas,
                         Xc + (float)(clockRadius / 1.50F * Math.Sin(i * 6 * PI / 180)),
                        Yc - (float)(clockRadius / 1.50F * Math.Cos(i * 6 * PI / 180)),
                        Xc + (float)(clockRadius / 1.55F * Math.Sin(i * 6 * PI / 180)),
                       Yc - (float)(clockRadius / 1.55F * Math.Cos(i * 6 * PI / 180)), Brushes.DarkRed, hourThinkness);

                    }
                }
            }
            float minEndPointX = minLength * (float)Math.Sin(minRadian);
            float minEndPointY = minLength * (float)Math.Cos(minRadian);
            DrawLine(canvas, Xc, Yc, Xc + minEndPointX, Yc - minEndPointY, Brushes.Blue, minThinkness);
            //ثانیه
            float secEndPointX = secLength * (float)Math.Sin(secRadian);
            float secEndPointY = secLength * (float)Math.Cos(secRadian);
            DrawLine(canvas, Xc, Yc, Xc + secEndPointX, Yc - secEndPointY, Brushes.Red, secThinkness);
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