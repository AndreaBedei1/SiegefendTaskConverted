using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void TestPosition()
        {
            Position position = new(0.0, 1.0);
            Assert.AreEqual(position.X, 0.0);
            Assert.AreEqual(position.Y, 1.0);
            position.Y = 0.0;
            Assert.AreEqual(position.Y, 0.0);
            position.SetCoordinates(1.0, 1.0);
            Assert.AreEqual(position, new Position(1.0, 1.0));
            Assert.AreEqual(position.DistanceTo(new Position(1.0, 1.0)), 0.0);
            Assert.AreEqual(position.GetAngle(new Position(1.0, 1.0)), 0.0);
        }

        [TestMethod]
        public void TestPair()
        {
            Pair<int, int> pair = new(0, 0);
            Assert.AreEqual(pair.X, 0);
            Assert.AreEqual(pair.Y, 0);
            Assert.AreEqual(pair, Pair<int, int>.From(0, 0));
        }

    }
}
