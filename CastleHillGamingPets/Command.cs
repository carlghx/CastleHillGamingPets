using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillGamingPets
{
    public class Command
    {
        public string Name { get; set; }
        private List<string> _args;
        
        private Command(string name, List<string> args)
        {
            Name = name;
            _args = args;
        }

        public static Command ParseFromInput(string input)
        {            
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            var split = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (!split.Any())
            {
                throw new ArgumentException();
            }
            var newCommand = new Command(split[0], split.Skip(1).ToList());
            return newCommand;
        }

        public string GetArg(int index)
        {
            if (_args != null && _args.Count > index)
            {
                return _args[index];
            }

            return null;
        }

        public int ArgCount
        {
            get
            {
                return _args?.Count ?? 0;
            }
        }
    }
}
