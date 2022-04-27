using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegefendCSProj
{
    public interface IPlayer
    {
        int GetMaxHP();

        int GetCurrentHP();

        void SetCurrentHP(int hp);

        void DecreaseCurrentHP();

        void DecreaseCurrentHP(int amount);

        int GetMoney();

        void SetMoney(int money);

        int GetScore();

        void SetScore(int score);

        string GetPlayerName();

        void SetPlayerName(string username);
    }
}
