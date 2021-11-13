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

        public override bool Interact(eInteraction interaction)
        {
            return true;
        }

    }
}
