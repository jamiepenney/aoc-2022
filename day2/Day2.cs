namespace day2;

public static class Day2
{
    public static int ConvertToNumber(char c)
    {
        if (c >= 'X')
        {
            return c - 'X' + 1; // X = 1, Y = 2, Z = 3
        }

        return c - 'A' + 1; // A = 1, B = 2, C = 3
    }

    public static Result ConvertToResult(char c)
    {
        return c switch
        {
            'X' => Result.Loss,
            'Y' => Result.Draw,
            'Z' => Result.Win,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static int ChooseHandForResult(int opponent, Result result)
    {
        if (result == Result.Draw) return opponent;
        return (opponent, result) switch
        {
            (1, Result.Win) => 2,
            (2, Result.Win) => 3,
            (3, Result.Win) => 1,
            (2, Result.Loss) => 1,
            (3, Result.Loss) => 2,
            (1, Result.Loss) => 3,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static Result PlayRound(int opponent, int us)
    {
        if (opponent is < 0 or > 3 || us is < 0 or > 3)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        if (opponent == us) return Result.Draw;

        return (opponent, us) switch
        {
            (1, 2) => Result.Win,
            (2, 3) => Result.Win,
            (3, 1) => Result.Win,
            _ => Result.Loss
        };
    }

    public static int CalculateScore(int ourHand, Result result)
    {
        return ourHand + (int)result;
    }

    public static (char opponent, char us) ParseLine(string line)
    {
        return (line[0], line[2]);
    }
}