using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillGamingPets.Pets
{
    public class Plant : Pet
    {
        protected override long TimerInterval => 1;

        public Plant()
        {
            HungerThreshold = 6;
            MaxHappiness = 5;
            Hunger = 5;
            Happiness = 2;            
        }

        public override string GetPetType => "Plant";

        public override void Eat(eFood food)
        {
        }

        public override void Interact(eInteraction interaction)
        {
        }
    }
}
