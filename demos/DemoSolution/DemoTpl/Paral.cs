namespace DemoTpl;

public class Paral
{
	public static void Go()
	{
		Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

		try
		{
			Parallel.Invoke(
				() => Doe1(),
				() => Doe2());

		}
		catch (AggregateException ex)
		{
			Console.WriteLine("meer errors!");
		}
		Console.WriteLine("Alles klaar!");
		

		// Parallel.For(1, 50, (index, loopState) =>
		// {
		// 	if (index == 4)
		// 	{
		// 		Console.WriteLine("stoppen!");
		// 		loopState.Stop();
		// 		// loopState.Break();
		// 	}
		//
		// 	Thread.Sleep(index * 100);
		// 	Console.WriteLine($"index: {index}");
		// });
		
		

		// for (int i = 0; i < 500; i++)
		// {
		// 	continue;
		// }
		//
	}

	public static void Doe1()
	{
		Console.WriteLine($"Doe1 Thread: {Thread.CurrentThread.ManagedThreadId}");
		Thread.Sleep(3000);

		throw new ArgumentNullException("dit hoort niet");
		
		Console.WriteLine($"Doe1 Thread na sleep: {Thread.CurrentThread.ManagedThreadId}");
	}

	public static void Doe2()
	{
		Console.WriteLine($"Doe2 Thread: {Thread.CurrentThread.ManagedThreadId}");
		Thread.Sleep(1000);

		throw new NotImplementedException("Ga weg");
			
		Console.WriteLine($"Doe2 Thread na sleep: {Thread.CurrentThread.ManagedThreadId}");
	}
}