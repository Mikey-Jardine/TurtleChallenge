using System.Drawing;

namespace Turtle_Challenge
{
    public abstract class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Point SetUpNextSquare(Point point)
        {
            return point;
        }
    }

    public class North : Direction
    {
        public North()
        {
            Id = 0;
            Name = "North";
        }

        public override Point SetUpNextSquare(Point point)
        {
            point.Y++;
            return point;
        }
    }

    public class East : Direction
    {
        public East()
        {
            Id = 1;
            Name = "East";
        }

        public override Point SetUpNextSquare(Point point)
        {
            point.X++;
            return point;
        }
    }

    public class South : Direction
    {
        public South()
        {
            Id = 2;
            Name = "South";
        }

        public override Point SetUpNextSquare(Point point)
        {
            point.Y--;
            return point;
        }
    }

    public class West : Direction
    {
        public West()
        {
            Id = 3;
            Name = "West";
        }

        public override Point SetUpNextSquare(Point point)
        {
            point.X--;
            return point;
        }
    }


}
