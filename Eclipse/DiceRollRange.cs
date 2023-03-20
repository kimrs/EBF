using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse;

public record DiceRollRange
{
    public DiceRoll Value { get; init; }

    public DiceRollRange(DiceRoll diceRoll)
    {
        Value = diceRoll.Value switch
        {
            < 2 => new DiceRoll(2),
            _ => diceRoll
        };
    }

    public bool IsWithinRange(DiceRoll diceRoll)
    {
        return Value <= diceRoll;
    }
}
