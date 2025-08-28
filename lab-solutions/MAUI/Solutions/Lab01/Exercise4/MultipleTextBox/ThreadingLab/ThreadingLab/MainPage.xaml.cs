namespace ThreadingLab;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    volatile int sum;
    int numResults;
    Entry[] source;
    private void CalculateButton_Click(object sender, EventArgs e)
    {
        CalculateButton.IsEnabled = false;
        sum = 0;
        numResults = 0;
        source = new Entry[] { TextBox1, TextBox2, TextBox3 };
        for (int i = 0; i < 3; i++)
        {
            int input = int.Parse(source[i].Text);
            ThreadPool.QueueUserWorkItem(this.CalculateSlow, input);
        }
    }


    private void CalculateSlow(object num)
    {
        Threading.SlowMath sm = new Threading.SlowMath();
        int res = sm.Square((int)num);
        Interlocked.Add(ref sum, res);
        if (Interlocked.Increment(ref numResults) == 3)
            this.ResultTextBox.Dispatcher.Dispatch(() =>
            {
                this.ResultTextBox.Text = sum.ToString();
                this.CalculateButton.IsEnabled = true;
            });
    }
}

