namespace ThreadingLab;

using System.ComponentModel;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    BackgroundWorker[] bw = new BackgroundWorker[3];
    Entry[] source;
    int sum;
    int numResults;
    private void CalculateButton_Click(object sender, EventArgs e)
    {
        CalculateButton.IsEnabled = false;
        source = new Entry[] { TextBox1, TextBox2, TextBox3 };
        sum = 0;
        numResults = 0;
        for (int i = 0; i < 3; i++)
        {
            int input = int.Parse(source[i].Text);
            bw[i] = new BackgroundWorker();
            bw[i].DoWork += (object sender, DoWorkEventArgs e) =>
            {
                Threading.SlowMath sm = new Threading.SlowMath();
                e.Result = sm.Square((int)e.Argument);
            };
            bw[i].RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                Interlocked.Add(ref sum, (int)e.Result);
                if (Interlocked.Increment(ref numResults) == 3)
                {
                    ResultTextBox.Text = sum.ToString();
                    CalculateButton.IsEnabled = true;
                }
            };
            bw[i].RunWorkerAsync(input);
        }
    }
}

