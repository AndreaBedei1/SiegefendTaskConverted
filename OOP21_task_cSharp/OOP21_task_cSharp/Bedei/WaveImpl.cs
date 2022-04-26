using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    internal class WaveImpl : IWave
    {
        private readonly List<IEnemy> _wave;
        List<IEnemy> IWave.EnemyList => _wave;
    
        public WaveImpl(List<IEnemy> wave) => _wave = wave;
    }
}
