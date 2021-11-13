using CastleHillGamingPets.Consts;
using CastleHillGamingPets.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using CastleHillGamingPets.Application;

namespace CastleHillGamingPets
{
    class Program
    {
        static AppState app;

        static void Main(string[] args)
        {
            Init();

            Console.WriteLine("Starting Castle Hill Gaming Pets App");
            Console.WriteLine();
            Console.WriteLine("Type help for command list");
            Console.WriteLine();
            Collection();

            while (true)
            {
                Console.WriteLine("");
                Console.Write(">");
                var input = Console.ReadLine();
                var command = Command.ParseFromInput(input);
                HandleCommand(command);
            }
            
        }

        private static void Init()
        {
            var existing = AppStateLoader.LoadState();

            if (existing != null)
            {
                app = existing;
            }
            else
            {
                app = new AppState();
                app.Store = new Store();
                app.Store.Restock();

                app.Pets = new List<Pet>();
            }
        }

        private static void HandleCommand(Command command)
        {
            switch (command.Name.ToLower())
            {
                case CommandNames.Help:
                case CommandAliases.Help:
                    Help();
                    break;
                case CommandNames.Store:
                case CommandAliases.Store:
                    Store();
                    break;
                case CommandNames.Collection:
                case CommandAliases.Collection:
                    Collection();
                    break;
                case CommandNames.Add:
                case CommandAliases.Add:
                    Add(command);
                    break;
                case CommandNames.Remove:
                case CommandAliases.Remove:
                    Remove(command);
                    break;
                case CommandNames.Exit:
                    Exit();
                    break;
                default:
                    Console.WriteLine($"Invalid command: {command.Name}");
                    break;
            }
        }

        private static void Remove(Command command)
        {
            var name = command.GetArg(0);
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("No name specified. Example format is remove spot");
                return;
            }

            var pet = app.Pets.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.InvariantCultureIgnoreCase));
            if (pet == null)
            {
                Console.WriteLine($"No pet with name found: {name}");
            }
            else 
            {
                Console.WriteLine($"Removing {pet.GetType()} {pet.Name}");
                app.Pets.Remove(pet);
                app.TimePasses(TimeCosts.RemovePet);
            }
            
        }

        private static void Collection()
        {
            Console.WriteLine("Your collection:");

            if (!app.Pets.Any())
            {
                Console.WriteLine("Empty; use add command to buy pets");
            }
            
            foreach (var pet in app.Pets)
            {
                Console.WriteLine($"{pet.GetPetType()} {pet.Name} Happiness: {pet.Happiness} Hunger: {pet.Hunger}");
            }
        }

        private static void Add(Command command)
        {
            var petType = command.GetArg(0)?.ToLower();
            var name = command.GetArg(1);
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Pet needs a name. Example format is add dog spot");
                return;
            }
            else if (app.Pets.Any(p => string.Equals(p.Name, name, StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.WriteLine($"Pet name is already in use: {name}");
                return;
            }

            switch (petType) 
            {
                case PetNames.Dog:
                case PetNames.Cat:
                case PetNames.Plant:
                case PetNames.Fish:
                    var pet = app.Store.Buy(petType, name);
                    if (pet == null)
                    {
                        Console.WriteLine($"Unable to buy pet {petType}; store is out of stock.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} added to collection");
                        app.TimePasses(TimeCosts.BuyPet);
                        app.Pets.Add(pet);                        
                    }
                    break;
                default:
                    Console.WriteLine($"Invalid pet type: {petType}");
                    break;
            }
        }

        private static void Store()
        {
            Console.WriteLine("Pets in store:");
            Console.WriteLine($"Dog {app.Store.DogCount}");
            Console.WriteLine($"Cat {app.Store.CatCount}");
            Console.WriteLine($"Plant {app.Store.PlantCount}");
            Console.WriteLine($"Fish {app.Store.FishCount}");
        }

        private static void Exit()
        {
            // possible todo: save state?
            AppStateLoader.SaveState(app);
            Environment.Exit(0);
        }

        private static void Help()
        {
            Console.WriteLine("Command list:");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Store}");
            Console.WriteLine("list pets in store");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Collection}");
            Console.WriteLine("list pets that you own");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Add} (dog|cat|plant|fish) name");
            Console.WriteLine("Add a pet to your collection with the specified type and name");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Remove} name");
            Console.WriteLine("Remove pet with the specified name from your collection");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Exit}");
            Console.WriteLine("save state (maybe) and close app");
        }
    }
}
