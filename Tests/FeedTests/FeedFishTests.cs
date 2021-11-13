using CastleHillGamingPets.Pets;
using NUnit.Framework;
using System.Collections;

namespace Tests.FeedTests
{
    [TestFixture]
    public class FeedFishTests
    {

        // happiness 2 hunger 2
        [TestCaseSource(nameof(GetTestCases))]
        public void FeedFish(eFood food, int happiness, int hunger)
        {
            var pet = new Fish();
            pet.Eat(food);
            Assert.AreEqual(happiness, pet.Happiness);
            Assert.AreEqual(hunger, pet.Hunger);
        }

        static IEnumerable GetTestCases()
        {
            yield return new TestCaseData(eFood.Bacon, 0, 4);
            yield return new TestCaseData(eFood.DogFood, 0, 4);
            yield return new TestCaseData(eFood.CatFood, 0, 4);
            yield return new TestCaseData(eFood.FishFood, 3, 0);
            yield return new TestCaseData(eFood.PlantFood, 0, 4);
            yield return new TestCaseData(eFood.Tuna, 0, 4);
            yield return new TestCaseData(eFood.Water, 0, 4);
        }

        [Test]
        public void OverfeedFish()
        {
            var pet = new Fish();
            for (int i = 0; i < 100; i++)
            {
                pet.Eat(eFood.FishFood);
            }

            Assert.AreEqual(pet.MaxHappiness, pet.Happiness);
        }
    }
}