using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using NUnit.Framework;
using Turtle_Challenge;
using Assert = NUnit.Framework.Assert;

namespace GameTest
{
    [TestFixture]
    public class TurtleTest
    {

        [Test]
        public void TurtleExitSuccess()
        {
            var moves = new List<char>() { 'm', 'm', 'r', 'm', 'r','m','m' };

            var startPoint = new Point() { X = 0, Y = 0};
            var exit = new Point() { X = 1, Y = 4 };
            var height = 5;
            var width = 6;
            var mines = new List<Point>();
            var settings = new GameSettings(startPoint, exit, height, width, mines);

            var game = new Game(settings, moves);
            game.Start();

            Assert.NotNull(game.Turtle);
            Assert.NotNull(game.Board);

            Assert.IsTrue(game.Turtle.Alive);
            Assert.IsTrue(game.Turtle.HasGameEnded);
        }


        [Test]
        public void TurtleExitFail()
        {
            var moves = new List<char>() { 'm', 'm', 'r', 'm', 'r', 'm', 'm' };

            var startPoint = new Point() { X = 0, Y = 1 };
            var exit = new Point() { X = 1, Y = 4 };
            var height = 5;
            var width = 6;
            var mines = new List<Point>() { new Point() { X = 0, Y = 0 } };
            var settings = new GameSettings(startPoint, exit, height, width, mines);

            var game = new Game(settings, moves);
            game.Start();

            Assert.NotNull(game.Turtle);
            Assert.NotNull(game.Board);

            Assert.IsFalse(game.Turtle.Alive);
            Assert.IsTrue(game.Turtle.HasGameEnded);
        }

        [Test]
        public void TurtleExitSameAsStartingPoint()
        {
            var moves = new List<char>() { 'm', 'm', 'r', 'm', 'r', 'm', 'm' };

            var startPoint = new Point() { X = 0, Y = 1 };
            var exit = new Point() { X = 0, Y = 1 };
            var height = 5;
            var width = 6;
            var mines = new List<Point>() { new Point() { X = 0, Y = 0 } };
            var settings = new GameSettings(startPoint, exit, height, width, mines);

            var game = new Game(settings, moves);
            game.Start();

            Assert.NotNull(game.Turtle);
            Assert.NotNull(game.Board);

            Assert.IsFalse(game.Turtle.Alive);
            Assert.IsTrue(game.Turtle.HasGameEnded);
        }

        [Test]
        public void AllRotations()
        {
            var moves = new List<char>() { 'r', 'r', 'r', 'r', 'r', 'r', 'r' };

            var startPoint = new Point() { X = 0, Y = 1 };
            var exit = new Point() { X = 2, Y = 3 };
            var height = 5;
            var width = 6;
            var mines = new List<Point>() { new Point() { X = 4, Y = 2 } };
            var settings = new GameSettings(startPoint, exit, height, width, mines);

            var game = new Game(settings, moves);
            game.Start();

            Assert.NotNull(game.Turtle);
            Assert.NotNull(game.Board);

            Assert.IsTrue(game.Turtle.Alive);
            Assert.IsTrue(game.Turtle.HasGameEnded);
        }

        [Test]
        public void AllMovesOutOfBoundsTest()
        {
            var moves = new List<char>() { 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm' };

            var startPoint = new Point() { X = 0, Y = 1 };
            var exit = new Point() { X = 2, Y = 3 };
            var height = 5;
            var width = 6;
            var mines = new List<Point>() { new Point() { X = 4, Y = 2 } };
            var settings = new GameSettings(startPoint, exit, height, width, mines);

            var game = new Game(settings, moves);
            game.Start();

            Assert.NotNull(game.Turtle);
            Assert.NotNull(game.Board);

            Assert.IsTrue(game.Turtle.Alive);
            Assert.IsTrue(game.Turtle.HasGameEnded);
        }
    }
}
