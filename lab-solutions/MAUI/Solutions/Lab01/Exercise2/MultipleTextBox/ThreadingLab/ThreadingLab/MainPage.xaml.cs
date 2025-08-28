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
    private void CalculateButton_Click(object sender, EventArgs e)
    {
        CalculateButton.IsEnabled = false;
        SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        source = new Entry[] { TextBox1, TextBox2, TextBox3 };
        for (int i = 0; i < 3; i++)
        {
            input[i] = int.Parse(source[i].Text);
            th[i] = new Thread(this.CalculateSlow);
            th[i].Start(i);
        }
        Thread th4 = new Thread(AddAndStoreResult);
        th4.Start(synchronizationContext);


    }

    private void AddAndStoreResult(object context)
    {
        SynchronizationContext synchronizationContext = (SynchronizationContext)context;
        for (int i = 0; i < 3; i++)
            th[i].Join();
        int sum = 0;
        for (int i = 0; i < 3; i++)
            sum += res[i];

        synchronizationContext.Post(s =>
        {
            this.ResultTextBox.Text = (string)s;
            this.CalculateButton.IsEnabled = true;
        }, sum.ToString());
    }

    private void CalculateSlow(object num)
    {
        Threading.SlowMath sm = new Threading.SlowMath();
        res[(int)num] = sm.Square(input[(int)num]);
    }
}

