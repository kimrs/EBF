namespace Eclipse.Domain.Ships.Parts;

public record Damage
{
    public static implicit operator int(Damage d) => d._value;
    public static implicit operator Damage(int i) => new(i);
    private readonly int _value;

    public Damage(int value)
    {
        _value = value < 1 ? 1 : value > 4 ? 4 : value;
    }
}