using CastleHillGamingPets.Application;
using System;

namespace CastleHillGamingPets.Pets
{
    public class Cat : Pet
    {
        protected override long TimerInterval => 2;

        public Cat()
        {
            MaxHappiness = 5;
            HungerThreshold = 8;            

            Happiness = 4;
            Hunger = 2;            
        }

        public override string PetType => "Cat";

        public override void Eat(eFood food)
        {
            switch (food)
            {
                case eFood.CatFood:
                    Hunger = Hunger / 2;
                    Happiness++;
                    Console.WriteLine($"{PetType} {Name} likes {food}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                case eFood.Tuna:
                    Hunger = 0;
                    Happiness += 3;
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
                case eInteraction.Pet:
                    LolCat();
                    break;
                case eInteraction.Ignore:
                    Hunger++;
                    Happiness += 2;
                    Console.WriteLine($"{PetType} {Name} likes {interaction}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                case eInteraction.Scold:
                    Hunger += 2;
                    Happiness -= 2;
                    Console.WriteLine($"{PetType} {Name} responds to {interaction}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                default:
                    Hunger += 2;
                    Happiness -= 2;
                    Console.WriteLine($"{PetType} {Name} dislikes {interaction}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
            }
        }

        private void LolCat()
        {
            var rand = RNG.Random.Next(100);
            if (rand > 50)
            {
                Console.WriteLine($"{PetType} {Name} randomly likes you. Happiness {Happiness} and Hunger {Hunger}");
                Hunger++;
                Happiness++;
            }
            else
            {
                Console.WriteLine($"{PetType} {Name} randomly dislikes you. Happiness {Happiness} and Hunger {Hunger}");
                Hunger += 2;
                Happiness -= 2;
            }
        }
    }
}
