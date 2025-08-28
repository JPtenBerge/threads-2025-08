namespace ThreadingLab;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async Task CalculateButton_Click(object sender, EventArgs e)
	{
        CalculateButton.IsEnabled = false;
        int input = int.Parse(TextBox1.Text);
        Threading.SlowMath sm = new Threading.SlowMath();
        int res = await sm.SquareAsync(input);
        ResultTextBox.Text = res.ToString();
        CalculateButton.IsEnabled = true;
    }
}

