using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP21_task_cSharp.Bedei;
using OOP21_task_cSharp.Gessi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    [TestClass]
    public class TestsBertuccioli
    {
        private readonly IShop _shop = new Shop(new TurretsLoader());
        private readonly IPlayer _player = new Player("test", 200, 100); 

        [TestMethod]
        public void TestShop()
        {
            Assert.IsNotNull(_shop.GetAvailableTurrets());
            Assert.AreEqual(_shop.CanBuy(0, _player), true);
            Assert.AreEqual(_shop.CanBuy(1, _player), true);
            Assert.AreEqual(_shop.CanBuy(2, _player), true);
        }

        internal class Player : IPlayer
        {
            private int MaxHP { get; set; }
            private int HP { get; set; }
            private int Money { get; set; }
            private string PlayerName { get; set; }
            private int Score { get; set; }

            public Player(string name, int maxHP, int money)
            {
                PlayerName = name;
                MaxHP = maxHP;
                Money = money;
            }

            public void DecreaseCurrentHP() => HP -= 1;

            public void DecreaseCurrentHP(int amount) => HP -= amount;

            public int GetCurrentHP() => HP;

            public int GetMaxHP() => MaxHP;

            public int GetMoney() => Money;

            public string GetPlayerName() => PlayerName;

            public int GetScore() => Score;

            public void SetCurrentHP(int hp) => HP = hp;

            public void SetMoney(int money) => Money = money;

            public void SetPlayerName(string username) => PlayerName = username;

            public void SetScore(int score) => Score = score;
        }

        internal class TurretSimple : ITurret
        {
            public IBullet CreateBullet()
            {
                throw new NotImplementedException();
            }

            public double GetAngle()
            {
                throw new NotImplementedException();
            }

            public ITurret GetClone()
            {
                throw new NotImplementedException();
            }

            public double GetFireRate()
            {
                throw new NotImplementedException();
            }

            public int GetID()
            {
                throw new NotImplementedException();
            }

            public Position GetPosition()
            {
                throw new NotImplementedException();
            }

            public int GetPrice() => 0;

            public double GetRange()
            {
                throw new NotImplementedException();
            }

            public IEnemy? GetTarget()
            {
                throw new NotImplementedException();
            }

            public bool IsAttacking()
            {
                throw new NotImplementedException();
            }

            public void SetAngle(double angle)
            {
                throw new NotImplementedException();
            }

            public void SetPosition(Position p)
            {
                throw new NotImplementedException();
            }

            public void SetState(bool state)
            {
                throw new NotImplementedException();
            }

            public void SetTarget(IEnemy target)
            {
                throw new NotImplementedException();
            }

            IBullet ITurret.CreateBullet()
            {
                throw new NotImplementedException();
            }
        }

        internal class TurretsLoader : ITurretsLoader
        {
            public IDictionary<int, ITurret> GetTurrets()
            {
                IDictionary<int, ITurret> dict = new Dictionary<int, ITurret>();
                dict.Add(0, new TurretSimple());    // Substitute with turret.
                dict.Add(1, new TurretSimple());
                dict.Add(2, new TurretSimple());
                dict.Add(3, new TurretSimple());
                return dict;
            }
        }
    }
}
