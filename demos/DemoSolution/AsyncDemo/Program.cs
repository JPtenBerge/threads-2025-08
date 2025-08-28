using System.Diagnostics;
using AsyncDemo;

Console.WriteLine("Hello, World!");


AsyncSpullen.Go().GetAwaiter().GetResult();

// (typeof AsyncSpullen)
Process.Start("cmd.exe");