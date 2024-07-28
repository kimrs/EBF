namespace Eclipse.Domain.Dice;

public record DieRoll : IDie
{
    public static DieRoll Max = new(6);
    public static DieRoll Min = new(1);
    
    private readonly int _value;
    
    public static implicit operator DieRoll(int i) => new(i);
    public static implicit operator int(DieRoll d) => d._value;

    public DieRoll(int value)
    {
        _value = value < 1 ? 1 : value > 6 ? 6 : value;
    }

    public static bool operator <(DieRoll left, DieRoll right)
    {
        return left._value < right._value;
    }

    public static bool operator >(DieRoll left, DieRoll right)
    {
        return left._value > right._value;
    }

    public static bool operator <=(DieRoll left, DieRoll right)
    {
        return left._value <= right._value;
    }

    public static bool operator >=(DieRoll left, DieRoll right)
    {
        return left._value >= right._value;
    }
}