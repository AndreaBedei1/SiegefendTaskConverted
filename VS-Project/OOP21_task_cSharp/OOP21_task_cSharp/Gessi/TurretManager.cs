using OOP21_task_cSharp.Bedei;
using OOP21_task_cSharp.Bertuccioli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Class that manages a turret.
    /// </summary>
    public class TurretManager : ITurretManager, IStoppable
    {
        private const int UPDATE_DELAY = 20;
        private readonly ITurret _turret;
        private volatile bool _isThreadRunning = true;
        private Thread? _gameThread;
        private readonly IEnemyController _enemyController;
        private readonly System.Timers.Timer _bulletTimer;

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="turret">the <see cref="ITurret"/></param>
        /// <param name="turretController">the <see cref="ITurretController"/></param>
        /// <param name="enemyController">the <see cref="IEnemyController"/></param>
        public TurretManager(ITurret turret, ITurretController turretController, IEnemyController enemyController)
        {
            _turret = turret;
            _enemyController = enemyController;
            ThreadAndViewObservable.Register(this);
            _bulletTimer = new System.Timers.Timer(1000 / Turret.FireRate);
            _bulletTimer.Elapsed += (source, e) =>
            {
                if (Turret.Target is not null)
                {
                    IBullet? bullet = Turret.CreateBullet();
                    if(bullet is not null)
                    {
                        turretController.BulletCreated(bullet);
                    }
                }
            };
            startTurretThread();
        }

        public ITurret Turret { get => _turret; }

        public int CurrentUpgradeLevel => throw new NotImplementedException();

        public int CurrentUpgradePrice => throw new NotImplementedException();

        public int NextUpgradePrice => throw new NotImplementedException();

        public ITurret NextUpgrade => throw new NotImplementedException();

        public bool CanPurchaseUpgrade => throw new NotImplementedException();

        public int Sell() => throw new NotImplementedException();

        public void Stop()
        {
            _isThreadRunning = false;
            if(_gameThread is not null)
            {
                _gameThread.Interrupt();
            }
        }


        /// <summary>
        /// Starts the turret thread.
        /// </summary>
        private void startTurretThread()
        {
            if (_gameThread == null)
            {
                _gameThread = new Thread(new ThreadStart(() =>
                {
                    while (_isThreadRunning)
                    {
                        try
                        {
                            IEnemy? target = Turret.Target;
                            if(target is null || target.HP <= 0) // Checks if there is a target and if there is one, it checks its HP
                            {
                                _bulletTimer.Stop();
                                findTarget();
                            }
                            else
                            {
                                Position? turretPosition = Turret.Position;
                                Position targetPosition = target.Position;
                                if(turretPosition is not null && turretPosition.DistanceTo(targetPosition) <= Turret.Range) // Checks if the target is inside the turret's range
                                {
                                    PointToTarget(targetPosition); // Rotation
                                    if (!_bulletTimer.Enabled)
                                    {
                                        _bulletTimer.Start();
                                    }
                                }
                                else
                                {
                                    Turret.Target = null;
                                }
                            }
                            Thread.Sleep(UPDATE_DELAY);
                        }
                        catch(ThreadInterruptedException e)
                        {
                            Console.Out.WriteLine(e.StackTrace);
                        }
                    }
                }));
            }
            _gameThread?.Start();
        }

        /// <summary>
        /// Searches the closest enemy to the turret and sets it as a target.
        /// </summary>
        private void findTarget()
        {
            LockClass.GetEnemySemaphore().WaitOne();
            var enemiesInRange = _enemyController.GetManagerList().Where(e => e.Enemy.HP > 0 && Turret.Position is not null && Turret.Position.DistanceTo(e.Enemy.Position) <= Turret.Range);
            LockClass.GetEnemySemaphore().Release();
            List<Pair<IEnemyManager, double>> mappedList = new List<Pair<IEnemyManager, double>>();
            foreach (var enemyManager in enemiesInRange)
            {
                mappedList.Add(Pair<IEnemyManager, double>.From(enemyManager, enemyManager.Enemy.Steps));
            }
            mappedList.OrderByDescending(p => p.Y);
            if (mappedList.Count > 0)
            {
                Turret.Target = mappedList.First().X.Enemy;
            }
            else
            {
                Turret.Target = null;
            }
        }

        /// <summary>
        /// Sets the angle of the <see cref="ITurret"/> to the <see cref="Position"/> of the targetted <see cref="IEnemy"/>.
        /// </summary>
        /// <param name="targetPosition">the <see cref="Position"/> of the targetted <see cref="IEnemy"/></param>
        private void PointToTarget(Position targetPosition)
        {
            if(Turret.Position is not null)
            {
                Turret.Angle = Turret.Position.GetAngle(targetPosition);
            }
        }
    }
}