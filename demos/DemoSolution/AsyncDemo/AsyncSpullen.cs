using System.Text;

namespace AsyncDemo;

public class AsyncSpullen
{
	private static object locKObj = new { };

	public static async Task Go()
	{
		var path = "C:\\repos\\course-instances\\threads-2025-08\\bestand.txt";
		// lock (locKObj)
		// {
			await File.AppendAllTextAsync(path, "Hallo!");
		// }

		Console.WriteLine("yes werkt");

		// Asynchronous Programming Model
		// .Begin...
		// .End...
		// var stream = File.OpenWrite(path);
		//
		// var buffer = Encoding.ASCII.GetBytes("wow dit werkt!!");
		//
		// stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(FinishWrite), stream);
	}

	// public static void FinishWrite(IAsyncResult asyncResult)
	// {
	// 	var stream = asyncResult.AsyncState as FileStream;
	// 	stream.EndWrite(asyncResult);
	// 	stream.Flush();
	// 	stream.Close();
	// 	Console.WriteLine("Bestand nu echt weggeschreven!");
	// }
}