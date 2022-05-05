using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP21_task_cSharp.Notaro;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    [TestClass]
    public class Tests
    {
        private readonly IEnemy _enemy = new EnemyImpl(new Position(0, 0), 1.0, 1.0, 1.0, EnemyType.TANK);
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

            Assert.AreEqual(_enemy.EnemyType, EnemyType.TANK);
            Assert.AreEqual(_enemy.Steps, 0.0);
            Assert.AreEqual(_enemy.Speed, 1.0);
            Assert.AreEqual(_enemy.Reward, 1.0);
            Assert.AreEqual(_enemy.HP, 1.0);
            Assert.AreEqual(_enemy.Position, new Position(0, 0));
            _enemy.Move(1.0, 1.0);
            Assert.AreEqual(_enemy.Steps, 1.0);
            Assert.AreEqual(_enemy.Position, new Position(1, 1));
            _enemy.DamageSuffered(0.5);
            Assert.AreEqual(_enemy.HP, 0.5);
        }

        private IWave WaveCreation()
        {
            List<IEnemy> enemyList = new();
            enemyList.Add(_enemy);
            return new WaveImpl(enemyList);
        }

        [TestMethod]
        public void TestWave()
        {
            IWave wave = WaveCreation();
            Assert.AreEqual(wave.Wave.Count, 1);
        }

        [TestMethod]
        public void TestLevel()
        {
            IMap map = new MapImpl();
            List<IWave> waveList = new();
            waveList.Add(WaveCreation());
            ILevel level = new LevelImpl(waveList, 0, map);
            Assert.AreEqual(level.LevelId, 0);
            Assert.AreEqual(level.NumberOfWaves, 1);
        }

        [TestMethod]
        public void TestLevelManager()
        {
            IMap map = new MapImpl();
            List<IWave> waveList = new();
            waveList.Add(WaveCreation());
            ILevel level = new LevelImpl(waveList, 0, map);
            ILevelManager levelManager = new LevelManagerImpl(level);
            Assert.AreEqual(levelManager.Waves, waveList);
            Assert.AreEqual(levelManager.TotalWaves, waveList.Count);
            Assert.AreEqual(levelManager.CurrentLevel, level);
            Assert.IsFalse(levelManager.NextWave);
            Assert.IsNull(levelManager.CurrentEnemy);
            Assert.IsTrue(levelManager.NextEnemy);
            Assert.IsNotNull(levelManager.CurrentEnemy);
            Assert.AreEqual(levelManager.CurrentEnemy, _enemy);
            Assert.IsFalse(levelManager.NextEnemy);
        }
    }
}
