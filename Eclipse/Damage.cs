using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse;

public interface IDamage
{
    int Value { get; }
}

public record Damage : IDamage
{
    public int Value { get; init; }

    public Damage(int value)
    {
        Value = value < 1 ? 1 : value > 4 ? 4 : value;
    }
}

public record NoDamage : IDamage
{
    public int Value => 0;
}
