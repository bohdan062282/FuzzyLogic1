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
        private string addition()
        {
            return (float.Parse(aLeft.Text) + float.Parse(bLeft.Text)).ToString() + ' ' + (float.Parse(aRight.Text) + float.Parse(bRight.Text)).ToString();
        }
        private string subtraction()
        {
            return (float.Parse(aLeft.Text) - float.Parse(bRight.Text)).ToString() + ' ' + (float.Parse(aRight.Text) - float.Parse(bLeft.Text)).ToString();
        }
        private string multiplication()
        {
            float[] comb = new float[4];
            
            comb[0] = float.Parse(aLeft.Text) * float.Parse(bLeft.Text);
            comb[1] = float.Parse(aLeft.Text) * float.Parse(bRight.Text);
            comb[2] = float.Parse(aRight.Text) * float.Parse(bLeft.Text);
            comb[3] = float.Parse(aRight.Text) * float.Parse(bRight.Text);

            return comb.Min().ToString() + ' ' + comb.Max().ToString();
        }
        private string division()
        {
            float[] comb = new float[4];

            comb[0] = float.Parse(aLeft.Text) / float.Parse(bLeft.Text);
            comb[1] = float.Parse(aLeft.Text) / float.Parse(bRight.Text);
            comb[2] = float.Parse(aRight.Text) / float.Parse(bLeft.Text);
            comb[3] = float.Parse(aRight.Text) / float.Parse(bRight.Text);

            return comb.Min().ToString() + ' ' + comb.Max().ToString();
        }
        private string displayA()
        {
            return (float.Parse(aRight.Text)*(-1)).ToString() + ' ' + (float.Parse(aLeft.Text) * (-1)).ToString();
        }
        private string inversionB()
        {
            return (1 / float.Parse(bRight.Text)).ToString() + ' ' + (1 / float.Parse(bLeft.Text)).ToString();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            switch (this.operationsBox.SelectedIndex)
            {
                case 0: this.result.Text = addition(); break;
                case 1: this.result.Text = subtraction(); break;
                case 2: this.result.Text = multiplication(); break;
                case 3: this.result.Text = division(); break;
                case 4: this.result.Text = displayA(); break;
                case 5: this.result.Text = inversionB(); break;
            }
        }
    }
}
