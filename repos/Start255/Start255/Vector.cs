using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start255
{
    struct Vector
    {
        public Vector(double x,double y,double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector(Vector v) {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public override string ToString() => $"({X},{Y},{Z})";
        public static Vector operator +(Vector left, Vector right) => new Vector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        public static bool operator ==(Vector left, Vector right) {
            if (object.ReferenceEquals(left, right)) return true;
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
        }
        public static bool operator !=(Vector left, Vector right) => !(left == right);
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return this == (Vector)obj;
        }
        public override int GetHashCode() => X.GetHashCode() + (Y.GetHashCode()<<4) + (Z.GetHashCode() << 8);
      
    }
}
