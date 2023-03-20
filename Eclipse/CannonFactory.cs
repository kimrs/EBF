using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse;

public class CannonFactory
{
    private readonly Dice _dice;

    public CannonFactory(Dice dice)
    {
        _dice = dice;
    }

    public Cannon Create(Damage damage)
        => new (_dice, damage);
}
