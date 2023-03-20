using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse;

public record Computer
{
    public int Value { get; init; }

    public Computer(int value)
    {
        Value = value switch
        {
            < 0 or > 10 => throw new ArgumentOutOfRangeException(nameof(value), "Computer value must be between 0 and 10."),
            _ => value
        };
    }
}
