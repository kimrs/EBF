using Eclipse.Domain.Dice;

namespace Eclipse.Domain.Ships.Parts;

public record Computer
{
    private readonly int _value;
    public static implicit operator Computer(int v) => new (v);
    public static implicit operator int(Computer c) => c._value;
    
    public static Computer operator +(Computer a, Computer b) => a._value + b._value; 

    private Computer(int value)
    {
        _value = value switch
        {
            < 0 or > 10 => throw new ArgumentOutOfRangeException(nameof(value), "Computer value must be between 0 and 10."),
            _ => value
        };
    }

    public DieRoll Against(Shield shield)
        => 6 - _value - shield;
}