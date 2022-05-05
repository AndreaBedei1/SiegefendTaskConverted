namespace OOP21_task_cSharp.Bedei
{
    public interface IEnemyManager
    {
        /// <summary>
        /// Takes the enemy.
        /// </summary>
        public IEnemy Enemy { get; }

        /// <summary>
        /// Deletes the enemy in the list of the enemyController.
        /// </summary>
        public void Disappear();

        /// <summary>
        /// Stops the thread.
        /// </summary>
        public void StopTread();
    }
}
