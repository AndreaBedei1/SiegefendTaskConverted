using OOP21_task_cSharp.Notaro;
using System;
using System.Threading;

namespace OOP21_task_cSharp.Bedei
{
    public class EnemyManagerImpl : IEnemyManager
    {
        private const int ENEMY_SPEED = 8;
        private const int IMG_TILE_SIZE = 80;
        private volatile bool _threadRun = true;
        private readonly IEnemyController _enemyController;
        private readonly IMap _map;
        private int _stepDone;
        private Direction? _lastDir;
        private readonly PositionConverter _converter;
        private Thread? _gameThread;

        public IEnemy Enemy { get; }

        public EnemyManagerImpl(IEnemy enemy, ILevelManager levelManager, IEnemyController enemyController)
        {
            Enemy = enemy;
            _map = levelManager.Map;
            _enemyController = enemyController;
            _converter = new PositionConverter(IMG_TILE_SIZE);
            StartEnemyThread();
        }

        private void StartEnemyThread()
        {
            if(_gameThread == null)
            {
                _gameThread = new Thread(() =>
                {
                    while (_threadRun)
                    {
                        try
                        {
                            CheckLife();
                            NextMovement();
                            CheckFinalDestination();
                            Thread.Sleep(ENEMY_SPEED);
                        }
                        catch (ThreadInterruptedException e)
                        {
                            if (e.Source != null)
                                Console.WriteLine("IOException source: {0}", e.Source);
                        }
                    }
                });
            }
            _gameThread.Start();
        }

        private void NextMovement()
        {
            if (InitialPart())
                TakeDirection();
            _stepDone += (int)Enemy.Speed;
            if(_stepDone>=IMG_TILE_SIZE)
                _stepDone = 0;
            EnemyMovement(_lastDir is null ? throw new NullReferenceException() : _lastDir );
        }

        private void EnemyMovement(Direction? dir)
        {
            Position p = Enemy.Position;
            double speed = Enemy.Speed;
            Pair<int, int> vec = ToUnitVector(dir);
            Enemy.Move(p.X + vec.X * speed, p.Y + vec.Y * speed);
        }

        private static Pair<int, int> ToUnitVector(Direction? d) => d switch
        {
            Direction.Up => Pair<int, int>.From(0, -1),
            Direction.Right => Pair<int, int>.From(1, 0),
            Direction.Down => Pair<int, int>.From(0, 1),
            Direction.Left => Pair<int, int>.From(-1, 0),
            _ => throw new NotSupportedException("Enemy direction not correct"),
        };

        private void TakeDirection()
        {
            GridPosition p = _converter.ConvertToGridPosition(Enemy.Position);
            bool hasValue = _map.Tiles.TryGetValue(p, out ITile? d);
            if (hasValue)
                _lastDir = d is not null ? d.TileDirection : null;
        }

        private bool InitialPart() => _stepDone == 0;

        private void CheckFinalDestination()
        {
            double x = Enemy.Position.X;
            double y = Enemy.Position.Y;
            if (x == -IMG_TILE_SIZE || y == -IMG_TILE_SIZE || this.EndIntoMap(x) || this.EndIntoMap(y))
                Disappear();
        }

        private bool EndIntoMap(double v) => _map.Size * IMG_TILE_SIZE == v;

        private void CheckLife()
        {
            if (Enemy.HP <= 0)
                Disappear();
        }

        public void Disappear()
        {
            StopTread();
            _enemyController.RemoveEnemy(this);
        }

        public void StopTread() => _threadRun = true;

        public override string ToString() => "EnemyManagerImpl [threadRun=" + _threadRun + ", enemy=" + Enemy + ", lastDir=" + _lastDir + "]";
    }
}
