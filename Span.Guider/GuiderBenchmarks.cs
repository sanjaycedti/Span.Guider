using System;
using BenchmarkDotNet.Attributes;

namespace Span.Guider;

[MemoryDiagnoser(false)]
public class GuiderBenchmarks
{
	private static readonly Guid guid = Guid.Parse("ce905a43-18c2-45a4-a0c4-2e8ede2c4c40");
	private const string str = "Q1qQzsIYpEWgxC6O3ixMQA";

	[Benchmark]
	public Guid ToGuidFromString()
	{
		return Guider.ToGuidFromString(str);
	}

    [Benchmark]
    public Guid ToGuidFromStringOp()
    {
        return Guider.ToGuidFromStringOp(str);
    }

    [Benchmark]
    public string ToStringFromGuid()
	{
		return Guider.ToStringFromGuid(guid);
	}

    [Benchmark]
    public string ToStringFromGuidOp()
    {
        return Guider.ToStringFromGuidOp(guid);
    }
}

