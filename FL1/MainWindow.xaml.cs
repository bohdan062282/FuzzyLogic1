using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using OxyPlot;

namespace FL1
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.Title = "Graph";
            setDefaultPoints();
        }
        public void setPointsX(float aLX, float aRX, float bLX, float bRX, float cLX, float cRX)
        {
            Points1 = new List<DataPoint> { new DataPoint(aLX, 1), new DataPoint(aRX, 1) };
            Points2 = new List<DataPoint> { new DataPoint(bLX, 2), new DataPoint(bRX, 2) };
            Points3 = new List<DataPoint> { new DataPoint(cLX, 3), new DataPoint(cRX, 3) };
        }
        public void setDefaultPoints()
        {
            setPointsX(0, 0, 0, 0, 0, 0);
        }
        public void setGraphs(TextBox fstLeft, TextBox fstRight, TextBox sndLeft, TextBox sndRight, TextBlock res)
        {
            string[] tmp = res.Text.Split(' ');
            setPointsX(float.Parse(fstLeft.Text), float.Parse(fstRight.Text), float.Parse(sndLeft.Text), float.Parse(sndRight.Text), float.Parse(tmp[0]), float.Parse(tmp[1]));
        }
        public void setGraphs(TextBox fstLeft, TextBox fstRight, TextBlock res)
        {
            string[] tmp = res.Text.Split(' ');
            setPointsX(float.Parse(fstLeft.Text), float.Parse(fstRight.Text), 0, 0, float.Parse(tmp[0]), float.Parse(tmp[1]));
        }

        public string Title { get; private set; }

        public IList<DataPoint> Points1 { get; private set; }
        public IList<DataPoint> Points2 { get; private set; }
        public IList<DataPoint> Points3 { get; private set; }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class InvalidResultException : Exception {}
    public partial class MainWindow : Window
    {
        private bool isWide = false;
        public MainWindow()
        {
            InitializeComponent();
            viewModel.setPointsX(0, 1, 3, 4, 5, 6);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void powerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addGrid_Click(object sender, RoutedEventArgs e)
        {
            if (isWide == true)
            {
                this.Width = 360;
                widerIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowRight;
                isWide = false;
            }
            else
            {
                this.Width = 720;
                widerIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowLeft;
                isWide = true;
            }
        }
        private void checkInterv(TextBox left, TextBox right)
        {
            if (float.Parse(left.Text) < float.Parse(right.Text)) return;
            else throw new Exception();
        }
        private string addition(TextBox fstLeft, TextBox fstRight, TextBox sndLeft, TextBox sndRight)
        {
            return (float.Parse(fstLeft.Text) + float.Parse(sndLeft.Text)).ToString() + ' ' + (float.Parse(fstRight.Text) + float.Parse(sndRight.Text)).ToString();
        }
        private string subtraction(TextBox fstLeft, TextBox fstRight, TextBox sndLeft, TextBox sndRight)
        {
            return (float.Parse(fstLeft.Text) - float.Parse(sndRight.Text)).ToString() + ' ' + (float.Parse(fstRight.Text) - float.Parse(sndLeft.Text)).ToString();
        }
        private string multiplication(TextBox fstLeft, TextBox fstRight, TextBox sndLeft, TextBox sndRight)
        {
            float[] comb = new float[4];
            
            comb[0] = float.Parse(fstLeft.Text) * float.Parse(sndLeft.Text);
            comb[1] = float.Parse(fstLeft.Text) * float.Parse(sndRight.Text);
            comb[2] = float.Parse(fstRight.Text) * float.Parse(sndLeft.Text);
            comb[3] = float.Parse(fstRight.Text) * float.Parse(sndRight.Text);

            return comb.Min().ToString() + ' ' + comb.Max().ToString();
        }
        private void multMultiplication()
        {
            //int count = int.Parse(additional.Text);
            //for(int i = 0; i < count; i++)
            //{

            //    Window1 w = new Window1();
            //    //while (w.IsActive) ;
            //    this.result.Text = "sasi";
            //}
        }
        private string division(TextBox fstLeft, TextBox fstRight, TextBox sndLeft, TextBox sndRight)
        {
            float[] comb = new float[4];

            comb[0] = float.Parse(fstLeft.Text) / float.Parse(sndLeft.Text);
            comb[1] = float.Parse(fstLeft.Text) / float.Parse(sndRight.Text);
            comb[2] = float.Parse(fstRight.Text) / float.Parse(sndLeft.Text);
            comb[3] = float.Parse(fstRight.Text) / float.Parse(sndRight.Text);

            return comb.Min().ToString() + ' ' + comb.Max().ToString();
        }
        private string display(TextBox left, TextBox right)
        {
            return (float.Parse(right.Text)*(-1)).ToString() + ' ' + (float.Parse(left.Text) * (-1)).ToString();
        }
        private string inversion(TextBox left, TextBox right)
        {
            return (1 / float.Parse(right.Text)).ToString() + ' ' + (1 / float.Parse(left.Text)).ToString();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {           
            viewModel.setPointsX(200, 56, 3, 4, 58, 7);
            model.InvalidatePlot(true);
            try
            {
                switch (this.operationsBox.SelectedIndex)
                {
                    case 0: checkInterv(aLeft, aRight); checkInterv(bLeft, bRight); this.result.Text = addition(aLeft, aRight, bLeft, bRight); viewModel.setGraphs(aLeft, aRight, bLeft, bRight, result); viewModel.setPointsX(0, 1, 3, 4, 5, 6); break;
                    case 1: checkInterv(aLeft, aRight); checkInterv(bLeft, bRight); this.result.Text = subtraction(aLeft, aRight, bLeft, bRight); viewModel.setGraphs(aLeft, aRight, bLeft, bRight, result); break;
                    case 2: checkInterv(aLeft, aRight); checkInterv(bLeft, bRight); this.result.Text = multiplication(aLeft, aRight, bLeft, bRight); viewModel.setGraphs(aLeft, aRight, bLeft, bRight, result); break;
                    case 3: checkInterv(aLeft, aRight); checkInterv(bLeft, bRight); this.result.Text = division(aLeft, aRight, bLeft, bRight); viewModel.setGraphs(aLeft, aRight, bLeft, bRight, result); break;
                    case 4: checkInterv(aLeft, aRight); this.result.Text = display(aLeft, aRight); viewModel.setGraphs(aLeft, aRight, result); break;
                    case 5: checkInterv(bLeft, bRight); this.result.Text = inversion(bLeft, bRight); viewModel.setGraphs(aLeft, aRight, result); break;
                    case 6: checkInterv(aLeft, aRight); this.result.Text = addition(aLeft, aRight, additional, additional); viewModel.setGraphs(aLeft, aRight, additional, additional, result); break;
                    case 7: checkInterv(bLeft, bRight); this.result.Text = subtraction(bLeft, bRight, additional, additional); viewModel.setGraphs(bLeft, bRight, additional, additional, result); break;
                    case 8: checkInterv(aLeft, aRight); this.result.Text = multiplication(aLeft, aRight, additional, additional); viewModel.setGraphs(aLeft, aRight, additional, additional, result); break;
                    case 9: checkInterv(bLeft, bRight); this.result.Text = division(bLeft, bRight, additional, additional); viewModel.setGraphs(bLeft, bRight, additional, additional, result); break;
                    //case 10: multMultiplication(); break;
                    default: throw new Exception();
                }
                string[] tmp = result.Text.Split(' ');
                if (float.Parse(tmp[0]) >= float.Parse(tmp[1])) throw new InvalidResultException();
            }
            catch (InvalidResultException)
            {
                this.result.Text = null;
                MessageBox.Show("Невірні параметри!", "Помилка!");
            }
            catch
            {
                MessageBox.Show("Невірні параметри!", "Помилка!");
            }

        }

        private void ToAResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] tmp = result.Text.Split(' ');
                aLeft.Text = tmp[0];
                aRight.Text = tmp[1];
            }
            catch
            {
                MessageBox.Show("Невірні параметри!", "Помилка!");
            }
        }

        private void ToBResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] tmp = result.Text.Split(' ');
                bLeft.Text = tmp[0];
                bRight.Text = tmp[1];
            }         
            catch
            {
                MessageBox.Show("Невірні параметри!", "Помилка!");
            }
        }

        private void OperationsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(operationsBox.SelectedIndex == 6 || operationsBox.SelectedIndex == 7 || operationsBox.SelectedIndex == 8 || operationsBox.SelectedIndex == 9 || operationsBox.SelectedIndex == 10)
            {
                this.Height = 540;
            }
            else
            {
                this.Height = 450;
            }
        }

    }
}
