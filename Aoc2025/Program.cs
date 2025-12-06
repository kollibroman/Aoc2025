namespace Aoc2025;

class Program
{
    public static async Task Main(string[] args)
    {
        var solutionPart1 = await Day1.Part1Solution();
        var solutionPart2 = await Day1.Part2Solution();
        
        Console.WriteLine(solutionPart1);
        Console.WriteLine(solutionPart2);
    }
}