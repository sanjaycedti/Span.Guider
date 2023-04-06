# Span.Guider


BenchmarkDotNet=v0.13.5, OS=macOS Ventura 13.1 (22C65) [Darwin 22.2.0]
Apple M1 Pro, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD [AttachedDebugger]
  DefaultJob : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD


|             Method |     Mean |    Error |   StdDev |   Median | Allocated |
|------------------- |---------:|---------:|---------:|---------:|----------:|
|   ToGuidFromString | 53.41 ns | 1.069 ns | 1.600 ns | 52.94 ns |     112 B |
| ToGuidFromStringOp | 30.84 ns | 0.255 ns | 0.213 ns | 30.80 ns |         - |
|   ToStringFromGuid | 70.38 ns | 2.062 ns | 5.815 ns | 68.32 ns |     184 B |
| ToStringFromGuidOp | 35.66 ns | 1.470 ns | 4.219 ns | 34.52 ns |      72 B |
