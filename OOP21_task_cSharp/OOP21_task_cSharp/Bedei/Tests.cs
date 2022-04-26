using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    [TestClass]
    public class Tests
    {
        private List<IEnemy> _enemyList = new List<IEnemy>();

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

        [TestMethod]
        public void TestEnemy()
        {
            IEnemy enemy = new EnemyImpl(new Position(0, 0), 1.0, 1.0, 1.0, EnemyType.TANK);
            Assert.AreEqual(enemy.EnemyType, EnemyType.TANK);
            Assert.AreEqual(enemy.Steps, 0.0);
            Assert.AreEqual(enemy.Speed, 1.0);
            Assert.AreEqual(enemy.Reward, 1.0);
            Assert.AreEqual(enemy.HP, 1.0);
            Assert.AreEqual(enemy.Position, new Position(0, 0));
            enemy.Move(1.0, 1.0);
            Assert.AreEqual(enemy.Steps, 1.0);
            Assert.AreEqual(enemy.Position, new Position(1, 1));
            enemy.DamageSuffered(0.5);
            Assert.AreEqual(enemy.HP, 0.5);
        }
    }
}
