namespace DemoTpl;

public class Stoppen
{
	public static void Go()
	{
		var cts = new CancellationTokenSource();
		
		var t = Task.Run(() =>
		{
			Console.WriteLine("summing...");
			int sum = 0;
			for (int i = 0; i < 2_000_000_000; i++)
			{
				cts.Token.ThrowIfCancellationRequested();
				
				sum += i;
			}

			Console.WriteLine($"gesumd! {sum}");
		}, cts.Token);

		Thread.Sleep(200);
		cts.Cancel();
		
		Task.WaitAll(t);
		Console.WriteLine("klaaaaar");
	}
}