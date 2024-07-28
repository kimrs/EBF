namespace Eclipse.Domain.Dice;

public class FixedDie(List<DieRoll> rolls) : IDie
{
    private List<DieRoll>.Enumerator _rollsEnumerator = rolls.GetEnumerator();
    
    public DieRoll Roll()
    {
        if (!_rollsEnumerator.MoveNext())
        {
            _rollsEnumerator = rolls.GetEnumerator();
            _rollsEnumerator.MoveNext();
        }

        return _rollsEnumerator.Current;
    }
}