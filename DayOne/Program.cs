const string fileName = "C:\\Users\\Thomas\\AdventOfCode2025\\input_day1.txt";

var text = File
    .OpenText(fileName)
    .ReadToEnd().Split('\n', StringSplitOptions.RemoveEmptyEntries);

var moves = text
    .Select(t => t[0] == 'L' ? -int.Parse(t[1..]) : int.Parse(t[1..]))
    .ToArray();

Part2(moves);

static void Part1(int[] moves)
{
    var currentPos = 50;
    var count = 0;
    foreach (var move in moves)
    {
        currentPos = Mod(currentPos + move, 100);
        if (currentPos == 0)
            count++;
    }

    Console.WriteLine(count);
}

static void Part2(int[] moves)
{
    var currentPos = 50;
    var count = 0;
    foreach (var move in moves)
    {
        Console.WriteLine($"CURRENT POSITION: {currentPos}, MOVE: {move}");

        var nextPos = currentPos + move;
        if ((nextPos <= 0 || nextPos >= 100) && currentPos != 0)
        {
            count += 1;
            Console.WriteLine("COUNT +1");
        }

        var absoluteMove = Math.Abs(move);

        if (absoluteMove > 100)
        {
            count += absoluteMove / 100;
            Console.WriteLine($"COUNT +{absoluteMove / 100}");
        }

        currentPos = Mod(currentPos + move, 100);
    }

    Console.WriteLine(count);
}

static int Mod(int x, int m) => (x % m + m) % m;

