using System.Text.RegularExpressions;

namespace Aoc2025.Days;

public class Day2
{
    private static async Task<List<string>> GetInputList()
    {
        var fileInput = await File.ReadAllTextAsync("./Input/Day2.txt");
        
        return fileInput.Split(',').Select(s => s.Trim()).ToList();
    }

    private static IEnumerable<string> CreateRange(long start, long count)
    {
        var limit = start + count;

        while (start <= limit)
        {
            yield return start.ToString();
            start++;
        }
    }

    public static async Task<long> Part1Solution()
    {
        var inputList = await GetInputList();

        var invalidList = new List<long>();

        foreach (var input in inputList)
        {
            var splittedStr = input.Split("-");
            
            var startRangeNumber = long.Parse(splittedStr[0]);
            var endRangeNumber = long.Parse(splittedStr[1]);
            
            var numRange = CreateRange(startRangeNumber, endRangeNumber - startRangeNumber);

            foreach (var num in numRange)
            {
                var startSeq = new string(num.Take(num.Length / 2).ToArray());
                var endSeq = new string(num.Skip(num.Length / 2).ToArray());

                if (startSeq.Length != endSeq.Length)
                {
                    continue;
                }

                if (string.Equals(startSeq, endSeq))
                {
                    invalidList.Add(long.Parse(num));
                }
            }
        }
        
        return invalidList.Sum();
    }

    public static async Task<long> Part2Solution()
    {
        var inputList = await GetInputList();
        
        var invalidList = new List<long>();
        
        foreach (var input in inputList)
        {
            var splittedStr = input.Split("-");
            
            var startRangeNumber = long.Parse(splittedStr[0]);
            var endRangeNumber = long.Parse(splittedStr[1]);
            
            var numRange = CreateRange(startRangeNumber, endRangeNumber - startRangeNumber);

            foreach (var num in numRange)
            {
                if (num.Length == 1)
                {
                    continue;
                }
                
                for (int i = 1; i <= num.Length; i++)
                {
                    var sequence = new string(num.Take(i).ToArray());
                    var occurrences = GetSequenceOccurrences(sequence, num);

                    if (occurrences <= 1)
                    {
                        continue;
                    }
                    
                    invalidList.Add(long.Parse(num));
                    break;
                }
            }
        }

        var distinct = invalidList.Distinct().ToList();
        
        return distinct.Sum();
    }

    private static int GetSequenceOccurrences(string sequence, string input)
    {
       if(sequence.Length == 1)
       {
           var occurenceCount = 1;

           if (input.All(x => x == sequence[0] && x == input[0]))
           {
               occurenceCount++;
           }

           return occurenceCount;
       }
        
       var pattern = $"({sequence})";
        
       var matches = Regex.Matches(input, pattern);
       
       if (matches.Count > 1)
       {
           var isStringLargerThanOccurenceCount = input.Length > sequence.Length * matches.Count;
       
           if (isStringLargerThanOccurenceCount)
           {
               return 1;
           }
       }
       
       return matches.Count;
    }
}