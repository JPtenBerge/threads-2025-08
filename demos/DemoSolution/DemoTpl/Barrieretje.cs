namespace DemoTpl;

public class Barrieretje
{
	private static Barrier s_barrier = new(5, phase => Console.WriteLine($"fase {phase.CurrentPhaseNumber} gehad"));

	public static void Go()
	{
		var tasks = new List<Task>();

		for (int i = 0; i < 5; i++)
		{
			var index = i;
			tasks.Add(Task.Run(() =>
			{
				Console.WriteLine($"Task {index} is running!");
				Thread.Sleep(Random.Shared.Next(10, 50) * 100);
				Console.WriteLine($"Task {index} is weer wakker, even wachten tot iedereen dat is");
				s_barrier.SignalAndWait();
				Console.WriteLine($"Task {index} gaat weer door!");
				Thread.Sleep(Random.Shared.Next(10, 50) * 500);
				Console.WriteLine($"Task {index} is ALWEER wakker, even wachten tot iedereen dat is");
				s_barrier.SignalAndWait();
				Console.WriteLine($"Laatste obstakel gehad, Task {index} gaat weer door!");

				
			}));
		}

		Task.WaitAll(tasks);
	}
}