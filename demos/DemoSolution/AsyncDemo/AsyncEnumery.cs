namespace AsyncDemo;

public class AsyncEnumery
{
	public static async Task Go()
	{

		// await using var bla;
		
		
		await foreach (var getal in GeefIntegers())
		{
			Console.WriteLine($"getal: {getal}");
		}
		// var source = GeefOudeIntegers();
		// var enumerator = source.GetEnumerator();
		// enumerator.MoveNext();
		// enumerator.MoveNext();
		// enumerator.MoveNext();

	}

	public static IEnumerable<int> GeefOudeIntegers()
	{
		Console.WriteLine("eerste");
		yield return 4;
		Console.WriteLine("tweede");
		yield return 8;
		Console.WriteLine("derde");
		yield return 15;
		Console.WriteLine("vierde");
		yield return 16;
		Console.WriteLine("vijfde");
		yield return 23;
		Console.WriteLine("zesde");
		yield return 42;
	}
	
	public static async IAsyncEnumerable<int> GeefIntegers()
	{
		Console.WriteLine("eerste");
		await Task.Delay(1000);
		yield return 4;
		Console.WriteLine("tweede");
		await Task.Delay(1000);
		yield return 8;
		Console.WriteLine("derde");
		await Task.Delay(1000);
		yield return 15;
		Console.WriteLine("vierde");
		await Task.Delay(5000);
		yield return 16;
		Console.WriteLine("vijfde");
		await Task.Delay(1000);
		yield return 23;
		Console.WriteLine("zesde");
		await Task.Delay(1000);
		yield return 42;
	}
}