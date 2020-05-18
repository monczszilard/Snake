using NUnit.Framework;
using SnakeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp.Tests
{
    [TestFixture]
    public class SnakeTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        [Test]
        [TestCase(Direction.Up, Direction.Down)]
        [TestCase(Direction.Down, Direction.Up)]
        public void MoveSelfCollisionTest(Direction oldDirection, Direction newDirection)
        {
            var snake = new Snake();

            snake.NewDirection = newDirection;
            snake.OldDirection = oldDirection;
            snake.NewDirection = newDirection;
            Assert.That(snake.NewDirection, Is.EqualTo(newDirection));
        }
    }
}