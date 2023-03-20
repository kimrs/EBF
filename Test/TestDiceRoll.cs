using Eclipse;
using FluentAssertions;

namespace Test
{
    public class TestDiceRoll
    {
        [Fact]
        public void DiceRollsShouldBeUniformlyDistributedWhenRolling72Dice()
        {
            var dice = new Dice();
            var rolls = new List<DiceRoll>(72);
            for(var i = 0; i < 72; i++) { rolls.Add(dice.Roll()); }

            rolls.Where(x => x == new DiceRoll(1)).Should().HaveCount(12);
            rolls.Where(x => x == new DiceRoll(2)).Should().HaveCount(12);
            rolls.Where(x => x == new DiceRoll(3)).Should().HaveCount(12);
            rolls.Where(x => x == new DiceRoll(4)).Should().HaveCount(12);
            rolls.Where(x => x == new DiceRoll(5)).Should().HaveCount(12);
            rolls.Where(x => x == new DiceRoll(6)).Should().HaveCount(12);
        }

        [Fact]
        public void DiceRollsShouldBeUniformlyDistributedWhenRolling144Dice()
        {
            var dice = new Dice();
            var rolls = new List<DiceRoll>(144);
            for(var i = 0; i < 144; i++) { rolls.Add(dice.Roll()); }

            rolls.Where(x => x == new DiceRoll(1)).Should().HaveCount(24);
            rolls.Where(x => x == new DiceRoll(2)).Should().HaveCount(24);
            rolls.Where(x => x == new DiceRoll(3)).Should().HaveCount(24);
            rolls.Where(x => x == new DiceRoll(4)).Should().HaveCount(24);
            rolls.Where(x => x == new DiceRoll(5)).Should().HaveCount(24);
            rolls.Where(x => x == new DiceRoll(6)).Should().HaveCount(24);
        }
    }
}