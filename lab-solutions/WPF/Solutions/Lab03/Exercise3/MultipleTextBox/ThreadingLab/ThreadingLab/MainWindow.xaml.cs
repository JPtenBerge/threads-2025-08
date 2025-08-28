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

        public async IAsyncEnumerable<int>  GetSquaresAsync()
        {
            TextBox[] textBoxes = { TextBox1, TextBox2, TextBox3 };
            Task<int>[] tasks = new Task<int>[3];
            for (int i = 0; i < 3; i++)
            {
                Threading.SlowMath sm = new Threading.SlowMath();
                int input = int.Parse(textBoxes[i].Text);
                tasks[i] = sm.SquareAsync(input);
            }
            for (int i = 0; i < 3; i++)
            {
                int result = await tasks[i];
                yield return result;
            }

        }

        //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private async Task CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;
            int sum = 0;
            await foreach (int res in GetSquaresAsync())
                sum += res;
            ResultTextBox.Text = sum.ToString();
            CalculateButton.IsEnabled = true;
        }
    }
}
