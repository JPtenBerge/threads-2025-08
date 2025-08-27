// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Task.Run(() =>
	{
		Thread.Sleep(1000);
		Console.WriteLine("Hallo vanaf Task");

		return 42;
	})
	.ContinueWith(task => Console.WriteLine($"result via continuewith: {task.Result}"));

// task.Start();
Thread.Sleep(2000);


// Task.WaitAll(task); // ⚠️
// Console.WriteLine("klaar");
// Console.WriteLine($"task.Result: {task.Result}"); // await

// new Thread() is altijd een nieuwe thread (OS-thread!)
// new Task() is soms/meestal een nieuwe thread.

// Task.Factory.StartNew()


// var result = await task;
// var result2 = await task;
// var result3 = await task;

// Task.FromResult()

// var tasky = new ValueTask<string>(new Task<string>(() =>
// {
// 	return "qqw";
// 	
// }));


// var valueTaskje = new ValueTask<string>(q =>
// {
// 	return "qwertyu";
// });