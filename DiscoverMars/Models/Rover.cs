using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverMars.Models
{
    public class Rover
    {
        public int Id { get; set; }
        public Point Location { get; set; }

        public Direction Direction { get; set; }

        public string[] Moves { get; set; }

        public Rover(int roverId,Point startPoint, string roverDirection, string[] moves)
        {
            Id = roverId;
            Location = startPoint;
            Moves = moves;

            switch (roverDirection)
            {
                case "N":
                    Direction = Direction.North;
                    break;
                case "W":
                    Direction = Direction.West;
                    break;
                case "E":
                    Direction = Direction.East;
                    break;
                case "S":
                    Direction = Direction.South;
                    break;
                default:
                    break;
            }
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    Location = new Point(Location.X, Location.Y + 1);
                    break;
                case Direction.South:
                    Location = new Point(Location.X, Location.Y - 1);
                    break;
                case Direction.East:
                    Location = new Point(Location.X + 1, Location.Y);
                    break;
                case Direction.West:
                    Location = new Point(Location.X - 1, Location.Y);
                    break;
                default:
                    break;
            }
        }

        public void RotateRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.South:
                    Direction = Direction.East;                    
                    break;
                case Direction.East:
                    Direction = Direction.South;                    
                    break;
                case Direction.West:
                    Direction = Direction.North;                    
                    break;
                default:
                    break;
            }
        }

        public void RotateLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
                default:
                    break;
            }
        }
    }
}
