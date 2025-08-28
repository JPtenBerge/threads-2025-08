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
        Task<int>[] tasks = new Task<int>[3];
        for (int i = 0; i < TextBoxes.Length; i++)
        {
            int myinput = int.Parse(TextBoxes[i].Text);
            Threading.SlowMath sm = new Threading.SlowMath();
            tasks[i] = Task<int>.Run(() => sm.Square(myinput));
        }
        Task.WhenAll(tasks).ContinueWith(t =>
        {
            int sum = 0;
            foreach (int i in t.Result)
                sum += i;
            ResultTextBox.Text = sum.ToString();
            CalculateButton.IsEnabled = true;
        }, TaskScheduler.FromCurrentSynchronizationContext());

    }
}

