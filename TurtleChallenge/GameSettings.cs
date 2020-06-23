using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace Turtle_Challenge
{
    public class GameSettings
    {
        public GameSettings(Point startPoint, Point exit, int height, int width, List<Point> mines)
        {
            StartPoint = startPoint;
            Exit = exit;
            Height = height;
            Width = width;
            Mines = mines;
        }
        [JsonProperty("startPoint")]
        public Point StartPoint { get; set; }

        [JsonProperty("exit")]
        public Point Exit { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("mines")]
        public List<Point> Mines { get; set; }


    }
}