using System.Diagnostics;

namespace DemoTpl;

public class Plinq
{
	public static void Go()
	{
		// Enumerable.Range(1, int.MaxValue);
		
		List<int> getallen = [1, 24, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 ,15, 16, 17, 18, 19, 20, 21, 22, 23];

		var stopwatch = new Stopwatch();
		stopwatch.Start();
		var gefiltered = getallen.AsParallel().WithCancellation().AsOrdered().Where(x => IngewikkeldFilter(x));
		foreach (var getal in gefiltered)
		{
			Console.WriteLine($"getal: {getal}");
		}
		stopwatch.Stop();
		Console.WriteLine($"Elapsed milliseconds: {stopwatch.ElapsedMilliseconds}");
	}

	public static bool IngewikkeldFilter(int getal)
	{
		Console.WriteLine($"getal verwerken {getal} - {Thread.CurrentThread.ManagedThreadId}");
		Thread.SpinWait(90_000_000);
		return true;
	}
}