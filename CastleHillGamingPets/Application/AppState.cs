using CastleHillGamingPets.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillGamingPets.Application
{
    [Serializable]
    public class AppState
    {
        public Store Store { get; set; }
        public List<Pet> Pets { get; set; }

        public long TimeElapsedMinutes { get; set; }

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
    }
}
