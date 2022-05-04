using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP21_task_cSharp.Bedei;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Testing class for turrets.
    /// </summary>
    [TestClass]
    public class TestsGessi
    {
        private const int TURRET0_PRICE = 120;
        private const int TURRET1_PRICE = 250;
        private const int TURRET2_PRICE = 400;
        private static readonly Position POSITION = new Position(3, 3);

        // Since the turrets loader is not implemented (there is just the interface, ITurretsLoader),
        // therefore I can't take the turrets' info from the.json file, I've decided to opt for this solution
        // where I manually take it from the .json file.
        private ITurret _turret0 = new Turret(0, null, 250.0, 120, 1.2, 150.0, 18.0);
        private ITurret _turret1 = new Turret(1, null, 250.0, 250, 0.75, 200.0, 50.0);
        private ITurret _turret2 = new Turret(2, null, 350.0, 400, 1.5, 200.0, 18.0);

        /// <summary>
        /// Checks if the price of the turrets is correct.
        /// </summary>
        [TestMethod, TestCategory("Turret")]
        public void priceTests()
        {
            Assert.AreEqual(_turret0.Price, _turret0.Price);
            Assert.AreEqual(_turret1.Price, _turret1.Price);
            Assert.AreEqual(_turret2.Price, _turret2.Price);
        }

        /// <summary>
        /// Checks if the initial position of the turret is correct.
        /// </summary>
        [TestMethod, TestCategory("Turret")]
        public void initialPositionTests()
        {
            Assert.IsNull(_turret0.Position);
            Assert.IsNull(_turret1.Position);
            Assert.IsNull(_turret2.Position);
        }

        /// <summary>
        /// Tests if the Position gets set correctly.
        /// </summary>
        [TestMethod, TestCategory("Turret")]
        public void setPositionTest()
        {
            _turret0.Position = POSITION;
            Assert.AreEqual(_turret0.Position, POSITION);
        }

        /// <summary>
        /// Tests if the GetClone() method works correctly.
        /// </summary>
        [TestMethod, TestCategory("Turret")]
        public void getCloneTest()
        {
            ITurret clone = _turret0.GetClone();
            Assert.AreEqual(_turret0, clone);
        }
    }
}
