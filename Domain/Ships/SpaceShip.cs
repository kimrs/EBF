using Eclipse.Domain.Dice;
using Eclipse.Domain.Ships.Commands;
using Eclipse.Domain.Ships.Events;
using Eclipse.Domain.Ships.Parts;

namespace Eclipse.Domain.Ships;

public abstract record SpaceShip
{
    public static readonly SpaceShip Empty = new Operating();
    public static SpaceShip Create(List<ShipEvent> events) => events.Aggregate(Empty, Evolve);

    public abstract Attack Attack(DieRoll dieRoll);

    public SpaceShip Handle(Attack attack)
    {
        return attack switch
        {
            Attack.FromCannon fromCannon => Evolve(
                spaceShipState: this, 
                new ShipEvent.WasAttacked(
                    Damage: fromCannon.Cannons.Sum(x => x.Damage),
                    fromCannon.Computer,
                    fromCannon.DieRoll)),
            _ => this
        };
    }
    
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

        public override Attack Attack(DieRoll dieRoll) => new Attack.FromCannon(Computer, Cannons, dieRoll);
    }

    public record Destroyed : SpaceShip
    {
        public override Attack Attack(DieRoll dieRoll) => new Attack.NoAttack();
    }
}