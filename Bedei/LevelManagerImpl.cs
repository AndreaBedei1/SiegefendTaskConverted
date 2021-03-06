using OOP21_task_cSharp.Notaro;
using System;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    public class LevelManagerImpl : ILevelManager
    {
        /*
         * It was decided to implement this class slightly differently to highlight the different aspects of C#,
         * in particular as regards the iterators, which offer slightly different methods
         * for this reason I decided to change the aspects of passing to the new wave and loading the new enemy.
         * The changes are visible from code.
         * With this mode an empty optional will not be passed (in c# null)
         * but just check if when loading a new enemy/wave the next method will return true or false.
         * I thought of this as the best way.
         */
        private readonly IEnumerator<IWave> _waveIter;
        private IEnumerator<IEnemy>? _enemyIter;
        private IWave? _currentWave;

        public LevelManagerImpl(ILevel level)
        {
            CurrentLevel = level;
            Map = level.Map;
            _waveIter = level.Waves.GetEnumerator();
            LoadWave();
        }

        private void LoadWave()
        {
            if (_waveIter.MoveNext())
            {
                _currentWave = _waveIter.Current;
                _enemyIter = _waveIter.Current.Wave.GetEnumerator();
            }
            else
                throw new NotImplementedException();
        }

        public IMap Map { get; }

        public ILevel CurrentLevel { get; }

        public List<IWave> Waves => CurrentLevel.Waves;

        public int TotalWaves => CurrentLevel.NumberOfWaves;

        public IWave CurrentWave => _currentWave is null ? throw new NullReferenceException() : _currentWave;

        public bool NextWave => _waveIter.MoveNext();

        public IEnemy? CurrentEnemy => _enemyIter is not null ? _enemyIter.Current : throw new NullReferenceException();

        public bool NextEnemy => _enemyIter is not null ? _enemyIter.MoveNext() : throw new NullReferenceException();
    }
}
