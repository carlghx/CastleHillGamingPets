using CastleHillGamingPets.Pets;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FeedTests
{
    [TestFixture]
    public class InteractFishTests
    {

        // happiness 2 hunger 2
        [TestCaseSource(nameof(GetTestCases))]
        public void InteractFish(eInteraction interaction, int happiness, int hunger)
        {
            var pet = new Fish();
            pet.TryInteract(interaction);
            Assert.AreEqual(happiness, pet.Happiness);
            Assert.AreEqual(hunger, pet.Hunger);
        }

        static IEnumerable GetTestCases()
        {
            yield return new TestCaseData(eInteraction.Rub, 0, 4);
            yield return new TestCaseData(eInteraction.Play, 0, 4);
            yield return new TestCaseData(eInteraction.Scold, 0, 4);
            yield return new TestCaseData(eInteraction.Ignore, 0, 4);
            yield return new TestCaseData(eInteraction.Music, 3, 3);
            yield return new TestCaseData(eInteraction.Pet, 0, 4);
            yield return new TestCaseData(eInteraction.Talk, 3, 3);
            yield return new TestCaseData(eInteraction.Tap, 0, 5);
        }

    }
}