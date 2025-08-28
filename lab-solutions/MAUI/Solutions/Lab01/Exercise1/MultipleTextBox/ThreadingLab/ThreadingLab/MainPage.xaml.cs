namespace ThreadingLab;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    Thread[] th = new Thread[3];
    int[] res = new int[3];
    Entry[] source;
    int[] input = new int[3];
    //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
    private void CalculateButton_Click(object sender, EventArgs e)
    {
        CalculateButton.IsEnabled = false;

        source = new Entry[] { TextBox1, TextBox2, TextBox3 };
        for (int i = 0; i < 3; i++)
        {
            input[i] = int.Parse(source[i].Text);
            th[i] = new Thread(this.CalculateSlow);
            th[i].Start(i);
        }
        Thread th4 = new Thread(AddAndStoreResult);
        th4.Start();


    }

    private void AddAndStoreResult()
    {
        for (int i = 0; i < 3; i++)
            th[i].Join();
        int sum = 0;
        for (int i = 0; i < 3; i++)
            sum += res[i];

        this.ResultTextBox.Dispatcher.Dispatch(() =>
        {
            this.ResultTextBox.Text = sum.ToString();
            this.CalculateButton.IsEnabled = true;
        });
    }

    private void CalculateSlow(object num)
    {
        Threading.SlowMath sm = new Threading.SlowMath();
        res[(int)num] = sm.Square(input[(int)num]);
    }
}

