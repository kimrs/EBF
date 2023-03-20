using System;
using System.Collections.Generic;
using System.Linq;

namespace Eclipse;

public class Dice
{
    private const int Sides = 6;
    private const int RollsPerShuffle = 72;
    private readonly Random _random;
    private List<DiceRoll> _rolls;
    private List<DiceRoll>.Enumerator _rollEnumerator;

    public Dice()
    {
        _random = new Random();
        _rolls = GenerateShuffledRolls();
        _rollEnumerator = _rolls.GetEnumerator();
    }

    private List<DiceRoll> GenerateShuffledRolls() =>
        Enumerable.Range(1, Sides)
            .SelectMany(x => Enumerable.Repeat(new DiceRoll(x), RollsPerShuffle / Sides))
            .OrderBy(x => _random.Next())
            .ToList();

    public DiceRoll Roll()
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
