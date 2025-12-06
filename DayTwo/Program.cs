const string fileName = "C:\\Users\\Thomas\\AdventOfCode2025\\input_day2.txt";

var text = File
    .OpenText(fileName)
    .ReadToEnd();

static void PartOne(string input)
{
    long[] ids =
        [..
        input
        .Split(',')
        .SelectMany(r =>
        {
            var split = r.Split('-');
            var startLength = split[0].Length;
            var endLength = split[1].Length;
            var oddStart = startLength % 2 == 1;
            var oddEnd = endLength % 2 == 1;

            if (oddStart && oddEnd && startLength == endLength)
                return [];

            var start = oddStart ? (long)Math.Pow(10, startLength) : long.Parse(split[0]);
            var end = oddEnd ? (long)Math.Pow(10, endLength - 1) : long.Parse(split[1]);

            return CreateRange(start, end - start + 1);
        })
    ];
    var invalidIds = ids.Where(id =>
    {
        var idAsString = id.ToString();
        return idAsString[..(idAsString.Length / 2)] == idAsString[(idAsString.Length / 2)..];
    });

    Console.WriteLine(invalidIds.Sum());
}

static void PartTwo(string input)
{
    var ids = input.Split(',').SelectMany(r =>
    {
        var split = r.Split('-');
        var start = long.Parse(split[0]);
        var end = long.Parse(split[1]);

        return CreateRange(start, end - start + 1);
    }).ToArray();

    var invalidIds = ids.Where(id =>
    {
        var idAsString = id.ToString();
        var possibleSubPatterns = Enumerable.Range(1, idAsString.Length / 2).Select(n => idAsString[..n]);

        return possibleSubPatterns.Any(pt =>
        {
            if (idAsString.Length % pt.Length != 0)
                return false;

            return string.Concat(Enumerable.Repeat(pt, idAsString.Length / pt.Length)) == idAsString;
        });
    });

    Console.WriteLine(invalidIds.Sum());
}

static IEnumerable<long> CreateRange(long start, long count)
{
    var limit = start + count;

    while (start < limit)
    {
        yield return start;
        start++;
    }
}