using System.Diagnostics;
using System.IO;
using Task7_Reflection;
using Newtonsoft.Json;

int it_count = 1_000_000;
var f = F.Get();

var stopwatch = new Stopwatch();

// UniversalConverter - Serialization
string result = string.Empty;
stopwatch.Start();
for (int i = 0; i < it_count; i++)
{   
    result = UniversalConverter.ConvertToString(f);
}
stopwatch.Stop();

Console.WriteLine($"UniversalConverter result: {result}");
Console.WriteLine($"UniversalConverter serialization elapsed: {(stopwatch.ElapsedMilliseconds/(float)it_count)} ms");

// Newtonsoft.Json - Serialization
string jsonResult = string.Empty;
stopwatch.Restart();
for (int i = 0; i < it_count; i++)
{
    jsonResult = JsonConvert.SerializeObject(f);
}
stopwatch.Stop();

Console.WriteLine($"Newtonsoft result: {jsonResult}");
Console.WriteLine($"Newtonsoft serialization elapsed: {(stopwatch.ElapsedMilliseconds/(float)it_count)} ms");

// UniversalConverter - deserialization
var ini1 = File.ReadAllText("Example1.ini");
F? resultObj = null;

stopwatch.Restart();
for (int i = 0; i < it_count; i++)
{
    resultObj = UniversalConverter.ConvertFromString<F>(ini1);
}
stopwatch.Stop();

Console.WriteLine($"UniversalConverter deserialize elapsed: {(stopwatch.ElapsedMilliseconds/(float)it_count)} ms");


// Newtonsoft.Json - deserialization
var jsonIni = File.ReadAllText("Example2.ini");
F? jsonResultObj = null;

stopwatch.Restart();
for (int i = 0; i < it_count; i++)
{
    jsonResultObj = JsonConvert.DeserializeObject<F>(jsonIni)!;
}
stopwatch.Stop();

Console.WriteLine($"Newtonsoft deserialize elapsed: {(stopwatch.ElapsedMilliseconds/(float)it_count)} ms");

