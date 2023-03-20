using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse;

public record Shield
{
    public int Value { get; init; }

    public Shield(int value)
    {
        Value = value switch
        {
            < 0 or > 10 => throw new ArgumentOutOfRangeException(nameof(value), "Shield value must be between 0 and 10."),
            _ => value
        };
    }
}
