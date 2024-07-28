using Eclipse.Domain.Dice;
using Eclipse.Domain.Ships;
using Eclipse.Domain.Ships.Events;
using FluentAssertions;

namespace Eclipse.Test.Combat.SufficientDamageApplied;

public class SufficientlyAppliedDamageTests
{
    [Fact]
    public void ShipGetsDestroyedAfterSufficientlyAttacked()
    {
        ShipEvent[] events =
        [
            new ShipEvent.PartAdded(
                Initiative: 0,
                Computer: 0,
                Shield: 0,
                Hull: 0,
                Cannons: []
            ),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 1, DieRoll.Max),
        ];

        events.Aggregate(SpaceShip.Empty, SpaceShip.Evolve)
            .Should()
            .BeOfType<SpaceShip.Destroyed>();
    }

    [Fact]
    public void ShipCountsDieRoll5AsHitWhenComputerIs1()
    {
        ShipEvent[] events =
        [
            new ShipEvent.PartAdded(
                Initiative: 0,
                Computer: 0,
                Shield: 0,
                Hull: 0,
                Cannons: []
            ),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 1, DieRoll: 5),
        ];

        events.Aggregate(SpaceShip.Empty, SpaceShip.Evolve)
            .Should()
            .BeOfType<SpaceShip.Destroyed>();
    }
    
    [Fact]
    public void ShipCountsDieRoll4AsMissWhenComputerIs1()
    {
        ShipEvent[] events =
        [
            new ShipEvent.PartAdded(
                Initiative: 0,
                Computer: 0,
                Shield: 0,
                Hull: 0,
                Cannons: []
            ),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 1, DieRoll: 4),
        ];

        events.Aggregate(SpaceShip.Empty, SpaceShip.Evolve)
            .Should()
            .BeOfType<SpaceShip.Operating>();
    }

    [Fact]
    public void ShipCountsDieRoll4AsMissWhenComputerIs2AndShieldIs1()
    {
        ShipEvent[] events =
        [
            new ShipEvent.PartAdded(
                Initiative: 0,
                Computer: 0,
                Shield: 1,
                Hull: 0,
                Cannons: []
            ),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 2, DieRoll: 4),
        ];

        events.Aggregate(SpaceShip.Empty, SpaceShip.Evolve)
            .Should()
            .BeOfType<SpaceShip.Operating>();
    }

    [Fact]
    public void ShipCountsDieRoll4AsHitWhenComputerIs2()
    {
        ShipEvent[] events =
        [
            new ShipEvent.PartAdded(
                Initiative: 0,
                Computer: 0,
                Shield: 0,
                Hull: 0,
                Cannons: []
            ),
            new ShipEvent.WasAttacked(Damage: 1, Computer: 2, DieRoll: 4),
        ];

        events.Aggregate(SpaceShip.Empty, SpaceShip.Evolve)
            .Should()
            .BeOfType<SpaceShip.Destroyed>();
    }
}