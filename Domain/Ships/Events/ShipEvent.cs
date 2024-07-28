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
    ) : ShipEvent
    {
        public static readonly PartAdded Empty = new (
            Initiative: 0,
            Computer: 0,
            Shield: 0,
            Hull: 0,
            Cannons: []
        );

        public static readonly PartAdded GluonComputer = new(
            Initiative: 0,
            Computer: 0,
            Shield: 0,
            Hull: 0,
            Cannons: [new Cannon(1)]
        );

        public static readonly PartAdded SentientHull = new(
            Initiative: 0,
            Computer: 0,
            Shield: 0,
            Hull: 1,
            Cannons: []
        );
    }

    public record WasAttacked(
        Damage Damage,
        Computer Computer,
        DieRoll DieRoll
    ) : ShipEvent;
}