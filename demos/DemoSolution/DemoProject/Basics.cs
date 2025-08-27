using System.Diagnostics;

namespace DemoProject;

public class Basics
{
	public static void Go()
	{
		var t1 = new Thread(() =>
		{
			Console.WriteLine("thread 1");
			var watch = Stopwatch.StartNew();
			for (int i = 0; i < 50_000; i++)
			{
				Console.Write("x");
			}
			watch.Stop();
			Console.WriteLine($"Verstreken t1: {watch.ElapsedMilliseconds}");
		});
		t1.Priority = ThreadPriority.Lowest;
		var t2 = new Thread(() =>
		{
			Console.WriteLine("thread 2");
			var watch = Stopwatch.StartNew();
			for (int i = 0; i < 50_000; i++)
			{
				Console.Write(".");
			}
			watch.Stop();
			Console.WriteLine($"Verstreken t2: {watch.ElapsedMilliseconds}");
		});
		t2.Priority = ThreadPriority.Highest;
		t1.Start();
		t2.Start();
	}

}