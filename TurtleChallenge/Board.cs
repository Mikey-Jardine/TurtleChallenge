using System.Collections.Generic;
using System.Drawing;
using TurtleChallenge.Interfaces;

namespace Turtle_Challenge
{
    public class Board : IBoard
    {
        public Board(int height, int width, List<Point> mines, Point exit)
        {
            Squares = new Square[width, height];

            for (var i = 0; i <= Squares.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= Squares.GetUpperBound(1); j++)
                {
                    Squares[i, j] = new Square();
                }
            }

            Squares[exit.X, exit.Y].HasExit = true;

            foreach (var mine in mines)
            {
                Squares[mine.X, mine.Y].HasMine = true;
            }

            Exit = exit;
        }

        public Square[,] Squares { get; set; }
        public Point Exit { get; set; }

        public void Update(Turtle turtle)
        {
            Squares[turtle.CurrentSquare.X, turtle.CurrentSquare.Y].SteppedOn = true;
            Squares[turtle.CurrentSquare.X, turtle.CurrentSquare.Y].HasTurtle = true;

            Squares[turtle.PreviousSquare.X, turtle.PreviousSquare.Y].HasTurtle = false;
            Squares[turtle.PreviousSquare.X, turtle.PreviousSquare.Y].IsEmpty = true;

        }
    }

    public class Square
    {
        public bool IsEmpty { get; set; }
        public bool HasMine { get; set; }
        public bool HasExit { get; set; }
        public bool HasTurtle { get; set; }
        public bool SteppedOn { get; set; }
    }
}
