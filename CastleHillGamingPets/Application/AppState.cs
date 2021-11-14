using CastleHillGamingPets.Consts;
using CastleHillGamingPets.Pets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CastleHillGamingPets.Application
{
    [Serializable]
    public class AppState
    {
        public Store Store { get; set; }
        public List<Pet> Pets { get; set; }

        public long TimeElapsedMinutes { get; set; }

        public static AppState BuildNewAppState()
        {
            var app = new AppState();
            app.Store = new Store();
            app.Store.Restock();

            app.Pets = new List<Pet>();

            return app;
        }

        public void TimePasses(long minutes)
        {
            Console.WriteLine($"Time passes: {minutes}");
            TimeElapsedMinutes += minutes;

            Store.TimePasses(minutes);

            foreach (var p in Pets)
            {
                p.TimePasses(minutes);
            }
        }

        public Pet FindPetByName(string name)
        {
            return Pets.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        public bool TryBuyPet(string petType, string petName)
        {
            var pet = Store.Buy(petType, petName);
            if (pet == null)
            {
                Console.WriteLine($"Unable to buy pet {petType}; store is out of stock.");
                return false;
            }
            else
            {
                Console.WriteLine($"{petName} added to collection");
                TimePasses(TimeCosts.BuyPet);
                Pets.Add(pet);
                return true;
            }
        }
    }
}
