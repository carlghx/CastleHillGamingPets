using CastleHillGamingPets.Application;
using CastleHillGamingPets.Consts;
using CastleHillGamingPets.Pets;
using System;
using System.Linq;

namespace CastleHillGamingPets
{
    class Program
    {
        static AppState app;

        static void Main(string[] args)
        {
            InitAppState();

            Console.WriteLine("Starting Castle Hill Gaming Pets App");
            Console.WriteLine();
            Console.WriteLine($"Type {CommandNames.Help} for command list");
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

        private static void InitAppState()
        {
            var existing = AppStateLoader.LoadState();

            if (existing != null)
            {
                app = existing;
            }
            else
            {
                app = AppState.BuildNewAppState();
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
                case CommandNames.Feed:
                case CommandAliases.Feed:
                    Feed(command);
                    break;
                case CommandNames.Interact:
                case CommandAliases.Interact:
                    Interact(command);
                    break;
                case CommandNames.Exit:
                    Exit();
                    break;
                default:
                    Console.WriteLine($"Invalid command: {command.Name}");
                    Console.WriteLine($"Type {CommandNames.Help} or {CommandAliases.Help} for commands");
                    break;
            }
        }

        private static void Interact(Command command)
        {
            var intName = command.GetArg(0);
            var petName = command.GetArg(1);
            if (string.IsNullOrEmpty(intName) || string.IsNullOrEmpty(petName))
            {
                Console.WriteLine($"Must specify interaction and pet name. {CommandNames.Interact} {string.Join('|', Enum.GetNames(typeof(eInteraction)))} petname");
                return;
            }

            var pet = app.FindPetByName(petName);
            if (pet == null)
            {
                Console.WriteLine($"No pet with name found: {petName}");
                return;
            }
            if (!Enum.TryParse<eInteraction>(intName, true, out eInteraction interaction))
            {
                Console.WriteLine($"Couldn't use interaction: {intName}. Valid options are {string.Join('|', Enum.GetNames(typeof(eInteraction)))}");
                return;
            }

            if (!pet.TryInteract(interaction))
            {
                Console.WriteLine($"{pet.PetType} {pet.Name} doesn't want to play right now. Try feeding them.");
            }
            app.TimePasses(TimeCosts.InteractPet);
        }


        private static void Feed(Command command)
        {
            var foodName = command.GetArg(0);
            var petName = command.GetArg(1);
            if (string.IsNullOrEmpty(foodName) || string.IsNullOrEmpty(petName))
            {
                Console.WriteLine($"Must specify food and pet name. {CommandNames.Feed} {string.Join('|', Enum.GetNames(typeof(eFood)))} petname");
                return;
            }

            var pet = app.FindPetByName(petName);
            if (pet == null)
            {
                Console.WriteLine($"No pet with name found: {petName}");
                return;
            }
            if (!Enum.TryParse<eFood>(foodName, true, out eFood food))
            {
                Console.WriteLine($"Couldn't use food: {foodName}. Valid options are {string.Join('|', Enum.GetNames(typeof(eFood)))}");
                return;
            }

            pet.Eat(food);
            app.TimePasses(TimeCosts.FeedPet);
        }

        private static void Remove(Command command)
        {
            var name = command.GetArg(0);
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine($"No name specified. Example format is {CommandNames.Remove} spot");
                return;
            }

            var pet = app.FindPetByName(name);
            if (pet == null)
            {
                Console.WriteLine($"No pet with name found: {name}");
            }
            else 
            {
                Console.WriteLine($"Removing {pet.PetType} {pet.Name}");
                app.Pets.Remove(pet);
                app.TimePasses(TimeCosts.RemovePet);
            }
            
        }

        private static void Collection()
        {
            Console.WriteLine("Your collection:");

            if (!app.Pets.Any())
            {
                Console.WriteLine($"Empty; use {CommandNames.Add} command to buy pets");
                return;
            }
            
            foreach (var pet in app.Pets)
            {
                Console.WriteLine($"{pet.PetType} {pet.Name} Happiness: {pet.Happiness} Hunger: {pet.Hunger}");
            }
        }

        private static void Add(Command command)
        {
            var petType = command.GetArg(0)?.ToLower();
            var petName = command.GetArg(1);
            if (string.IsNullOrEmpty(petName))
            {
                Console.WriteLine($"Pet needs a name. Example format is {CommandNames.Add} dog spot");
                return;
            }
            else if (app.FindPetByName(petName) != null)
            {
                Console.WriteLine($"Pet name is already in use: {petName}");
                return;
            }

            switch (petType) 
            {
                case PetNames.Dog:
                case PetNames.Cat:
                case PetNames.Plant:
                case PetNames.Fish:
                    app.TryBuyPet(petType, petName);
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
            AppStateLoader.SaveState(app);
            Environment.Exit(0);
        }

        private static void Help()
        {
            Console.WriteLine("Command list:");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Store}|{CommandAliases.Store}");
            Console.WriteLine("List pets that are available in store");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Collection}|{CommandAliases.Collection}");
            Console.WriteLine("List pets that you own");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Add}|{CommandAliases.Add} (dog|cat|plant|fish) petname");
            Console.WriteLine("Add a pet to your collection with the specified type and name");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Remove}|{CommandAliases.Remove} petname");
            Console.WriteLine("Remove pet with the specified name from your collection");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Feed}|{CommandAliases.Feed} {string.Join('|', Enum.GetNames(typeof(eFood)))} petname");
            Console.WriteLine("Give specified food to the pet with specified name");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Interact}|{CommandAliases.Interact} {string.Join('|', Enum.GetNames(typeof(eInteraction)))} petname");
            Console.WriteLine("Perform the specified interaction on the pet with the specified name");

            Console.WriteLine("");
            Console.WriteLine($"{CommandNames.Exit}");
            Console.WriteLine("Save current state to a local xml file and close app");
        }
    }
}
