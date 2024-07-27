using Eclipse.Domain.Dice;
using Eclipse.Domain.Ships;
using Eclipse.Domain.Ships.Events;
using FluentAssertions;

namespace Eclipse.Test;

public class InsufficientlyAttackedTests
{
    [Fact]
    public void ShipIsOperatingAferInsufficientlyAttacked()
    {
        ShipEvent[] events =
        [
            new ShipEvent.PartAdded(
                Initiative: 0,
                Computer: 0,
                Shield: 0,
                Hull: 1,
                Cannons: []
            ),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 0, DieRoll.Max),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 0, DieRoll.Min)
        ];

        events.Aggregate(SpaceShip.Empty, SpaceShip.Evolve)
            .Should()
            .BeOfType(typeof(SpaceShip.Operating));
    }

    [Fact]
    public void ShipIsOperatingAferInsufficientlyAttacked2()
    {
        ShipEvent[] events =
        [
            new ShipEvent.PartAdded(
                Initiative: 0,
                Computer: 0,
                Shield: 0,
                Hull: 1,
                Cannons: []
            ),
            new ShipEvent.PartAdded(
                Initiative: 0,
                Computer: 0,
                Shield: 0,
                Hull: 1,
                Cannons: []
            ),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 0, DieRoll.Max),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 0, DieRoll.Max)
        ];

        events.Aggregate(SpaceShip.Empty, SpaceShip.Evolve)
            .Should()
            .BeOfType(typeof(SpaceShip.Operating));
    }
}