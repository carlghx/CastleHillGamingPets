using CastleHillGamingPets.Pets;
using NUnit.Framework;
using System.Collections;

namespace Tests.FeedTests
{
    [TestFixture]
    public class FeedDogTests
    {

        // happiness 5 hunger 2
        [TestCaseSource(nameof(GetTestCases))]
        public void FeedDog(eFood food, int happiness, int hunger)
        {
            var pet = new Dog();
            pet.Eat(food);
            Assert.AreEqual(happiness, pet.Happiness);
            Assert.AreEqual(hunger, pet.Hunger);
        }

        static IEnumerable GetTestCases()
        {
            yield return new TestCaseData(eFood.Bacon, 6, 1);
            yield return new TestCaseData(eFood.DogFood, 6, 0);
            yield return new TestCaseData(eFood.CatFood, 3, 4);
            yield return new TestCaseData(eFood.FishFood, 3, 4);
            yield return new TestCaseData(eFood.PlantFood, 3, 4);
            yield return new TestCaseData(eFood.Tuna, 3, 4);
            yield return new TestCaseData(eFood.Water, 3, 4);
        }

        [Test]
        public void FeedHungryDogBacon()
        {
            var pet = new Dog();
            pet.Hunger = 10;
            pet.Eat(eFood.Bacon);
            Assert.AreEqual(5, pet.Hunger);
        }

        [Test]
        public void OverfeedDog()
        {
            var pet = new Dog();
            for (int i = 0; i < 100; i++)
            {
                pet.Eat(eFood.DogFood);
            }

            Assert.AreEqual(pet.MaxHappiness, pet.Happiness);
        }
    }
}