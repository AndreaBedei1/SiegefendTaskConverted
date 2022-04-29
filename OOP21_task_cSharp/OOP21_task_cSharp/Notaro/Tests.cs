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
    }
}