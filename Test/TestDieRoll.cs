using Eclipse.Domain;
using Eclipse.Domain.Dice;
using FluentAssertions;

namespace Eclipse.Test
{
    public class TestDieRoll
    {
        [Fact]
        public void DiceRollsShouldBeUniformlyDistributedWhenRolling72Dice()
        {
            var dice = new Die();
            var rolls = new List<DieRoll>(72);
            for(var i = 0; i < 72; i++) { rolls.Add(dice.Roll()); }

            rolls.Where(x => x == new DieRoll(1)).Should().HaveCount(12);
            rolls.Where(x => x == new DieRoll(2)).Should().HaveCount(12);
            rolls.Where(x => x == new DieRoll(3)).Should().HaveCount(12);
            rolls.Where(x => x == new DieRoll(4)).Should().HaveCount(12);
            rolls.Where(x => x == new DieRoll(5)).Should().HaveCount(12);
            rolls.Where(x => x == new DieRoll(6)).Should().HaveCount(12);
        }

        [Fact]
        public void DiceRollsShouldBeUniformlyDistributedWhenRolling144Dice()
        {
            var dice = new Die();
            var rolls = new List<DieRoll>(144);
            for(var i = 0; i < 144; i++) { rolls.Add(dice.Roll()); }

            rolls.Where(x => x == new DieRoll(1)).Should().HaveCount(24);
            rolls.Where(x => x == new DieRoll(2)).Should().HaveCount(24);
            rolls.Where(x => x == new DieRoll(3)).Should().HaveCount(24);
            rolls.Where(x => x == new DieRoll(4)).Should().HaveCount(24);
            rolls.Where(x => x == new DieRoll(5)).Should().HaveCount(24);
            rolls.Where(x => x == new DieRoll(6)).Should().HaveCount(24);
        }
    }
}