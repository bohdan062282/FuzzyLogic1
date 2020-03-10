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
using System.Windows.Shapes;

namespace FL1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int counter;
        private int i;
        private float left;
        private float right;
        private TextBlock rez;
        public Window1(int counter, TextBlock rez)
        {
            InitializeComponent();
            if (counter < 1)
            {
                this.DialogResult = false;
            }
            this.counter = counter;
            this.rez = rez;
            i = 0;
            left = 1;
            right = 1;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            checkInterv(aLeft, aRight);
            if(i < counter)
            {
                multiplication();
                aLeft.Text = null;
                aRight.Text = null;
                i++;
            }
            if(i == counter)
            {
                rez.Text = left.ToString() + ' ' + right.ToString();
                try
                {
                    this.DialogResult = true;
                }
                catch(InvalidOperationException ex)
                {
                    ;
                }
            }
        }

        private void multiplication()
        {
            float[] comb = new float[4];

            comb[0] = left * float.Parse(aLeft.Text);
            comb[1] = left * float.Parse(aRight.Text);
            comb[2] = right * float.Parse(aLeft.Text);
            comb[3] = right * float.Parse(aRight.Text);

            left = comb.Min();
            right = comb.Max();
        }
        private void checkInterv(TextBox left, TextBox right)
        {
            if (float.Parse(left.Text) < float.Parse(right.Text)) return;
            else this.DialogResult = false;
        }
    }
}
