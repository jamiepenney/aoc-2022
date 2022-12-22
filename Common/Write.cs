namespace Common;

public static class Write
{
    public static void Print<T>(this IEnumerable<T> list)
    {
        Console.WriteLine(string.Join(", ", list));
    }
}