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
        Entry[] textBoxes = { TextBox1, TextBox2, TextBox3 };
        Task<int>[] tasks = new Task<int>[3];
        for (int i = 0; i < 3; i++)
        {
            int input = int.Parse(textBoxes[i].Text);
            Threading.SlowMath sm = new Threading.SlowMath();
            tasks[i] = sm.SquareAsync(input);
        }
        await Task.WhenAll(tasks);
        int sum = 0;
        for (int i = 0; i < 3; i++)
            sum += tasks[i].Result;
        ResultTextBox.Text = sum.ToString();
        CalculateButton.IsEnabled = true;
    }
}

