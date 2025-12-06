namespace Aoc2025.Days;

public class Day1
{
    private static async Task<List<string>> GetInputList()
    {
        var inputArr = await File.ReadAllLinesAsync("./Input/Day1.txt");
        return inputArr.ToList();    
    }
    
    public static async Task<int> Part1Solution()
    {
        var numbersList = Enumerable.Range(0, 100).ToList();       
        
        var inputList = await GetInputList();
        
        var startPos = numbersList.IndexOf(50);
        
        var zerosInSeq = 0;
        
        foreach (var input in inputList)
        {
            var direction = input[0];
            var distance = int.Parse(input[1..]);
            
            switch (direction)
            {
                case 'R':
                {
                    startPos += (distance % 100);

                    var isIndexOutOfRange = startPos > numbersList.Count - 1;
                
                    if (isIndexOutOfRange)
                    {
                        startPos %= 100;
                    }

                    break;
                }
                case 'L':
                {
                    startPos -= distance;

                    var isIndexOutOfRange = startPos < 0;

                    if (isIndexOutOfRange)
                    {
                        startPos = ((startPos % 100) + 100) % 100;
                    }

                    break;
                }
            }

            if (numbersList[startPos] == 0)
            {
                zerosInSeq++;
            }
        }
        
        return zerosInSeq;
    }
    
    // IT WORKED BUT AT WHAT COST 
    public static async Task<int> Part2Solution()
    {
        var numbersList = new  List<int>();

        for (int i = 0; i < 999; i++)
        {
            numbersList.AddRange(Enumerable.Range(0, 100).ToList());
        }
        
        var inputList = await GetInputList();
        
        var startPos = 52950;
        var startPosNum = numbersList[52950];
        
        var zerosDuringRotation = 0;
        
        foreach (var input in inputList)
        {
            var direction = input[0];
            var distance = int.Parse(input[1..]);
            
            switch (direction)
            {
                case 'R':
                {
                    for (int i = 0; i < distance; i++)
                    {
                        startPos++;

                        if (numbersList[startPos] == 0)
                        {
                            zerosDuringRotation++;
                        }
                    }   

                    break;
                }
                case 'L':
                {
                    for (int i = 0; i < distance; i++)
                    {
                        startPos--;

                        if (numbersList[startPos] == 0)
                        {
                            zerosDuringRotation++;
                        }
                    }   

                    break;
                }
            }
        }
        
        return zerosDuringRotation;
    }
}