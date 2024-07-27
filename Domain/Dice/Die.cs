namespace Eclipse.Domain.Dice;

public class Die
{
    private const int Sides = 6;
    private const int RollsPerShuffle = 72;
    private readonly Random _random;
    private List<DieRoll> _rolls;
    private List<DieRoll>.Enumerator _rollEnumerator;

    public Die()
    {
        _random = new Random();
        _rolls = GenerateShuffledRolls();
        _rollEnumerator = _rolls.GetEnumerator();
    }

    private List<DieRoll> GenerateShuffledRolls() =>
        Enumerable.Range(1, Sides)
            .SelectMany(x => Enumerable.Repeat(new DieRoll(x), RollsPerShuffle / Sides))
            .OrderBy(x => _random.Next())
            .ToList();

    public DieRoll Roll()
    {
        if (!_rollEnumerator.MoveNext())
        {
            _rolls = GenerateShuffledRolls();
            _rollEnumerator = _rolls.GetEnumerator();
            _rollEnumerator.MoveNext();
        }

        return _rollEnumerator.Current;
    }
}
