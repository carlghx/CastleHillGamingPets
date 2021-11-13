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
            MaxHappiness = 5;
            HungerThreshold = 6;            

            Happiness = 2;
            Hunger = 5;                      
        }

        public override string PetType => "Plant";

        public override void Eat(eFood food)
        {
            switch (food)
            {
                case eFood.Water:
                    Hunger = Hunger / 2;
                    Happiness++;
                    Console.WriteLine($"{PetType} {Name} likes {food}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                case eFood.PlantFood:
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
