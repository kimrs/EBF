namespace Eclipse.Domain.Dice;

public class Die
{
    private const int Sides = 6;
    private const int RollsPerShuffle = 72;
    private readonly List<DieRoll> _rollList;
    private List<DieRoll>.Enumerator _rollEnumerator;

    public Die()
    {
        _rollList = GenerateShuffledRolls(new Random());
        _rollEnumerator = _rollList.GetEnumerator();
    }

    private static List<DieRoll> GenerateShuffledRolls(Random r)
        => Enumerable.Range(1, Sides)
        .SelectMany(x => Enumerable.Repeat(new DieRoll(x), RollsPerShuffle / Sides))
        .OrderBy(_ => r.Next())
        .ToList();

    public DieRoll Roll()
    {
        if (!_rollEnumerator.MoveNext())
        {
            _rollEnumerator = _rollList.GetEnumerator();
            _rollEnumerator.MoveNext();
        }

        return _rollEnumerator.Current;
    }
}