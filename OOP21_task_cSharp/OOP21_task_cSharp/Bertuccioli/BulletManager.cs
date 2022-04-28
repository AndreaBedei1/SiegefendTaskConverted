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
        private readonly IBullet _bullet;
        private readonly IBulletController _bulletController;
        private Thread? _thread;
        private const int UPDATE_DELAY = 20;
        private const int TOUCH_DISTANCE = 50;
        private bool _active;
        private bool _threadRunning;

        /// <summary>
        /// Creates an instance of the class with the given {@link Bullet}.
        /// <param name "bullet">a bullet</param>
        /// <param name "bulletController">the controller for the bullet view</param>
        /// </summary>
        public BulletManager(IBullet bullet, IBulletController bulletController)
        {
            _bullet = bullet;
            _bulletController = bulletController;
            _active = true;
            StartThread();
        }

        public IBullet GetBullet()
        {
            return _bullet;
        }

        public void Eliminate()
        {
            _bulletController.RemoveBullet(this);
            _active = false;
        }

        private void Shift(double x, double y)
        {
            _bullet.Move(_bullet.GetPosition().X + x, _bullet.GetPosition().Y + y);
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
                        while (_active && _threadRunning && _bullet != null && _bullet.GetTarget() != null && _bullet.GetTarget().HP > 0)
                        {
                            if (_bullet.GetPosition().DistanceTo(_bullet.GetTargetPosition()) < TOUCH_DISTANCE)
                            {
                                _bullet.GetTarget().DamageSuffered(_bullet.GetDamage());
                                break;
                            }
                            double directionAngle = _bullet.GetPosition().GetAngle(_bullet.GetTargetPosition());
                            Shift(Math.Cos(directionAngle) * _bullet.GetSpeed() * deltaTime, Math.Sin(directionAngle) * _bullet.GetSpeed() * deltaTime);
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
