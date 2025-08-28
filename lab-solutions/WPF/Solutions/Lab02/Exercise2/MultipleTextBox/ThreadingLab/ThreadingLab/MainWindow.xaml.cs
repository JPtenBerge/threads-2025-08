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
            int sum = 0;
            int[] input = new int[3];
            for (int i = 0; i < 3; i++)
                input[i] = int.Parse(TextBoxes[i].Text);

            Task.Run(() =>
            {
                Parallel.For(0, 3, i =>
                  {
                      Threading.SlowMath sm = new Threading.SlowMath();
                      int result = sm.Square(input[i]);
                      Interlocked.Add(ref sum, result);
                  });
                ResultTextBox.Dispatcher.Invoke((Action<string>)(s =>
                {
                    ResultTextBox.Text = s;
                    CalculateButton.IsEnabled = true;
                }), sum.ToString());
            });
        }
    }
}
