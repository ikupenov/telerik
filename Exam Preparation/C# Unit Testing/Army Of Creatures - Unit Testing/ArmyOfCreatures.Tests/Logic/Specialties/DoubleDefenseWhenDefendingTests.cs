namespace ArmyOfCreatures.Tests.Logic.Specialties
{
    using System;

    using NUnit.Framework;

    using Moq;

    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Battles;

    [TestFixture]
    public class DoubleDefenseWhenDefendingTests
    {
        [Test]
        public void ApplyWhenDefending_ShouldThrowArgumentNullException_IfDefenderIsNull()
        {
            var rounds = 5;
            var specialty = new DoubleDefenseWhenDefending(rounds);

            var attacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() =>
            specialty.ApplyWhenDefending(null, attacker.Object));
        }

        [Test]
        public void ApplyWhenDefending_ShouldThrowArgumentNullException_IfAttackerIsNull()
        {
            var rounds = 5;
            var specialty = new DoubleDefenseWhenDefending(rounds);

            var defender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() =>
            specialty.ApplyWhenDefending(defender.Object, null));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void ApplyWhenDefending_ShouldReturnAndNotChangeCurrentDefenseProperty_WhenTheEffectIsExpired(int rounds)
        {
            var specialty = new DoubleDefenseWhenDefending(rounds);

            var attacker = new Mock<ICreaturesInBattle>();

            var defender = new Mock<ICreaturesInBattle>();
            defender.Setup(x => x.CurrentDefense).Returns(It.IsAny<int>());

            for (int i = 0; i < rounds * 2; i++)
            {
                specialty.ApplyWhenDefending(defender.Object, attacker.Object);
            }

            defender.VerifySet(x => x.CurrentDefense = It.IsAny<int>(), Times.Exactly(rounds));
        }

        [Test]
        public void ApplyWhenDefending_ShouldMultiplyByTwoCurrentDefenseProperty_WhenEffectHasNotExpired()
        {
            var rounds = 5;
            var defense = 10;
            var specialty = new DoubleDefenseWhenDefending(rounds);

            var attacker = new Mock<ICreaturesInBattle>();

            var defender = new Mock<ICreaturesInBattle>();
            defender.SetupGet(x => x.CurrentDefense).Returns(defense);

            var currDefense = defender.Object.CurrentDefense;

            specialty.ApplyWhenDefending(defender.Object, attacker.Object);

            defender.VerifySet(x => x.CurrentDefense = defense * 2);
        }
    }
}
