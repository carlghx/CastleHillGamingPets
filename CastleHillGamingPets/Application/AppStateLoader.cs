using System;
using System.IO;
using System.Xml.Serialization;

namespace CastleHillGamingPets.Application
{
    public class AppStateLoader
    {
        public const string FileName = "gamestate.xml";

        public static void SaveState(AppState app)
        {
            try
            {
                var path = Path.Combine(Environment.CurrentDirectory, FileName);
                var serializer = new XmlSerializer(typeof(AppState));
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    serializer.Serialize(stream, app);
                    Console.WriteLine($"State saved to: {path}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving state: " + ex);
            }
        }

        public static AppState LoadState()
        {
            try
            {
                var path = Path.Combine(Environment.CurrentDirectory, FileName);
                var serializer = new XmlSerializer(typeof(AppState));
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var app = (AppState)serializer.Deserialize(stream);
                    if (app != null) 
                    {
                        Console.WriteLine($"Existing state found at: {path}");
                        return app;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load pre-existing state; starting fresh.");
            }

            return null;
        }
    }
}
