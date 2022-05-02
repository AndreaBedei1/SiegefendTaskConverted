namespace OOP21_task_cSharp.Bedei
{
    /// <summary>
    /// Only partial interface not implementation of this interface.
    /// </summary>
    public interface IEnemyController
    {
        /// <summary>
        /// Removes the <paramref name="enemyManager"/> from the list of a Wave.
        /// </summary>
        /// <param name="enemyManager">Is the element of the list that has to be removed.</param>
        public void RemoveEnemy(IEnemyManager enemyManager);
    }
}
