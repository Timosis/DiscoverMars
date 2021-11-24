using DiscoverMars.Models;
using System;
using Xunit;

namespace DiscoverMars.Test
{
    public class RoverTest
    {

        [Fact]
        public void GetRoversTest()
        {
            var fileReader = new FileReader();
            var rovers = fileReader.GetRovers();
             Assert.Equal(3, rovers.Count);
        }


        [Fact]
        public void GetRoversDirectionTest()
        {
            var fileReader = new FileReader();
            var rovers = fileReader.GetRovers();
            Assert.Equal(Direction.North, rovers[0].Direction);
            Assert.Equal(Direction.East, rovers[1].Direction);
            Assert.Equal(Direction.South, rovers[2].Direction);
        }

        [Fact]
        public void RotateRoverLeftTest()
        {
            var fileReader = new FileReader();
            var rovers = fileReader.GetRovers();
            rovers[0].RotateLeft();
            Assert.Equal(Direction.West, rovers[0].Direction);            
        }

        [Fact]
        public void RotateRoverRightTest()
        {
            var fileReader = new FileReader();
            var rovers = fileReader.GetRovers();
            rovers[0].RotateRight();
            Assert.Equal(Direction.East, rovers[0].Direction);            
        }

        [Fact]
        public void MoveRoverTest()
        {
            var fileReader = new FileReader();
            var rovers = fileReader.GetRovers();
            Point expectedLocation = new Point(rovers[0].Location.X, rovers[0].Location.Y + 1);
            rovers[0].Move();
            Assert.Equal(expectedLocation.X, rovers[0].Location.X);
            Assert.Equal(expectedLocation.Y, rovers[0].Location.Y);
        }


    }
}
