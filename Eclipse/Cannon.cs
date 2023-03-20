using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace Eclipse;

public record Cannon(
    Dice Dice,
    Damage Damage
)
{
    public IDamage Fire(DiceRollRange range)
    {
        return range.IsWithinRange(Dice.Roll()) ? Damage : new NoDamage();
    }
}
