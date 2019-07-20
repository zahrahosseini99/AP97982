using System.Windows.Controls;
using System.Windows.Media;

namespace P1
{
    public interface ILine
    {
        void DrawLine(Canvas grid, double x1, double y1, double x2, double y2, SolidColorBrush color, float thick);
    }
}