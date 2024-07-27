using Eclipse.Domain.Dice;
using Eclipse.Domain.Ships.Events;
using Eclipse.Domain.Ships.Parts;

namespace Eclipse.Domain.Ships;

public record SpaceShip
{
    public static readonly SpaceShip Empty = new Operating();
    public static SpaceShip Evolve(SpaceShip spaceShipState, ShipEvent @event)
    {
        if (spaceShipState is not Operating state)
        {
            return spaceShipState;
        }

        if (@event is ShipEvent.PartAdded partAdded)
        {
            return state + partAdded;
        }

        if (@event is ShipEvent.WasAttacked attacked)
        {
            return attacked.DieRoll >= DieRoll.Max - attacked.Computer + state.Shield
                ? state - attacked.Damage
                : state;
        }

        return state;
    }

    public record Operating
        : SpaceShip
    {
        private readonly List<ShipEvent> _events = [];
        private Initiative Initiative { get; init; } = 0;
        private Computer Computer { get; init; } = 0;
        public Shield Shield { get; private init; } = 0;
        private Hull Hull { get; init; } = 0;
        private List<Cannon> Cannons { get; init; }= [];

        public static Operating operator +(Operating operating, ShipEvent.PartAdded partAdded)
            => operating with
            {
                Initiative = operating.Initiative + partAdded.Initiative,
                Computer = operating.Computer + partAdded.Computer,
                Shield = operating.Shield + partAdded.Shield,
                Hull = operating.Hull + partAdded.Hull,
                Cannons = [..operating.Cannons, ..partAdded.Cannons]
            };

        public static SpaceShip operator -(Operating operating, Damage damage)
            => operating.Hull < damage
            ? new Destroyed()
            : operating with
            {
                Hull = operating.Hull - damage
            };
    }

    public record Destroyed : SpaceShip
    {
        public Destroyed() { }
    }
}