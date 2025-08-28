namespace ThreadingLab;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}
    int sum;
    Barrier barrier;
    Entry[] source;

    private void CalculateButton_Click(object sender, EventArgs e)
	{
        CalculateButton.IsEnabled = false;
        sum = 0;
        barrier = new Barrier(3, b => this.ResultTextBox.Dispatcher.Dispatch(() =>
        {
            this.ResultTextBox.Text = sum.ToString();
            CalculateButton.IsEnabled = true;
        }));
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
        barrier.SignalAndWait();
    }

}

