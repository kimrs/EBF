namespace Eclipse.Domain.Ships.Parts;

public record Shield
{
    private readonly int _value;
    public static implicit operator int(Shield s) => s._value;
    public static implicit operator Shield(int i) => new(i);

    private Shield(int value)
    {
        _value = value switch
        {
            < 0 or > 10 => throw new ArgumentOutOfRangeException(nameof(value), "Shield value must be between 0 and 10."),
            _ => value
        };
    }
}
