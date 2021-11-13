using CastleHillGamingPets.Pets;
using NUnit.Framework;
using System.Collections;

namespace Tests.FeedTests
{
    [TestFixture]
    public class FeedPlantTests
    {

        // happiness 2 hunger 5
        [TestCaseSource(nameof(GetTestCases))]
        public void FeedPlant(eFood food, int happiness, int hunger)
        {
            var pet = new Plant();
            pet.Eat(food);
            Assert.AreEqual(happiness, pet.Happiness);
            Assert.AreEqual(hunger, pet.Hunger);
        }

        static IEnumerable GetTestCases()
        {
            yield return new TestCaseData(eFood.Bacon, 0, 7);
            yield return new TestCaseData(eFood.DogFood, 0, 7);
            yield return new TestCaseData(eFood.CatFood, 0, 7);
            yield return new TestCaseData(eFood.FishFood, 0, 7);
            yield return new TestCaseData(eFood.PlantFood, 3, 0);
            yield return new TestCaseData(eFood.Tuna, 0, 7);
            yield return new TestCaseData(eFood.Water, 3, 2);
        }

        [Test]
        public void FeedHungryPlantFood()
        {
            var pet = new Plant();
            pet.Hunger = 10;
            pet.Eat(eFood.Water);
            Assert.AreEqual(5, pet.Hunger);
        }

        [Test]
        public void OverfeedPlant()
        {
            var pet = new Plant();
            for (int i = 0; i < 100; i++)
            {
                pet.Eat(eFood.Water);
            }

            Assert.AreEqual(pet.MaxHappiness, pet.Happiness);
        }
    }
}