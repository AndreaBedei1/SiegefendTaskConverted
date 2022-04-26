using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP21_task_cSharp.Bedei
{
    /// <summary>
    /// This class represents the implementation of the interface link Enemy.
    /// </summary>
    public class EnemyImpl : IEnemy
    {
        private readonly Position _position;
        private double _stepsDone;
        private double _hp;
        private readonly double _maxHp;
        private readonly double _reward;
        private double _speed;
        private readonly Semaphore _enemySemaphore;
        private readonly EnemyType _enemyType;

        public double Points => _maxHp * _speed;

        public double PercentHp => _hp / _maxHp;

        public Position Position => _position;

        public double Steps => _stepsDone;

        public double HP => _hp;

        public double Speed => _speed;

        public EnemyType EnemyType => _enemyType;

        public double Reward => _reward;


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
            _position = new Position(position);
            _hp = hp;
            _maxHp = hp;
            _reward = reward;
            _speed = speed;
            _enemyType = enemyType;
            _enemySemaphore = new Semaphore(1,1);
        }
        
        public void Move(double x, double y)
        {
            _position?.SetCoordinates(x, y);
            _stepsDone++;
        }

        public void damageSuffered(double damage)
        {
            _enemySemaphore?.WaitOne();
            _hp -= damage;
            _enemySemaphore?.Release();
        }

        public override bool Equals(object? obj) => obj is EnemyImpl impl && 
            EqualityComparer<Position>.Default.Equals(_position, impl._position) && _enemyType == impl._enemyType;

        public override int GetHashCode() => HashCode.Combine(_position, _enemyType);

        public override string ToString() => "EnemyImpl [ position=" + _position + ", stepsDone=" + _stepsDone + ", hp=" + _hp + ", maxHp=" + _maxHp
                + ", hpPercent=" + PercentHp + ", speed=" + _speed + ", enemyType=" + _enemyType + "]";

    }
}
