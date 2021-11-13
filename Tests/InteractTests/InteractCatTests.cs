using CastleHillGamingPets.Pets;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FeedTests
{
    [TestFixture]
    public class InteractCatTests
    {

        // happiness 4 hunger 2
        [TestCaseSource(nameof(GetTestCases))]
        public void InteractCat(eInteraction interaction, int happiness, int hunger)
        {
            var pet = new Cat();
            pet.TryInteract(interaction);
            Assert.AreEqual(happiness, pet.Happiness);
            Assert.AreEqual(hunger, pet.Hunger);
        }

        static IEnumerable GetTestCases()
        {
            yield return new TestCaseData(eInteraction.Rub, 2, 4);
            yield return new TestCaseData(eInteraction.Play, 2, 4);
            yield return new TestCaseData(eInteraction.Scold, 2, 4);
            yield return new TestCaseData(eInteraction.Ignore, 5, 3);
            yield return new TestCaseData(eInteraction.Music, 2, 4);
            //yield return new TestCaseData(eInteraction.Pet, 3, 4);
            yield return new TestCaseData(eInteraction.Talk, 2, 4);
            yield return new TestCaseData(eInteraction.Tap, 2, 4);
        }

        [Test]
        public void InteractCat_Pet()
        {
            var cats = new List<Cat>();
            for (int i = 0; i < 100; i++)
            {
                var cat = new Cat();
                cat.TryInteract(eInteraction.Pet);
                cats.Add(cat);
            }

            Assert.IsTrue(cats.Any(c => c.Happiness == 2));
            Assert.IsTrue(cats.Any(c => c.Happiness == 5));
        }
    }
}