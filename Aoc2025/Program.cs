using Aoc2025.Days;

namespace Aoc2025;

class Program
{
    public static async Task Main(string[] args)
    {
        // var solutionPart1 = await Day1.Part1Solution();
        // var solutionPart2 = await Day1.Part2Solution();
        
        var solutionDay2 = await Day2.Part1Solution();
        var solutionDay2P2 = await Day2.Part2Solution();
        
        // Console.WriteLine(solutionPart1);
        // Console.WriteLine(solutionPart2);
        Console.WriteLine(solutionDay2);
        Console.WriteLine(solutionDay2P2);
    }
}