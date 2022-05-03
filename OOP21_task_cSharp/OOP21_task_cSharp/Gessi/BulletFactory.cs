using OOP21_task_cSharp.Bedei;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Gessi
{
    public class BulletFactory : IBulletFactory
    {
        public IBullet CreateBullet(int id, double speed, Position startPosition, double damage, IEnemy enemyTarget)
        {
            return new Bullet(id, speed, startPosition, damage, enemyTarget);
        }
    }
}
