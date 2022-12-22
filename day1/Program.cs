
Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("input.txt").Select(line => int.TryParse(line, out var parsed) ? (int?)parsed : null);

var result = input.Aggregate<int?, (int Highest, int Current)>((0, 0), (acc, val) =>
{
    if (val != null) return (acc.Highest, acc.Current + val.Value);
    
    return acc.Current > acc.Highest ? (acc.Current, 0) : (acc.Highest, 0);
});

Console.WriteLine(result.Highest);

Console.WriteLine("Part 2");

var input2 = File.ReadAllLines("input.txt")
    .Select(line => int.TryParse(line, out var parsed) ? (int?)parsed : null);
    
var result2 = input2.Aggregate(new List<int>{0}, (acc, val) =>
{
    if (val != null)
    {
        acc[^1] += val.Value;
        return acc;
    }
    acc.Add(0);
    return acc;
});

Console.WriteLine(result2.OrderByDescending(a => a).Take(3).Sum());