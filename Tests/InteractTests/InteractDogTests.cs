using CastleHillGamingPets.Pets;
using NUnit.Framework;
using System.Collections;

namespace Tests.FeedTests
{
    [TestFixture]
    public class InteractDogTests
    {
        Pet pet;
        [SetUp]
        public void SetUp()
        {
            pet = new Dog();
        }


        // happiness 5 hunger 2
        [TestCaseSource(nameof(GetTestCases))]
        public void InteractDog(eInteraction interaction, int happiness, int hunger)
        {
            pet.TryInteract(interaction);
            Assert.AreEqual(happiness, pet.Happiness);
            Assert.AreEqual(hunger, pet.Hunger);
        }

        static IEnumerable GetTestCases()
        {
            yield return new TestCaseData(eInteraction.Rub, 6, 3);
            yield return new TestCaseData(eInteraction.Play, 7, 5);
            yield return new TestCaseData(eInteraction.Scold, 3, 4);
            yield return new TestCaseData(eInteraction.Ignore, 3, 4);
            yield return new TestCaseData(eInteraction.Music, 3, 4);
            yield return new TestCaseData(eInteraction.Pet, 3, 4);
            yield return new TestCaseData(eInteraction.Talk, 3, 4);
            yield return new TestCaseData(eInteraction.Tap, 3, 4);
        }

        [Test]
        public void TryInteract_Hungry()
        {
            pet.Hunger = pet.HungerThreshold + 1;
            var result = pet.TryInteract(eInteraction.Rub);
            Assert.AreEqual(false, result);
            Assert.AreEqual(pet.HungerThreshold + 1, pet.Hunger);
            Assert.AreEqual(5, pet.Happiness);
        }

        [Test]
        public void TryInteract_AlmostHungry()
        {
            pet.Hunger = pet.HungerThreshold;
            var result = pet.TryInteract(eInteraction.Rub);
            Assert.AreEqual(true, result);
            Assert.AreEqual(pet.HungerThreshold + 1, pet.Hunger);
            Assert.AreEqual(6, pet.Happiness);
        }

        [Test]
        public void TryInteract_Unhappy()
        {
            pet.Happiness = 0;
            var result = pet.TryInteract(eInteraction.Rub);
            Assert.AreEqual(false, result);
            Assert.AreEqual(0, pet.Happiness);
            Assert.AreEqual(2, pet.Hunger);
        }
    }
}