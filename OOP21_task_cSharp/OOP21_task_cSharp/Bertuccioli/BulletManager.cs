using OOP21_task_cSharp.Gessi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Manages a bullet, moving it towards an enemy and inflicting damage when reaching it.
    /// </summary>
    public class BulletManager : IBulletManager, IStoppable
    {
        private readonly IBulletController _bulletController;
        private Thread? _thread;
        private const int UPDATE_DELAY = 20;
        private const int TOUCH_DISTANCE = 50;
        private bool _active;
        private bool _threadRunning;

        /// <summary>
        /// Creates an instance of the class with the given <see cref="IBullet"/>.
        /// <param name "bullet">a bullet</param>
        /// <param name "bulletController">the controller for the bullet view</param>
        /// </summary>
        public BulletManager(IBullet bullet, IBulletController bulletController)
        {
            Bullet = bullet;
            _bulletController = bulletController;
            _active = true;
            StartThread();
        }

        public IBullet Bullet { get; private set; }

        public void Eliminate()
        {
            _bulletController.RemoveBullet(this);
            _active = false;
        }

        private void Shift(double x, double y)
        {
            Bullet.Move(Bullet.Position.X + x, Bullet.Position.Y + y);
        }

        private void StartThread()
        {
            double deltaTime = 1.0 / UPDATE_DELAY;
            if (_active && _thread == null)
            {
                _thread = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        while (_active && _threadRunning && Bullet != null && Bullet.Target != null && Bullet.Target.HP > 0)
                        {
                            if (Bullet.Position.DistanceTo(Bullet.TargetPosition) < TOUCH_DISTANCE)
                            {
                                Bullet.Target.DamageSuffered(Bullet.Damage);
                                break;
                            }
                            double directionAngle = Bullet.Position.GetAngle(Bullet.Position);
                            Shift(Math.Cos(directionAngle) * Bullet.Speed * deltaTime, Math.Sin(directionAngle) * Bullet.Speed * deltaTime);
                            Thread.Sleep(UPDATE_DELAY);
                        }
                        Eliminate();
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.Out.WriteLine(e.StackTrace);
                    }
                }));
            }
            _threadRunning = true;
            _thread?.Start();
        }

        public void Stop()
        {
            _threadRunning = false;
        }
    }
}
