namespace DemoProject;

public class RaceCondition
{
	public static int s_counter = 0;
	private static object s_lockObj = new { };
	
	public static void Go()
	{
		var t1 = new Thread(() =>
		{
			// hier?
			for (int i = 0; i < 1_000_000; i++)
			{
				lock (s_lockObj)
				{
					s_counter++;
				}
			}
		});
		var t2 = new Thread(() =>
		{
			for (int i = 0; i < 1_000_000; i++)
			{
				Monitor.Enter(s_lockObj);
				s_counter++;
				Monitor.Exit(s_lockObj);
			}
		});
		t1.Start();
		t2.Start();
		
		Console.WriteLine("Wachten...");

		t1.Join();
		t2.Join();

		Console.WriteLine($"Counter: {s_counter}");
	}
}