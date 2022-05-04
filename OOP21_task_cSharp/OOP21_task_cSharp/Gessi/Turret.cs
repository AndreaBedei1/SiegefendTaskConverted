using OOP21_task_cSharp.Bedei;
using System;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Class that represents a simple turret.
    /// </summary>
    public class Turret : ITurret, ICloneable
    {
        private double _bulletSpeed;
        private double _bulletDamage;
        private IBulletFactory _bulletFactory;

        /// <summary>
        /// Creates a new instance of Turret.
        /// </summary>
        /// <param name="id">the id of the turret</param>
        /// <param name="position">the initial <see cref="Position"/> of the turret</param>
        /// <param name="range">the range of the turret</param>
        /// <param name="price">the price of the turret</param>
        /// <param name="fireRate">the fire rate of the turret</param>
        /// <param name="bulletSpeed">the speed of the <see cref="IBullet"/></param>
        /// <param name="bulletDamage">the damage of the <see cref="IBullet"/></param>
        public Turret(int id, Position? position, double range, int price, double fireRate, double bulletSpeed, double bulletDamage)
        {
            ID = id;
            Position = position != null ? new Position(position) : null;
            Range = range;
            Price = price;
            FireRate = fireRate;
            _bulletSpeed = bulletSpeed;
            _bulletDamage = bulletDamage;
            _bulletFactory = new BulletFactory();
            Angle = Math.PI / 4;
            
        }
        public int ID { get; set; }
        public Position? Position { get; set; }
        public double Range { get; set; }
        public double Angle { get; set; }
        public bool State { get; set; }
        public IBullet? CreateBullet()
        {
            if (Target is not null && Position is not null)
            {
                return _bulletFactory.CreateBullet(ID, _bulletSpeed, Position, _bulletDamage, Target);
            }
            return null;
        }
        public double FireRate { get; set; }
        public IEnemy? Target { get; set; }
        public int Price { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public ITurret GetClone()
        {
            return (ITurret) Clone();
        }
        public override int GetHashCode()
        {
            // HashCode.Combine(...) can't take 11 arguments, so I opted for this solution.
            HashCode hash = new HashCode();
            hash.Add(Angle);
            hash.Add(_bulletDamage);
            hash.Add(_bulletFactory);
            hash.Add(_bulletSpeed);
            hash.Add(FireRate);
            hash.Add(ID);
            hash.Add(Position);
            hash.Add(Price);
            hash.Add(Range);
            hash.Add(State);
            hash.Add(Target);
            return hash.ToHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (!GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Turret other = (Turret)obj;
            return BitConverter.DoubleToInt64Bits(Angle) == BitConverter.DoubleToInt64Bits(other.Angle)
                    && BitConverter.DoubleToInt64Bits(_bulletDamage) == BitConverter.DoubleToInt64Bits(other._bulletDamage)
                    && Object.Equals(_bulletFactory, other._bulletFactory)
                    && BitConverter.DoubleToInt64Bits(_bulletSpeed) == BitConverter.DoubleToInt64Bits(other._bulletSpeed)
                    && BitConverter.DoubleToInt64Bits(FireRate) == BitConverter.DoubleToInt64Bits(other.FireRate) && ID == other.ID
                    && Object.Equals(Position, other.Position) && Price == other.Price
                    && BitConverter.DoubleToInt64Bits(Range) == BitConverter.DoubleToInt64Bits(other.Range) && State == other.State
                    && Object.Equals(Target, other.Target);
        }
        public override string ToString()
        {
            return "Turret [ID=" + ID + ", position=" + Position + ", range=" + Range + ", price=" + Price
                           + ", fireRate=" + FireRate + ", bulletSpeed=" + _bulletSpeed + ", bulletDamage=" + _bulletDamage + "]";
        }
    }
}
