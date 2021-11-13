using CastleHillGamingPets.Pets;
using NUnit.Framework;
using System.Collections;

namespace Tests.FeedTests
{
    [TestFixture]
    public class FeedCatTests
    {

        // happiness 4 hunger 2
        [TestCaseSource(nameof(GetTestCases))]
        public void FeedCat(eFood food, int happiness, int hunger)
        {
            var pet = new Cat();
            pet.Eat(food);
            Assert.AreEqual(happiness, pet.Happiness);
            Assert.AreEqual(hunger, pet.Hunger);
        }

        static IEnumerable GetTestCases()
        {
            yield return new TestCaseData(eFood.Bacon, 2, 4);
            yield return new TestCaseData(eFood.DogFood, 2, 4);
            yield return new TestCaseData(eFood.CatFood, 5, 1);
            yield return new TestCaseData(eFood.FishFood, 2, 4);
            yield return new TestCaseData(eFood.PlantFood, 2, 4);
            yield return new TestCaseData(eFood.Tuna, 5, 0);
            yield return new TestCaseData(eFood.Water, 2, 4);
        }

        [Test]
        public void FeedHungryCatFood()
        {
            var pet = new Cat();
            pet.Hunger = 10;
            pet.Eat(eFood.CatFood);
            Assert.AreEqual(5, pet.Hunger);
        }

        [Test]
        public void OverfeedCat()
        {
            var pet = new Cat();
            for (int i = 0; i < 100; i++)
            {
                pet.Eat(eFood.CatFood);
            }

            Assert.AreEqual(pet.MaxHappiness, pet.Happiness);
        }

        [Test]
        public void FeedSadCatTuna()
        {
            var pet = new Cat();
            pet.Happiness = 0;
            pet.Eat(eFood.Tuna);
            Assert.AreEqual(3, pet.Happiness);
        }


    }
}