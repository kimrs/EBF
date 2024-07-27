using Eclipse.Domain.Dice;
using Eclipse.Domain.Ships.Parts;

namespace Eclipse.Domain.Ships.Events;

public abstract record ShipEvent
{
    public record PartAdded(
        Initiative Initiative,
        Computer Computer,
        Shield Shield,
        Hull Hull,
        List<Cannon> Cannons
    ) : ShipEvent;

    public record WasAttacked(
        Damage Damage,
        Computer Computer,
        DieRoll DieRoll
    ) : ShipEvent;
}