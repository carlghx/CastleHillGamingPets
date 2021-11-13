using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleHillGamingPets.Pets
{
    public class Dog : Pet
    {
        protected override long TimerInterval => 2;
        public override string PetType => "Dog";

        public Dog()
        {
            MaxHappiness = 10;
            HungerThreshold = 10;            
            
            Happiness = 5;
            Hunger = 2;            
        }

        public override void Eat(eFood food)
        {
            switch (food)
            {
                case eFood.Bacon:
                    Hunger = Hunger / 2;
                    Happiness++;
                    Console.WriteLine($"{PetType} {Name} likes {food}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                case eFood.DogFood:
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
                case eInteraction.Rub:
                    Hunger++;
                    Happiness++;
                    Console.WriteLine($"{PetType} {Name} likes {interaction}. Happiness {Happiness} and Hunger {Hunger}");
                    break;
                case eInteraction.Play:
                    Hunger += 3;
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

    }
}
