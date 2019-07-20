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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime datetime;
        private DispatcherTimer dispatchTimer;
        private Clock clock;
        private Taylor Taylor;
        private Equations equation;
       private Fractal F;
        private Function func;
        public MainWindow()
        {

            InitializeComponent();

            datetime = DateTime.Now;
            clock = new Clock(datetime, grid, circle);


         
            this.dispatchTimer = new DispatcherTimer();
            this.dispatchTimer.Interval = new TimeSpan(0, 0, 1);
            this.dispatchTimer.Tick += dispatchTimer_Tick;
            this.dispatchTimer.Start();
        }

        private void dispatchTimer_Tick(object sender, EventArgs e)
        {
            grid.Children.Clear();
            clock.DrawClock(true);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            func = new Function(Draw_Canvas, Draw_Grid, double.Parse(minx1.Text),
               double.Parse(miny1.Text), double.Parse(maxx1.Text), double.Parse(maxy1.Text),
               function.Text.ToString());
            func.DrawCartesian();
            this.MouseWheel += MainWindow_MouseWheel;
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;

        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Draw_Canvas.Children.Clear();
            func = new Function(Draw_Canvas, Draw_Grid, double.Parse(minx1.Text) + 10,
           double.Parse(miny1.Text) + 10, double.Parse(maxx1.Text) + 10, double.Parse(maxy1.Text) + 10,
           function.Text.ToString());
            func.DrawCartesian();
        }

        private void MainWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Draw_Canvas.Children.Clear();
                func = new Function(Draw_Canvas, Draw_Grid, double.Parse(minx1.Text) + 1,
               double.Parse(miny1.Text) + 1, double.Parse(maxx1.Text) - 1, double.Parse(maxy1.Text) - 1,
               function.Text.ToString());
                func.DrawCartesian();
            }
            else
            {
                Draw_Canvas.Children.Clear();
                func = new Function(Draw_Canvas, Draw_Grid, double.Parse(minx1.Text) - 1,
               double.Parse(miny1.Text) - 1, double.Parse(maxx1.Text) + 1, double.Parse(maxy1.Text) + 1,
               function.Text.ToString());
                func.DrawCartesian();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            miny1.Clear();
            maxy1.Clear();
            minx1.Clear();
            maxx1.Clear();
            Draw_Canvas.Children.Clear();
            function.Clear();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Clear_E_Click(object sender, RoutedEventArgs e)
        {
            Equation.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
              Equations equation = new Equations(Equation);
        solution.Text = equation.solve();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Taylor = new Taylor(Draw_t, Draw_Taylor,
                double.Parse(Start_Point.Text), double.Parse(Taylor_Number.Text), Taylor_Input.Text);
            Taylor.DrawTaylor();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Start_Point.Clear();
            Taylor_Number.Clear();
            Draw_t.Children.Clear();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

            circle.Visibility=Visibility.Hidden;
            clock.DrawClock(false);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            main.Background = Brushes.Purple;
        }

        private void yellow_Click(object sender, RoutedEventArgs e)
        {
            main.Background = Brushes.Yellow;
        }

        private void black_Click(object sender, RoutedEventArgs e)
        {
            main.Background = Brushes.LightBlue;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Ghaab.Visibility = Visibility.Hidden;
        }
        private void fractal_Click(object sender, RoutedEventArgs e)
        {
            Draw_Fractal.Background = Brushes.White;
            F = new Fractal(Draw_Fractal, int.Parse(frctal_number.Text));
            F.DrawFractal();
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog prnt = new PrintDialog();
            if (prnt.ShowDialog() == true)
            {
                Size pageSize = new Size(prnt.PrintableAreaWidth, prnt.PrintableAreaHeight);
                Draw_Canvas.Measure(pageSize);
                Draw_Canvas.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));

                if (prnt.ShowDialog() == true)
                {
                    prnt.PrintVisual(Draw_Canvas, "Printing Diagram");
                }
            }
            this.Close();
        }
    }
}
