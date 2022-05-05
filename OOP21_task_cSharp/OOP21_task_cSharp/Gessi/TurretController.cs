using OOP21_task_cSharp.Bedei;
using OOP21_task_cSharp.Bertuccioli;
using OOP21_task_cSharp.Notaro;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Controller class for the view of turrets.
    /// </summary>
    public class TurretController : ITurretController
    {
        private readonly int _tileSize;
        private readonly Dictionary<GridPosition, ITurretManager> _turrets;
        private readonly Semaphore _semaphore;
        private readonly IShopController _shopController;
        private readonly IEnemyController _enemyController;
        private readonly IBulletController _bulletController;

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="shopController">the <see cref="IShopController"/></param>
        /// <param name="semaphore">the <see cref="Semaphore"/></param>
        /// <param name="enemyController">the <see cref="IEnemyController"/></param>
        /// <param name="bulletController">the <see cref="IBulletController"/></param>
        public TurretController(IShopController shopController, Semaphore semaphore, IEnemyController enemyController, IBulletController bulletController)
        {
            _shopController = shopController;
            _semaphore = semaphore;
            _turrets = new Dictionary<GridPosition, ITurretManager>();
            _tileSize = ImgTileSize.GetTileSize();
            _enemyController = enemyController;
            _bulletController = bulletController;
        }

        public bool IsTurretSelected()
        {
            return _shopController.GetSelectedTurret() is not null;
        }

        public ITurret? GetTurretAt(GridPosition gpos)
        {
            ITurretManager t;
            _turrets.TryGetValue(gpos, out t);
            return t is not null ? (ITurret?)t.Turret : null;
        }

        public void AddSelectedTurret(GridPosition gpos)
        {
            if(_shopController.GetSelectedTurret() is not null && IsTileEmpty(gpos))
            {
                ITurret? t = _shopController.Buy();
                if(t is not null)
                {
                    _semaphore.WaitOne();
                    ITurretManager newTurretManager = new TurretManager(t.GetClone(), this, _enemyController);
                    newTurretManager.Turret.Position = new PositionConverter(this._tileSize).ConvertToPosition(gpos);
                    _turrets.Add(new GridPosition(gpos), newTurretManager);
                    _semaphore.Release();
                }
            }
        }

        public bool IsTileEmpty(GridPosition gpos)
        {
            return !_turrets.ContainsKey(gpos);
        }

        private class TurretEnumerator : IEnumerator<KeyValuePair<GridPosition, ITurret>>
        {
            IEnumerator<KeyValuePair<GridPosition, ITurretManager>> _enumerator;
            public TurretEnumerator(IEnumerator<KeyValuePair<GridPosition, ITurretManager>> enumerator)
            {
                _enumerator = enumerator;
            }

            public KeyValuePair<GridPosition, ITurret> Current => new KeyValuePair<GridPosition, ITurret>(_enumerator.Current.Key, _enumerator.Current.Value.Turret);

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            public void Reset()
            {
                _enumerator.Reset();
            }
        }

        public IEnumerator<KeyValuePair<GridPosition, ITurret>> GetTurretsEnumerator()
        {
            return new TurretEnumerator(_turrets.GetEnumerator());
        }

        public void BulletCreated(IBullet bullet)
        {
            _bulletController.AddBullet(bullet);
        }
    }
}