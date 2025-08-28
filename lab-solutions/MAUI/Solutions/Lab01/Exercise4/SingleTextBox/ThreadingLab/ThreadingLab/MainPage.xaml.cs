namespace ThreadingLab;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void CalculateButton_Click(object sender, EventArgs e)
    {
        CalculateButton.IsEnabled = false;
        int input1 = int.Parse(TextBox1.Text);
        ThreadPool.QueueUserWorkItem(CalculateSlow, input1);
    }


    private void CalculateSlow(object num)
    {
        Threading.SlowMath sm = new Threading.SlowMath();
        int res = sm.Square((int)num);
        this.ResultTextBox.Dispatcher.Dispatch(() =>
        {
            this.ResultTextBox.Text = res.ToString();
            this.CalculateButton.IsEnabled = true;
        });
    }
}

