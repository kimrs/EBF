using System.Collections.Generic;
using Eclipse;
using FluentAssertions;

namespace Test;
public class TestAttack
{
    [Fact]
    public void TestRange()
    {
        Dice dice = new ();
        CannonFactory cannonFactory = new (dice);
        Damage damage = new (1);
        List<Cannon> cannons = new ()
        {
            cannonFactory.Create(damage),
            cannonFactory.Create(damage),
        };
        List<ShipPart> shipParts = new ()
        {
            new (
                new Initiative(1),
                new Computer(2),
                new Shield(1),
                Hull: 3
            ),
        };

        var attacker = new SpaceShip(cannons, shipParts);
        var defender = new SpaceShip(cannons, shipParts);

        var d = attacker.Attack(defender);
    }
}