using System;

namespace OOP21_task_cSharp.Bedei
{ 
    /// <summary>
    /// Represents an enemy that can spawn on the map.
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// The enemy score value.
        /// </summary>
        public double Points { get; }

        /// <summary>
        /// The percentage of enemy Life.
        /// </summary>
        /// <returns>The percentage of enemy Life.</returns>
        public double PercentHp { get; }
        
        /// <summary>
        ///  Steps done by one enemy.
        /// </summary>
        public double Steps { get; }

        /// <summary>
        /// The current Position of the enemy.
        /// </summary>
        public Position Position { get; }

        /// <summary>
        /// The amount of health points the enemy has left.
        /// </summary>
        public double HP { get; }

        /// <summary>
        /// The speed at which the enemy moves on the map.
        /// </summary>
        public double Speed { get; }

        /// <summary>
        ///  The EnemyType of one enemy.
        /// </summary>
        public EnemyType EnemyType { get; }

        /// <summary>
        /// The enemy reward.
        /// </summary>
        public double Reward { get; }

        /// <summary>
        /// Triggers the enemy to start moving.
        /// </summary>
        /// <param name="x">coordinate</param>
        /// <param name="y">coordinate</param>
        public void Move(double x, double y);

        /// <summary>
        /// Method that decrees the enemy life. 
        /// </summary>
        /// <param name="damage">Is the damage that the enemy has recived.</param>
        public void damageSuffered(double damage);
    }
}
