namespace Eclipse;

public class BattleField
{
    private IEnumerable<SpaceShip> _attackingFleet;
    private IEnumerable<SpaceShip> _defendingFleet;

    public BattleField(
        IEnumerable<SpaceShip> attackingFleet,
        IEnumerable<SpaceShip> defendingFleet
    )
    {
        _attackingFleet = attackingFleet;
        _defendingFleet = defendingFleet;
    }

    public (IEnumerable<SpaceShip> attackingFleet, IEnumerable<SpaceShip> defendingFleet) Commit()
    {
        var attackersByInitiative = _attackingFleet.GroupBy(x => x.Initiative);
        var defendersByInitiative = _defendingFleet.GroupBy(x => x.Initiative);
        
        
        
        return (_attackingFleet, new List<SpaceShip>());
    }
}