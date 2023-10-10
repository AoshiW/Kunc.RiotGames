using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
