using OOP21_task_cSharp.Bedei;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Class that creates bullets.
    /// </summary>
    public interface IBulletFactory
    {
        IBullet CreateBullet(int id, double speed, Position startPosition, double damage, IEnemy enemyTarget);
    }
}
