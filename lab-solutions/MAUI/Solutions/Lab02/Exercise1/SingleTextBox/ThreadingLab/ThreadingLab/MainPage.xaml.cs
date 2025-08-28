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

