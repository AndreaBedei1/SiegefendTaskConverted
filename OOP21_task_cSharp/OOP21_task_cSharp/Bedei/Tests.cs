using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bedei
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestPosition()
        {
            Position position = new Position(0.0, 1.0);
            Assert.AreEqual(position.X, 0.0);
            Assert.AreEqual(position.Y, 1.0);
            position.Y = 0.0;
            Assert.AreEqual(position.Y, 0.0);
            position.SetCoordinates(1.0, 1.0);
            Assert.AreEqual(position, new Position(1.0, 1.0));
            Assert.AreEqual(position.DistanceTo(new Position(1.0, 1.0)), 0.0);
            Assert.AreEqual(position.GetAngle(new Position(1.0, 1.0)), 0.0);
        }
    }
}
