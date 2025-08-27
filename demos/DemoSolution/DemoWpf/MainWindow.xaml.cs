using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	{
		var t = new Thread(() =>
		{
			Thread.Sleep(3000);
			lblResult.Dispatcher.Invoke(() => // roep aan op UI thread
			{
				lblResult.Content = "Thread klaar!";
			});
		});
		t.Start();
	}


	private void BtnWorker_OnClick(object sender, RoutedEventArgs e)
	{
		var worker = new BackgroundWorker();
		worker.WorkerReportsProgress = true;
		worker.DoWork += (o, args) =>
		{
			try
			{
				// lblVoortgang.Content = $"testje";
				worker.ReportProgress(20);
				Thread.Sleep(1500);
				worker.ReportProgress(40);
				Thread.Sleep(500);
				worker.ReportProgress(45);
				Thread.Sleep(5000);
				worker.ReportProgress(80);
				Thread.Sleep(1000);
				worker.ReportProgress(100);

			}
			catch (Exception ex)
			{
				Console.WriteLine("ohoh! " + ex.Message);
			}
		};
		
		worker.ProgressChanged += (sender, args) =>
		{
			lblVoortgang.Content = $"Voortgang nu op {args.ProgressPercentage}%";
		};
		worker.RunWorkerAsync();

	}
}