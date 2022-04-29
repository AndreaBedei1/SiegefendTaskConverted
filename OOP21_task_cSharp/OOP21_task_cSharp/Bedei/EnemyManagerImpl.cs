

using OOP21_task_cSharp.Notaro;
using System.Threading;

namespace OOP21_task_cSharp.Bedei
{
    public class EnemyManagerImpl : IEnemyManager
    {
        private const int ENEMY_SPEED = 8;
        private const int IMG_TILE_SIZE = 80;
        private volatile bool _threadRun = true;
        private readonly IEnemy _enemy;
        private readonly IMap _map;
        private int _stepDone;
        private Direction? _lastDir = null;
        private readonly PositionConverter _converter;
        private Thread _gameThread;


        public IEnemy Enemy => throw new System.NotImplementedException();

        public void Disappear()
        {
            throw new System.NotImplementedException();
        }

        public void StopTread()
        {
            throw new System.NotImplementedException();
        }
    }
}
