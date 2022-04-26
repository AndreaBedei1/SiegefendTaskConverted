using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bedei
{
    public class Pair<A, B>
    {
        public A X { get; }
        public B Y { get; }

        /// <summary>
        /// Sets the x and y field.
        /// </summary>
        /// <param name="x">number</param>
        /// <param name="y">number</param>
        public Pair(A x, B y)
        {
            X = x;
            Y = y;
        }

        public static Pair<A, B> From(A x, B y) => new Pair<A, B>(x, y);

        public override bool Equals(object? obj) => obj is Pair<A, B> pair && EqualityComparer<A>.Default.Equals(X, pair.X) && EqualityComparer<B>.Default.Equals(Y, pair.Y);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override string ToString() => "Pair [x=" + X + ", y=" + Y + "]";
    }
}
