using Eclipse.Domain.Dice;
using Eclipse.Domain.Ships.Parts;

namespace Eclipse.Domain.Ships.Commands;


public record Attack
{
    public record NoAttack : Attack;

    public record FromCannon(Computer Computer, IEnumerable<Cannon> Cannons, DieRoll DieRoll) : Attack;
}
