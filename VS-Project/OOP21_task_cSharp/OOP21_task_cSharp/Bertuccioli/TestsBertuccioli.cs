using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP21_task_cSharp.Bedei;
using OOP21_task_cSharp.Gessi;
using System.Collections.Generic;

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

        internal class TurretsLoader : ITurretsLoader
        {
            public IDictionary<int, ITurret> GetTurrets()
            {
                IDictionary<int, ITurret> dict = new Dictionary<int, ITurret>();
                dict.Add(0, new Turret(0, new Position(10, 10), 10, 10, 10, 10, 10));
                dict.Add(1, new Turret(1, new Position(20, 20), 20, 20, 20, 20, 20));
                dict.Add(2, new Turret(2, new Position(30, 30), 30, 30, 30, 30, 30));
                dict.Add(3, new Turret(3, new Position(40, 40), 40, 40, 40, 40, 40));
                return dict;
            }
        }
    }
}
