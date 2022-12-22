using Xunit;

namespace day2;


public class Tests
{
    [Theory]
    [InlineData('A', 1)]
    [InlineData('B', 2)]
    [InlineData('C', 3)]
    [InlineData('X', 1)]
    [InlineData('Y', 2)]
    [InlineData('Z', 3)]
    [InlineData('E', 5)]
    public void ConvertToNumber_should_convert_correctly(char character, int expected)
    {
        var actual = Day2.ConvertToNumber(character);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, Result.Draw)]
    [InlineData(2, 2, Result.Draw)]
    [InlineData(3, 3, Result.Draw)]
    [InlineData(1, 2, Result.Win)]
    [InlineData(2, 3, Result.Win)]
    [InlineData(3, 1, Result.Win)]
    [InlineData(2, 1, Result.Loss)]
    [InlineData(3, 2, Result.Loss)]
    [InlineData(1, 3, Result.Loss)]
    public void PlayRound_should_return_the_correct_result(int opponent, int us, Result expected)
    {
        var actual = Day2.PlayRound(opponent, us);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void PlayRound_should_throw_exception_if_input_is_out_of_range()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Day2.PlayRound(4, 1));
    }
}