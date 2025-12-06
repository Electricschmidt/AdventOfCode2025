const string fileName = "C:\\Users\\Thomas\\AdventOfCode2025\\input_day3.txt";

var text = File
    .OpenText(fileName)
    .ReadToEnd().Split('\n', StringSplitOptions.RemoveEmptyEntries);

PartTwo(text);

static void PartOne(string[] input)
{
    var joltages = input
        .Select(line =>
        {
            var chars = line.TrimEnd('\r').ToCharArray();
            var (largestFirstNumber, index) = chars[..^1].Select((c, idx) => (c, idx)).MaxBy(m => m.c);

            return int.Parse(string.Join(string.Empty, [largestFirstNumber, chars[(index + 1)..].Max()]));
        });

    Console.WriteLine(joltages.Sum());
}

static void PartTwo(string[] input)
{
    var twelveBatteries = input
        .Select(line =>
        {
            var chars = line.TrimEnd('\r').ToCharArray().Select((c, idx) => (c, idx)).ToArray();
            var maxTwelve = new char[12];
            var lastSetIndex = 0;
            foreach (var (c, idx) in chars)
            {
                if (lastSetIndex == 12)
                    break;

                if (!chars[(idx + 1)..Math.Min(chars.Length - 11 + lastSetIndex, chars.Length)].All(ch => ch.c <= c))
                    continue;

                maxTwelve[lastSetIndex] = c;
                lastSetIndex++;
            }

            return long.Parse(string.Join(string.Empty, maxTwelve));
        });

    Console.WriteLine(twelveBatteries.Sum());
}

