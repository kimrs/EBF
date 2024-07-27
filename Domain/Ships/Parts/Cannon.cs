using Eclipse.Domain.Dice;

namespace Eclipse.Domain.Ships.Parts;

public record Cannon(
    Die Die,
    Damage Damage
)
{
    // public IDamage Fire(DieRollRange range)
    // {
    //     return range.IsWithinRange(Die.Roll()) ? Damage : new NoDamage();
    // }
}