using OOP21_task_cSharp.Bedei;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Implementation of a bullet that follows a target.
    /// </summary>
    public class Bullet : IBullet
    {
        private int _id;
        private double _speed;
        private double _damage;
        private Position _position;
        private IEnemy _target;

        public Bullet(int id, double speed, Position position, double damage, IEnemy target)
        {
            ID = id;
            Speed = speed;
            Position = new Position(position);
            Damage = damage;


            if(target == null)
            {
                throw new ArgumentNullException("target");
            }
            else
            {
                Target = target;
            }
        }

        public int ID { get => _id; set => _id = value; }
        public double Speed { get => _speed; set => _speed = value; }
        public Position Position { get => _position; set => _position = value; }
        public IEnemy Target { get => _target; set => _target = value; }
        public Position TargetPosition { get => Target.Position; }
        public double Damage { get => _damage; set => _damage = value; }
        public void Move(double x, double y)
        {
            Position.SetCoordinates(x, y);
        }
    }
}
