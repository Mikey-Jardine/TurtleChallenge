using System;
using System.Collections.Generic;
using System.Drawing;
using TurtleChallenge.Interfaces;

namespace Turtle_Challenge
{
    public class Turtle : ITurtle
    {
        public Turtle(Point startPoint, int directionId)
        {
            Alive = true;
            DirectionId = directionId;
            StartPoint = startPoint;
            SetDirection();
        }

        public Point StartPoint { get; set; }
        public Point CurrentSquare { get; set; }
        public Point PreviousSquare { get; set; }
        public Point NextSquare { get; set; }
        private int DirectionId { get; set; }
        public Direction Direction { get; set; }
        public bool Alive { get; set; }
        public bool HasGameEnded { get; set; }

        private static readonly Dictionary<int, Direction> _directions = new Dictionary<int, Direction>()
        {
            { 0, new North()},
            { 1, new East() },
            { 2, new South()},
            { 3, new West() }
        };

        public void Move()
        {
            PreviousSquare = CurrentSquare;
            CurrentSquare = NextSquare;
            SetNextSquare(CurrentSquare);

            Console.WriteLine($"Moved to square: {CurrentSquare.X} {CurrentSquare.Y}");
        }

        public void Rotate()
        {
            if (DirectionId >= 3)
            {
                DirectionId = 0;
                return;
            }

            DirectionId++;
            SetDirection();
        }

        private void SetNextSquare(Point currentSquare)
        {
            NextSquare = Direction.SetUpNextSquare(currentSquare);
        }

        private void SetDirection()
        {
            if(!_directions.ContainsKey(DirectionId))
            {
                Direction = new North();
            }
            if (_directions.ContainsKey(DirectionId))
            {
                Direction = _directions[DirectionId];
            }
            SetNextSquare(CurrentSquare);
            Console.WriteLine($"Direction rotated to face: {_directions[DirectionId].Name}");
        }

    }
}
