using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public struct Vector2 : IEquatable<Vector2>, IComparable<Vector2>
    {
        private static readonly double _Sqr = Math.Sqrt(2);
        private readonly int _X;
        private readonly int _Y;
        private readonly int _HashCode;

        public Vector2(int x, int y)
        {
            _X = x;
            _Y = y;
            _HashCode = System.HashCode.Combine(_X, _Y);
        }

        public int X { get { return _X; } }
        public int Y { get { return _Y; } }
        public int HashCode { get { return _HashCode; } }

        public double DistanceEstimate()
        {
            int linearSteps = Math.Abs(Math.Abs(Y) - Math.Abs(X));
            int diagonalSteps = Math.Max(Math.Abs(Y), Math.Abs(X)) - linearSteps;
            return linearSteps + (_Sqr * diagonalSteps);
        }

        public bool Equals(Vector2 other)
        {
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Vector2 vec)
                return false;

            return Equals(vec);
        }

        public override string ToString()
        {
            return $"({X} ; {Y})";
        }

        public override int GetHashCode()
        {
            return this.HashCode;
        }

        public int CompareTo(Vector2 other)
        {
            if (this > other)
                return 1;
            else if (this < other)
                return -1;
            else
                return 0;
        }

        public static Vector2 operator +(Vector2 current, Vector2 other)
        {
            return new Vector2(current.X + other.X, current.Y + other.Y);
        }

        public static Vector2 operator -(Vector2 current, Vector2 other)
        {
            return new Vector2(current.X - other.X, current.Y - other.Y);
        }

        public static bool operator ==(Vector2 current, Vector2 other)
        {
            return current.X == other.X && current.Y == other.Y;
        }

        public static bool operator !=(Vector2 current, Vector2 other)
        {
            return !(current == other);
        }

        public static bool operator >(Vector2 current, Vector2 other)
        {
            return current.X > other.X && current.Y > other.Y;
        }

        public static bool operator <(Vector2 current, Vector2 other)
        {
            return current.X < other.X && current.Y < other.Y;
        }
    }
}
