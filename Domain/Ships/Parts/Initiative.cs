using System.Diagnostics;

namespace Eclipse.Domain.Ships.Parts;

public record Initiative
{
    private int Value { get; init; }
    public static implicit operator Initiative(int v) => new(v);
    public static implicit operator int(Initiative i) => i.Value;
    
    // public static Initiative operator +(Initiative a, Initiative b) => a + b;
    private Initiative(int value)
    {
        Value = value switch
        {
            < 0 or > 10 => throw new ArgumentOutOfRangeException(nameof(value), "Initiative value must be between 0 and 10."),
            _ => value
        };
    }
}
