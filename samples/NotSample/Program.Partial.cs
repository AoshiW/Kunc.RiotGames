global using NotSample;

using System.Diagnostics;
using BenchmarkDotNet.Running;

partial class Program
{
    [Conditional("RELEASE")]
    static void RunBenchmarks(bool exit = true)
    {
        BenchmarkRunner.Run<LorDeckEncoderBenchmark>();
        if (exit)
            Environment.Exit(0);
    }
}
