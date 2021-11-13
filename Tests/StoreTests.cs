using CastleHillGamingPets.Application;
using CastleHillGamingPets.Consts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class StoreTests
    {
        [Test]
        public void TestTimedRestock()
        {
            var store = new Store();
            
            store.TimePasses(Timers.PetRestock);
            Assert.AreEqual(2, store.DogCount);
            Assert.AreEqual(2, store.CatCount);
            Assert.AreEqual(2, store.PlantCount);
            Assert.AreEqual(2, store.FishCount);

            store.TimePasses(Timers.PetRestock);
            Assert.AreEqual(4, store.DogCount);
            Assert.AreEqual(4, store.CatCount);
            Assert.AreEqual(4, store.PlantCount);
            Assert.AreEqual(4, store.FishCount);

            store.TimePasses(Timers.PetRestock - 1);
            Assert.AreEqual(4, store.DogCount);
            Assert.AreEqual(4, store.CatCount);
            Assert.AreEqual(4, store.PlantCount);
            Assert.AreEqual(4, store.FishCount);
        }

        [Test]
        public void TestBadTime()
        {
            var store = new Store();

            Assert.Throws<ArgumentException>(() => store.TimePasses(-1));
        }

        [Test]
        public void TestBuyoutDogs()
        {
            var store = new Store();
            store.Restock();

            var pet = store.Buy(PetNames.Dog, "test");
            Assert.AreEqual(1, store.DogCount);
            Assert.NotNull(pet);

            pet = store.Buy(PetNames.Dog, "test");
            Assert.AreEqual(0, store.DogCount);
            Assert.NotNull(pet);

            pet = store.Buy(PetNames.Dog, "test");
            Assert.AreEqual(0, store.DogCount);
            Assert.IsNull(pet);
        }

        [Test]
        public void TestBuyoutCats()
        {
            var store = new Store();
            store.Restock();

            var pet = store.Buy(PetNames.Cat, "test");
            Assert.AreEqual(1, store.CatCount);
            Assert.NotNull(pet);

            pet = store.Buy(PetNames.Cat, "test");
            Assert.AreEqual(0, store.CatCount);
            Assert.NotNull(pet);

            pet = store.Buy(PetNames.Cat, "test");
            Assert.AreEqual(0, store.CatCount);
            Assert.IsNull(pet);
        }

        [Test]
        public void TestBuyoutPlant()
        {
            var store = new Store();
            store.Restock();

            var pet = store.Buy(PetNames.Plant, "test");
            Assert.AreEqual(1, store.PlantCount);
            Assert.NotNull(pet);

            pet = store.Buy(PetNames.Plant, "test");
            Assert.AreEqual(0, store.PlantCount);
            Assert.NotNull(pet);

            pet = store.Buy(PetNames.Plant, "test");
            Assert.AreEqual(0, store.PlantCount);
            Assert.IsNull(pet);
        }

        [Test]
        public void TestBuyoutFish()
        {
            var store = new Store();
            store.Restock();

            var pet = store.Buy(PetNames.Fish, "test");
            Assert.AreEqual(1, store.FishCount);
            Assert.NotNull(pet);

            pet = store.Buy(PetNames.Fish, "test");
            Assert.AreEqual(0, store.FishCount);
            Assert.NotNull(pet);

            pet = store.Buy(PetNames.Fish, "test");
            Assert.AreEqual(0, store.FishCount);
            Assert.IsNull(pet);
        }

    }
}
