using System.Collections.Generic;

namespace OOP21_task_cSharp.Bedei
{
    public class WaveImpl : IWave
    {
        public List<IEnemy> Wave { get; }

        public WaveImpl(List<IEnemy> wave) => Wave = wave;
    }
}
