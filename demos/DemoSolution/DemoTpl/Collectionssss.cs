using System.Collections.Concurrent;
using System.Security.AccessControl;

namespace DemoTpl;

public class Collectionssss
{
	public static ConcurrentDictionary<int, string> s_dict { get; set; } = new();
	
	public static void Go()
	{
		var t1 = Task.Run(() =>
		{
			for (int i = 0; i < 10; i++)
			{
				s_dict.TryAdd(i, "Task 1");
				Thread.Sleep(i * 10);
			}
		});
		var t2 = Task.Run(() =>
		{
			for (int i = 0; i < 10; i++)
			{
				s_dict.TryAdd(i, "Task 2");
				Thread.Sleep(i * 11);
			}
		});

		Task.WaitAll(t1, t2);
		foreach (var entry in s_dict)
		{
			Console.WriteLine($"{entry.Key} heeft value {entry.Value}");
		}

		// System.Collections.Concurrent.Bag
		// var lijstje = new List<int>();
		// lijstje[4].
	}
}