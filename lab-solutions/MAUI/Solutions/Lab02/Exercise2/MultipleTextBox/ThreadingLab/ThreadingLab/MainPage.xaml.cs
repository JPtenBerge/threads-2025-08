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
        Entry[] TextBoxes = { TextBox1, TextBox2, TextBox3 };
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
            ResultTextBox.Dispatcher.Dispatch(() =>
            {
                ResultTextBox.Text = sum.ToString();
                CalculateButton.IsEnabled = true;
            });
        });
    }
}

