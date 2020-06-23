using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Turtle_Challenge;

namespace TurtleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var movesContent = File.ReadAllText(@"moves.txt");
            var moves = movesContent.Split(',').Select(char.Parse).ToList();

            var settingsContent = File.ReadAllText(@"game-settings.txt");
            var settings = JsonConvert.DeserializeObject<GameSettings>(settingsContent);

            var game = new Game(settings, moves);
            game.Start();

            Console.ReadLine();
        }
    }
}
