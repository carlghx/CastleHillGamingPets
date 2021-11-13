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

        protected override void Interact(eInteraction interaction)
        {
            switch (interaction)
            {
                case eInteraction.Talk:
                    Hunger++;
                    Happiness++;
                    Console.WriteLine($"{PetType} {Name} likes {interaction}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                case eInteraction.Music:
                    Hunger++;
                    Happiness += 2;
                    Console.WriteLine($"{PetType} {Name} likes {interaction}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                case eInteraction.Ignore:
                    Hunger += 3;
                    Happiness -= 3;
                    Console.WriteLine($"{PetType} {Name} responds to {interaction}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                default:
                    Hunger += 2;
                    Happiness -= 2;
                    Console.WriteLine($"{PetType} {Name} dislikes {interaction}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
            }
        }
    }
}
