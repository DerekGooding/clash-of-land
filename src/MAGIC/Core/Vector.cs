namespace ClashLand.Core;

internal struct Vector(int X, int Y)
{
    public int X { get; set; } = X;
    public int Y { get; set; } = Y;

    public readonly int LengthSquared => (X * X) + (Y * Y);

    public static Vector operator -(Vector v1, Vector v2)
    {
        return new Vector(v1.X - v2.X, v1.Y - v2.Y);
    }
}
