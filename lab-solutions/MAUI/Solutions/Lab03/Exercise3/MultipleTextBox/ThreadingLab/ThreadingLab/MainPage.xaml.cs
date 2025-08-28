namespace ThreadingLab;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    public async IAsyncEnumerable<int> GetSquaresAsync()
    {
        Entry[] textBoxes = { TextBox1, TextBox2, TextBox3 };
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
    private async Task CalculateButton_Click(object sender, EventArgs e)
    {
        CalculateButton.IsEnabled = false;
        int sum = 0;
        await foreach (int res in GetSquaresAsync())
            sum += res;
        ResultTextBox.Text = sum.ToString();
        CalculateButton.IsEnabled = true;
    }
}

