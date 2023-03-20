using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse;

public record SpaceShip
{
    public Initiative Initiative { get; }
    public Computer Computer { get; }
    public Shield Shield { get; }
    public int Hull { get; init; }
    public List<Cannon> Cannons { get; }

    public SpaceShip(List<Cannon> cannons, IReadOnlyCollection<ShipPart> shipParts)
    {
        Cannons = cannons;

        Initiative = new Initiative(shipParts.Sum(p => p.Initiative.Value));
        Computer = new Computer(shipParts.Sum(p => p.Computer.Value));
        Shield = new Shield(shipParts.Sum(p => p.Shield.Value));
        Hull = shipParts.Sum(p => p.Hull);
    }

    public SpaceShip Attack(SpaceShip target)
    {
        var difference = Computer.Value - target.Shield.Value;
        var minimumSuccessfulDiceRoll = 6 - difference;
        var diceRollRange = new DiceRollRange(new DiceRoll(minimumSuccessfulDiceRoll));
        var fireResult = Cannons.Select(x => x.Fire(diceRollRange))
            .OfType<Damage>()
            .Sum(x => x.Value);

        return target with { Hull = target.Hull - fireResult, };
    }
}
