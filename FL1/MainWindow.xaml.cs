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

namespace FL1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isWide = false;
        public MainWindow()
        {
            InitializeComponent();
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
                this.Width = 700;
                widerIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowLeft;
                isWide = true;
            }
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
            switch (this.operationsBox.SelectedIndex)
            {
                case 0: this.result.Text = addition(aLeft, aRight, bLeft, bRight); break;
                case 1: this.result.Text = subtraction(aLeft, aRight, bLeft, bRight); break;
                case 2: this.result.Text = multiplication(aLeft, aRight, bLeft, bRight); break;
                case 3: this.result.Text = division(aLeft, aRight, bLeft, bRight); break;
                case 4: this.result.Text = display(aLeft, aRight); break;
                case 5: this.result.Text = inversion(bLeft, bRight); break;
                case 6: this.result.Text = addition(aLeft, aRight, additional, additional); break;
                case 7: this.result.Text = subtraction(bLeft, bRight, additional, additional); break;
                case 8: this.result.Text = multiplication(aLeft, aRight, additional, additional); break;
                case 9: this.result.Text = division(bLeft, bRight, additional, additional); break;
            }
        }

        private void ToAResult_Click(object sender, RoutedEventArgs e)
        {
            string []tmp = result.Text.Split(' ');
            aLeft.Text = tmp[0];
            aRight.Text = tmp[1];
        }

        private void ToBResult_Click(object sender, RoutedEventArgs e)
        {
            string[] tmp = result.Text.Split(' ');
            bLeft.Text = tmp[0];
            bRight.Text = tmp[1];
        }
    }
}
