using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillGamingPets.Pets
{
    public class Cat : Pet
    {
        protected override long TimerInterval => 2;

        public Cat()
        {
            HungerThreshold = 8;
            MaxHappiness = 5;
            Hunger = 2;
            Happiness = 4;
        }

        public override string GetPetType()
        {
            return "Cat";
        }

        public override void Eat(eFood food)
        {
        }

        public override void Interact(eInteraction interaction)
        {
        }

    }
}
