using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillGamingPets.Pets
{
    public class Fish : Pet
    {
        protected override long TimerInterval => 3;

        public Fish()
        {
            HungerThreshold = 5;
            MaxHappiness = 5;
            Hunger = 2;
            Happiness = 2;
        }

        public override string GetPetType()
        {
            return "Fish";
        }

        public override void Eat(eFood food)
        {
        }

        public override void Interact(eInteraction interaction)
        {
        }

    }
}
