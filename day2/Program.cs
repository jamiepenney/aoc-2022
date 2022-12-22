using day2;

Console.WriteLine("Day 2");

var input = File.ReadAllLines("input.txt");
    
// function / code to convert first + second columns to appropriate scores,
// A - 1, B - 2, C - 3
// Loss - 0, Draw - 3, Win - 6
// Function for: is a line win, loss or draw?
// 1 - 1 Draw
// 2 - 2 Draw
// 3 - 3 Draw 

// 1 - 2 Win
// 2 - 3 Win 
// 3 - 1 Win

// 2 - 1 Loss
// 3 - 2 Loss
// 1 - 3 Loss 


// map back to a b c

// ACSCII table
// number -> character
// 40-something is a
// 66 is A - 1
// B - 66 = 1

var overallResult = input
    .Where(line => string.IsNullOrWhiteSpace(line) == false) // filter
    .Select(line => Day2.ParseLine(line)) // map
    .Select(round => (opponent: Day2.ConvertToNumber(round.opponent), us: Day2.ConvertToNumber(round.us)))
    .Select(round => (round.us, result: Day2.PlayRound(round.opponent, round.us)))
    .Select(roundResult => Day2.CalculateScore(roundResult.us, roundResult.result))
    .Sum(); // aggregate

Console.WriteLine(overallResult);


var overallResult2 = input
    .Where(line => string.IsNullOrWhiteSpace(line) == false) // filter
    .Select(line => Day2.ParseLine(line)) // map
    .Select(round => (opponent: Day2.ConvertToNumber(round.opponent), result: Day2.ConvertToResult(round.us)))
    .Select(round => (round.opponent, us: Day2.ChooseHandForResult(round.opponent, round.result)))
    .Select(round => (round.us, result: Day2.PlayRound(round.opponent, round.us)))
    .Select(roundResult => Day2.CalculateScore(roundResult.us, roundResult.result))
    .Sum(); // aggregate

Console.WriteLine(overallResult2);