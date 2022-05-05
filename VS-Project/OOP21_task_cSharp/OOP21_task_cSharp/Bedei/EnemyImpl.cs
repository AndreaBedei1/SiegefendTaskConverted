using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP21_task_cSharp.Bedei
{
    /// <summary>
    /// This class represents the implementation of the Enemy interface.
    /// </summary>
    public class EnemyImpl : IEnemy
    {
        private readonly Semaphore _enemySemaphore;

        public double Points => MaxHp * Speed;

        public double PercentHp => HP / MaxHp;

        public Position Position { get; }

        public double Steps { get; private set; }

        public double HP { get; private set; }

        public double Speed { get; }

        public EnemyType EnemyType { get; }

        public double Reward { get; }

        public double MaxHp { get; }


        /// <summary>
        /// Creates an Enemy.
        /// </summary>
        /// <param name="position">Is the position in pixel occupied by the Enemy.</param>
        /// <param name="hp">Is the Enemy health.</param>
        /// <param name="speed">Is the movement speed parameter.</param>
        /// <param name="reward">Is the reward of the enemy.</param>
        /// <param name="enemyType">Denotes the type of the Enemy.</param>
        public EnemyImpl(Position position, double hp, double speed, double reward, EnemyType enemyType)
        {
            Position = new Position(position);
            HP = hp;
            MaxHp = hp;
            Reward = reward;
            Speed = speed;
            EnemyType = enemyType;
            _enemySemaphore = new Semaphore(1, 1);
        }

        public void Move(double x, double y)
        {
            Position?.SetCoordinates(x, y);
            Steps++;
        }

        public void DamageSuffered(double damage)
        {
            _enemySemaphore?.WaitOne();
            HP -= damage;
            _enemySemaphore?.Release();
        }

        public override bool Equals(object? obj) => obj is EnemyImpl impl &&
            EqualityComparer<Position>.Default.Equals(Position, impl.Position) && EnemyType == impl.EnemyType;

        public override int GetHashCode() => HashCode.Combine(Position, EnemyType);

        public override string ToString() => "EnemyImpl [ position=" + Position + ", stepsDone=" + Steps + ", hp=" + HP + ", maxHp=" + MaxHp
                + ", hpPercent=" + PercentHp + ", speed=" + Speed + ", enemyType=" + EnemyType + "]";

    }
}
