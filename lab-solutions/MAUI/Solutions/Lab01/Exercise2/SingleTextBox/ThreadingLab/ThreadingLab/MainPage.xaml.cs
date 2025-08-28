namespace ThreadingLab;

class ThreadContext
{
    public SynchronizationContext SyncContext;
    public int Number;
}

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
        SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        ThreadContext context = new() { SyncContext = synchronizationContext, Number = input1 };
        Thread th = new Thread(this.CalculateSlow);
        th.Start(context);
    }


    private void CalculateSlow(object context)
    {
        Threading.SlowMath sm = new Threading.SlowMath();
        ThreadContext threadContext = (ThreadContext)context;
        SynchronizationContext synchronizationContext = threadContext.SyncContext;
        int res = sm.Square(threadContext.Number);
        synchronizationContext.Post(s =>
        {
            this.ResultTextBox.Text = (string)s;
            this.CalculateButton.IsEnabled = true;
        }, res.ToString());
    }
}

