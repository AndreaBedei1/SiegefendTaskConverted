using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOP21_task_cSharp.Notaro
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestGrassContainsTurret()
        {
            ITile tile = new TileImpl(TileType.Grass);
            Assert.IsTrue(tile.CanContainTurret());
        }
        [TestMethod]
        public void TestWaterNotContainsTurret()
        {
            ITile tile = new TileImpl(TileType.Water);
            Assert.IsFalse(tile.CanContainTurret());
        }
        [TestMethod]
        public void TestCorrectStartTile()
        {
            MapLoaderImpl mapLoader = new MapLoaderImpl(1);
            IMap map = mapLoader.Map;
            Assert.AreEqual(map.StartTile, new GridPosition(12, 0));
        }
        [TestMethod]
        public void TestCorrectEndTile()
        {
            MapLoaderImpl mapLoader = new MapLoaderImpl(1);
            IMap map = mapLoader.Map;
            Assert.AreEqual(map.EndTile, new GridPosition(4, 14));
        }
        [TestMethod]
        public void TestCorrectSize()
        {
            MapLoaderImpl mapLoader = new MapLoaderImpl(1);
            IMap map = mapLoader.Map;
            Assert.AreEqual(map.Size, 15);
        }
    }
}