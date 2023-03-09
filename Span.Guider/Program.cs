using BenchmarkDotNet.Running;
using Span.Guider;

BenchmarkRunner.Run<GuiderBenchmarks>();


return;

var id = Guid.NewGuid();

Console.WriteLine(id);

var base64Id = Convert.ToBase64String(id.ToByteArray());
Console.WriteLine(base64Id);

var urlFriendlyBase64 = Guider.ToStringFromGuid(id);
Console.WriteLine(urlFriendlyBase64);

var urlFriendlyBase64Op = Guider.ToStringFromGuidOp(id);
Console.WriteLine(urlFriendlyBase64Op);


var idAgain = Guider.ToGuidFromString(urlFriendlyBase64);
Console.WriteLine(idAgain);

var idAgainOp = Guider.ToGuidFromStringOp(urlFriendlyBase64);
Console.WriteLine(idAgainOp);
