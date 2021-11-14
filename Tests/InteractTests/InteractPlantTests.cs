using CastleHillGamingPets.Pets;
using NUnit.Framework;
using System.Collections;

namespace Tests.FeedTests
{
    [TestFixture]
    public class InteractPlantTests
    {

        // happiness 2 hunger 5
        [TestCaseSource(nameof(GetTestCases))]
        public void InteractPlant(eInteraction interaction, int happiness, int hunger)
        {
            var pet = new Plant();
            pet.TryInteract(interaction);
            Assert.AreEqual(happiness, pet.Happiness);
            Assert.AreEqual(hunger, pet.Hunger);
        }

        static IEnumerable GetTestCases()
        {
            yield return new TestCaseData(eInteraction.Rub, 0, 7);
            yield return new TestCaseData(eInteraction.Play, 0, 7);
            yield return new TestCaseData(eInteraction.Scold, 0, 7);
            yield return new TestCaseData(eInteraction.Ignore, -1, 8);
            yield return new TestCaseData(eInteraction.Music, 4, 6);
            yield return new TestCaseData(eInteraction.Pet, 0, 7);
            yield return new TestCaseData(eInteraction.Talk, 3, 6);
            yield return new TestCaseData(eInteraction.Tap, 0, 7);
        }

    }
}