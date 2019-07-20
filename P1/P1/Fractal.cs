using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public  class Fractal
    {
        public Rectangle rectangle=new Rectangle();
        public Canvas F_Canvas;
        private int n;
        
        public Fractal(Canvas c,int n)
        {
            F_Canvas = c;
            this.n = n;
        }
       
        public void DrawFractal(double height=200,double wideth=100,int i=0)
        {
            
            Rectangle rectangle = new Rectangle();
            rectangle.Stroke = Brushes.Pink;
            
            rectangle.Height = height;
            rectangle.Width = wideth;

            if (i != n)
            {
                DrawFractal(rectangle.Height / 2, rectangle.Width / 2, i + 1);
            }
            F_Canvas.Children.Add(rectangle);
        }
    }
}