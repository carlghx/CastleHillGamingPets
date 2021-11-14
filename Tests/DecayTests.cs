using CastleHillGamingPets.Pets;
using NUnit.Framework;

namespace Tests.FeedTests
{
    [TestFixture]
    public class DecayTests
    {
        [Test]
        public void TimeDog_2Minutes()
        {
            var pet = new Dog();

            pet.TimePasses(1);
            Assert.AreEqual(5, pet.Happiness);
            Assert.AreEqual(2, pet.Hunger);

            pet.TimePasses(1);
            Assert.AreEqual(4, pet.Happiness);
            Assert.AreEqual(3, pet.Hunger);

            pet.TimePasses(2);
            Assert.AreEqual(3, pet.Happiness);
            Assert.AreEqual(4, pet.Hunger);
        }

        [Test]
        public void TimeCat_2Minutes()
        {
            var pet = new Cat();

            pet.TimePasses(1);
            Assert.AreEqual(4, pet.Happiness);
            Assert.AreEqual(2, pet.Hunger);

            pet.TimePasses(1);
            Assert.AreEqual(3, pet.Happiness);
            Assert.AreEqual(3, pet.Hunger);

            pet.TimePasses(2);
            Assert.AreEqual(2, pet.Happiness);
            Assert.AreEqual(4, pet.Hunger);
        }

        [Test]
        public void TimePlant_1Minute()
        {
            var pet = new Plant();

            pet.TimePasses(1);
            Assert.AreEqual(1, pet.Happiness);
            Assert.AreEqual(6, pet.Hunger);

            pet.TimePasses(1);
            Assert.AreEqual(0, pet.Happiness);
            Assert.AreEqual(7, pet.Hunger);

            pet.TimePasses(2);
            Assert.AreEqual(-2, pet.Happiness);
            Assert.AreEqual(9, pet.Hunger);
        }

        [Test]
        public void TimeFish_3Minutes()
        {
            var pet = new Fish();

            pet.TimePasses(1);
            Assert.AreEqual(2, pet.Happiness);
            Assert.AreEqual(2, pet.Hunger);

            pet.TimePasses(1);
            Assert.AreEqual(2, pet.Happiness);
            Assert.AreEqual(2, pet.Hunger);

            pet.TimePasses(1);
            Assert.AreEqual(1, pet.Happiness);
            Assert.AreEqual(3, pet.Hunger);

            pet.TimePasses(3);
            Assert.AreEqual(0, pet.Happiness);
            Assert.AreEqual(4, pet.Hunger);
        }
    }
}