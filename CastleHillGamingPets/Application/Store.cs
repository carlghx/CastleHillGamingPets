using CastleHillGamingPets.Consts;
using CastleHillGamingPets.Pets;
using System;

namespace CastleHillGamingPets.Application
{
    [Serializable]
    public class Store
    {
        public int DogCount { get; set; }
        public int CatCount { get; set; }
        public int PlantCount { get; set; }
        public int FishCount { get; set; }

        private long TimeSinceLastRestock;

        public Store()
        {
        }

        public void Restock()
        {
            Console.WriteLine("Restocking the store");
            DogCount += 2;
            CatCount += 2;
            PlantCount += 2;
            FishCount += 2;
        }

        // not handled: transactions / being able to rollback on failure
        public Pet Buy(string petType, string name)
        {
            switch (petType)
            {
                case PetNames.Dog:
                    if (DogCount > 0)
                    {
                        DogCount--;
                        Console.WriteLine($"Adding a {PetNames.Dog}. Store has {DogCount} left.");
                        return new Dog()
                        {
                            Name = name
                        };
                    }
                    break;
                case PetNames.Cat:
                    if (CatCount > 0)
                    {
                        CatCount--;
                        Console.WriteLine($"Adding a {PetNames.Cat}. Store has {CatCount} left.");
                        return new Cat()
                        {
                            Name = name
                        };
                    }
                    break;
                case PetNames.Plant:
                    if (PlantCount > 0)
                    {
                        PlantCount--;
                        Console.WriteLine($"Adding a {PetNames.Plant}. Store has {PlantCount} left.");
                        return new Plant()
                        {
                            Name = name
                        };
                    }
                    break;
                case PetNames.Fish:
                    if (FishCount > 0)
                    {
                        FishCount--;
                        Console.WriteLine($"Adding a {PetNames.Fish}. Store has {FishCount} left.");
                        return new Fish()
                        {
                            Name = name
                        };
                    }
                    break;
            }

            return null;
        }

        public void TimePasses(long minutes)
        {
            if (minutes < 0)
            {
                throw new ArgumentException();
            }
            TimeSinceLastRestock += minutes;
            if (TimeSinceLastRestock >= Timers.PetRestock)
            {
                TimeSinceLastRestock = 0;
                Restock();
            }
        }
    }
}
