namespace Eclipse.Domain.Ships.Parts;

public class Hull
{
    private readonly int _value;
    public static implicit operator int(Hull h) => h._value;
    public static implicit operator Hull(int i) => new(i);
    public static Hull operator -(Hull hull, Damage damage) => hull._value - damage;

    private Hull(int value)
    {
        _value = value switch
        {
            < 0 or > 10 => throw new ArgumentOutOfRangeException(nameof(value), "Shield value must be between 0 and 10."),
            _ => value
        };
    }
}