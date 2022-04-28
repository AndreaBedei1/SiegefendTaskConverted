using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Represents a player.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Returns the maximum amount of HP the player can have. <br/>
        /// This value is also the starting HP.
        /// </summary>
        /// <returns>the max amount of HP of the player.</returns>
        int GetMaxHP();

        /// <summary>
        /// Returns the current HP.
        /// </summary>
        /// <returns>the current HP.</returns>
        int GetCurrentHP();

        /// <summary>
        /// Sets a new HP amount.
        /// </summary>
        /// <param name="hp">the new HP amount.</param>
        void SetCurrentHP(int hp);

        /// <summary>
        /// Decreases current HP by the default damage taken.
        /// </summary>
        void DecreaseCurrentHP();

        /// <summary>
        /// Decreases current HP by a specified amount of damage. Overload of decreaseCurrentHP().
        /// </summary>
        /// <param name="amount">of damage taken.</param>
        void DecreaseCurrentHP(int amount);

        /// <summary>
        /// </summary>
        /// <returns>the current money amount.</returns>
        int GetMoney();

        /// <summary>
        /// Sets a new money amount.
        /// </summary>
        /// <param name="money">the new money amount.</param>
        void SetMoney(int money);

        /// <summary>
        /// Getter for score.
        /// </summary>
        /// <returns>Player's current score.</returns>
        int GetScore();

        /// <summary>
        /// Sets score to a new value.
        /// </summary>
        /// <param name="score">New score.</param>
        void SetScore(int score);

        /// <summary>
        /// Getter for player's name.
        /// </summary>
        /// <returns>Player's name.</returns>
        string GetPlayerName();

        /// <summary>
        /// Sets player's name.
        /// </summary>
        /// <param name="username">is the player's name.</param>
        void SetPlayerName(string username);
    }
}
