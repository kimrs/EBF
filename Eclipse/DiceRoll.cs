namespace Eclipse;

public record DiceRoll
{
    public int Value { get; init; }

    public DiceRoll(int value)
    {
        Value = value < 1 ? 1 : value > 6 ? 6 : value;
    }

    public static bool operator <(DiceRoll left, DiceRoll right)
    {
        return left.Value < right.Value;
    }

    public static bool operator >(DiceRoll left, DiceRoll right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <=(DiceRoll left, DiceRoll right)
    {
        return left.Value <= right.Value;
    }

    public static bool operator >=(DiceRoll left, DiceRoll right)
    {
        return left.Value >= right.Value;
    }
}