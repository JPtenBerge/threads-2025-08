namespace ThreadingLab;

using System.ComponentModel;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}
    private BackgroundWorker backgroundWorker = new BackgroundWorker();

    private void CalculateButton_Click(object sender, EventArgs e)
	{
        CalculateButton.IsEnabled = false;
        int input1 = int.Parse(TextBox1.Text);
        backgroundWorker.DoWork += (object sender, DoWorkEventArgs e) =>
        {
            Threading.SlowMath sm = new Threading.SlowMath();
            e.Result = sm.Square((int)e.Argument);
        };
        backgroundWorker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
        {
            ResultTextBox.Text = e.Result.ToString();
            CalculateButton.IsEnabled = true;
        };
        backgroundWorker.RunWorkerAsync(input1);

    }
}

