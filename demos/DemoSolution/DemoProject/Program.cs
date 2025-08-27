// See https://aka.ms/new-console-template for more information

using DemoProject;

Console.WriteLine("Hello, World!");

// Basics.Go();
// RaceCondition.Go();

ThreadPool.QueueUserWorkItem((q) =>
{
	Thread.Sleep(1000);
	Console.WriteLine("hey werk klaar!");
});

Console.ReadKey();