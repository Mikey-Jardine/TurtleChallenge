using System;
using System.Collections.Generic;
using TurtleChallenge.Interfaces;

namespace Turtle_Challenge
{
    public class Game : IGame
    {
        public Game(GameSettings gameSettings, List<char> moves)
        {
            Settings = gameSettings;
            Board = new Board(gameSettings.Height, gameSettings.Width, gameSettings.Mines, gameSettings.Exit);
            Turtle = new Turtle(gameSettings.StartPoint, 0);
            Moves = moves;
            DisplayMessage = string.Empty;
        }

        public Board Board { get; set; }
        public Turtle Turtle { get; set; }
        public GameSettings Settings { get; set; }
        public List<char> Moves { get; set; }
        public bool Success { get; set; }
        public string DisplayMessage { get; set; }
        private const char _rotate = 'r';
        private const char _move = 'm';
        public void Start()
        {
            foreach (var move in Moves)
            {
                if (Board.Squares[Turtle.CurrentSquare.X, Turtle.CurrentSquare.Y].HasExit)
                {
                    Turtle.Alive = true;
                    break;
                }

                if (Board.Squares[Turtle.CurrentSquare.X, Turtle.CurrentSquare.Y].HasMine)
                {
                    Turtle.Alive = false;
                    break;
                }

                if (move == _rotate)
                {
                    Turtle.Rotate();
                }

                if (move == _move)
                {
                    if (IsOnBoard())
                    {
                        Turtle.Move();
                    }
                }

                Board.Update(Turtle);

            }

            Success = Turtle.Alive;
            Turtle.HasGameEnded = true;
            DisplayMessage = Success ? "He exited safely" : "He's dead";
            Stop(DisplayMessage);
        }

        public void Stop(string message)
        {
            Console.WriteLine($"{message}");
        }

        public bool IsOnBoard()
        {
            return (Turtle.NextSquare.Y >= 0 && Turtle.NextSquare.Y < Board.Squares.GetLength(0) -1
                                             && Turtle.NextSquare.X >= 0 
                                             && Turtle.NextSquare.X < Board.Squares.GetLength(1) -1);

        }

    }
}
