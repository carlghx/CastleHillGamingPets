using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillGamingPets.Pets
{
    public class Dog : Pet
    {
        protected override long TimerInterval => 2;

        public Dog()
        {
            HungerThreshold = 10;
            MaxHappiness = 10;
            Hunger = 2;
            Happiness = 5;
        }

        public override string GetPetType => "Dog";

        public override void Eat(eFood food)
        {
        }


        public override void Interact(eInteraction interaction)
        {
        }

    }
}
