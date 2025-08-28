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
            TextBox[] TextBoxes = { TextBox1, TextBox2, TextBox3 };
            Task<int>[] tasks = new Task<int>[3];
            for (int i = 0; i < TextBoxes.Length; i++)
            {
                int myinput = int.Parse(TextBoxes[i].Text);
                Threading.SlowMath sm = new Threading.SlowMath();
                tasks[i] = Task<int>.Run(() => sm.Square(myinput));
            }
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                int sum = 0;
                foreach (int i in t.Result)
                    sum += i;
                ResultTextBox.Text = sum.ToString();
                CalculateButton.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
