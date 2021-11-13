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
            MaxHappiness = 5;
            HungerThreshold = 5;            

            Happiness = 2;
            Hunger = 2;            
        }

        public override string PetType => "Fish";

        public override void Eat(eFood food)
        {
            switch (food)
            {
                case eFood.FishFood:
                    Hunger = 0;
                    Happiness++;
                    Console.WriteLine($"{PetType} {Name} likes {food}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                default:
                    Hunger += 2;
                    Happiness -= 2;
                    Console.WriteLine($"{PetType} {Name} dislikes {food}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
            }
        }

        public override bool Interact(eInteraction interaction)
        {
            return true;
        }

    }
}
