using System;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    public class LevelManagerImpl : ILevelManager
    {
        private readonly ILevel _level;
        private readonly IEnumerator<IWave> _waveIter;
        private IEnumerator<IEnemy> _enemyIter;
        private IWave? _currentWave = null; 

        public LevelManagerImpl(ILevel level)
        {
            _level = level;
            _waveIter = level.Waves.GetEnumerator();
            loadWave();
        }

        private void loadWave()
        {
            if (_waveIter.MoveNext())
            {
                _currentWave = _waveIter.Current;
                _enemyIter = _waveIter.Current.EnemyList.GetEnumerator();
            }
            else
                throw new NotImplementedException();
        }

        public List<IWave> Waves => _level.Waves;

        public int TotalWaves => _level.NumberOfWaves;

        public ILevel CurrentLevel => _level;

        public IWave CurrentWave => _currentWave is null ? throw new Exception() : _currentWave;

        public bool hasNextWave => _waveIter.MoveNext();

        public IEnemy? CurrentEnemy => _enemyIter.Current;

        public bool hasNextEnemy => _enemyIter.MoveNext();

        public void nextWave() => loadWave();
    }
}
