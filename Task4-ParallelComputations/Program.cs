using System.Diagnostics;

var sizes = new int[3] { 100_000, 1_000_000, 10_000_000 };

var random = new Random();
var stopwatch = new Stopwatch();

foreach (var size in sizes)
{
    var array = new int[size];
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = random.Next(-100, 101);
    }

    stopwatch.Restart();
    var classicSum = ClassicSum(array);
    stopwatch.Stop();
    Console.WriteLine($"Classic Sum of {size} elements: {classicSum}, Time: {stopwatch.Elapsed}");

    stopwatch.Restart();
    var parallelSum = ParallelSum(array);
    stopwatch.Stop();
    Console.WriteLine($"Parallel Sum of {size} elements: {parallelSum}, Time: {stopwatch.Elapsed}");

    stopwatch.Restart();
    var linqParallelSum = LinqParallelSum(array);
    stopwatch.Stop();
    Console.WriteLine($"LINQ Parallel Sum of {size} elements: {linqParallelSum}, Time: {stopwatch.Elapsed}");
}

static long ClassicSum(int[] array)
{
    long sum = 0;
    foreach (var item in array)
    {
        sum += item;
    }
    return sum;
}

static long ParallelSum(int[] array)
{
    long sum = 0;
    Parallel.For(0, array.Length, i => Interlocked.Add(ref sum, array[i]));

    return sum;
}

static long LinqParallelSum(int[] array)
{
    return array.AsParallel().Sum();
}