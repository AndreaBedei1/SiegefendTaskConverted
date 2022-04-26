using System;

namespace OOP21_task_cSharp.Bedei
{
	/// <summary>
	/// Represents a pair of spatial coordinates on the map. 
	/// </summary>
	public class Position
	{
		public double X { get; set; }
		public double Y { get; set; }

		/// <summary>
		///  Creates a new instance of Position.
		/// </summary>
		/// <param name="x">The x coordinate of the position.</param> 
		/// <param name="y">The y coordinate of the position.</param> 
		public Position(double x, double y) => SetCoordinates(x, y);

        /// <summary>
        /// Creates a new instance of Position from another instance of position.
        /// </summary>
        /// <param name="pos">the instance of position to copy.</param>
        public Position(Position pos) : this(pos.X, pos.Y) { }

        /// <summary>
        /// Sets both coordinates of the position.
        /// </summary>
        /// <param name="x">The x coordinate of the position.</param> 
        /// <param name="y">The y coordinate of the position.</param> 
        public void SetCoordinates(double x, double y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		/// Calculates the distance from another position.
		/// </summary>
		/// <param name="pos">the other position</param> 
		/// <returns>the distance</returns>
		public double DistanceTo(Position pos) => Math.Sqrt(Math.Pow(pos.X - X, 2) + Math.Pow(pos.Y - Y, 2));

		/// <summary>
		/// Returns the angle between two positions in radians.
		/// </summary>
		/// <param name="targer">the other position</param>
		/// <returns>the angle in radians</returns>
		public double GetAngle(Position targer) => Math.Atan2(targer.Y - Y, targer.X - X);

		public override bool Equals(object? obj) => obj is Position position && X == position.X && Y == position.Y;

		public override int GetHashCode() => HashCode.Combine(X, Y);

		public override string ToString() => "Position [x=" + X + ", y=" + Y + "]";
	}
}
