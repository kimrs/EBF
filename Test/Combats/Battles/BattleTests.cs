using Eclipse.Domain.Dice;
using Eclipse.Domain.Ships;
using Eclipse.Domain.Ships.Events;

namespace Eclipse.Test.Combats.Battles;

public class BattleTests
{
    private List<ShipEvent> BaseEvents =
    [
        ShipEvent.PartAdded.GluonComputer,
        ShipEvent.PartAdded.SentientHull
    ];
        
    [Fact]
    public void D()
    {
        var die = new Die();

        var defender = SpaceShip.Create(BaseEvents);
        var attacker = SpaceShip.Create(BaseEvents);
        
        var attackedDefender = defender.Handle(attacker.Attack(die.Roll()));
        
    }
}