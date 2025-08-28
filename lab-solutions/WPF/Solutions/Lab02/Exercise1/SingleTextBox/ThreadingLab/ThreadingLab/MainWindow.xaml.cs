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
using System.Threading;

namespace ThreadingLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;
            int input1 = int.Parse(TextBox1.Text);
            Task<int> t1 = new Task<int>(() =>
            {
                Threading.SlowMath sm = new Threading.SlowMath();
                return sm.Square(input1);
            });
            t1.ContinueWith(t =>
            {
                ResultTextBox.Text = t.Result.ToString();
                CalculateButton.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
            t1.Start();
        }

    }
}
