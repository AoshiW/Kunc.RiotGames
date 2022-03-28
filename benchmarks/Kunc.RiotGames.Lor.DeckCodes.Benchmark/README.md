``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100-preview.2.22153.17
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|       Method | type |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------------- |----- |----------:|----------:|----------:|-------:|----------:|
| **Riot.GetCode** |  **D_1** | **18.405 μs** | **0.3126 μs** | **0.2924 μs** | **3.5706** |     **15 KB** |
| Kunc.GetCode |  D_1 |  8.311 μs | 0.0713 μs | 0.0632 μs | 0.7019 |      3 KB |
|              |      |           |           |           |        |           |
| Riot.GetDeck |  D_1 |  8.176 μs | 0.0898 μs | 0.0796 μs | 1.1902 |      5 KB |
| Kunc.GetDeck |  D_1 |  5.652 μs | 0.0143 μs | 0.0111 μs | 0.5569 |      2 KB |
|              |      |           |           |           |        |           |
| **Riot.GetCode** |  **Max** | **26.951 μs** | **0.3141 μs** | **0.2938 μs** | **8.9722** |     **37 KB** |
| Kunc.GetCode |  Max | 14.475 μs | 0.1382 μs | 0.1293 μs | 1.7548 |      7 KB |
|              |      |           |           |           |        |           |
| Riot.GetDeck |  Max | 15.537 μs | 0.1016 μs | 0.0901 μs | 1.2207 |      5 KB |
| Kunc.GetDeck |  Max |  6.788 μs | 0.0544 μs | 0.0509 μs | 0.5722 |      2 KB |
|              |      |           |           |           |        |           |
| **Riot.GetCode** |  **Min** | **11.910 μs** | **0.1512 μs** | **0.1415 μs** | **2.1973** |      **9 KB** |
| Kunc.GetCode |  Min |  5.179 μs | 0.0449 μs | 0.0398 μs | 0.5035 |      2 KB |
|              |      |           |           |           |        |           |
| Riot.GetDeck |  Min |  4.878 μs | 0.0403 μs | 0.0357 μs | 0.7095 |      3 KB |
| Kunc.GetDeck |  Min |  3.396 μs | 0.0220 μs | 0.0195 μs | 0.3014 |      1 KB |
