namespace PlantsVsZombies.СoordinateSystem;

internal class Vector2i
{
    protected int _x;
    protected int _y;

    public virtual int X { get => _x; set => _x = value; }
    public virtual int Y { get => _y; set => _y = value; }

    public static Vector2i Zero => new Vector2i(0, 0);

    public Vector2i()
    {
        X = 0;
        Y = 0;
    }
    public Vector2i(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vector2i operator -(Vector2i left, Vector2i right) { return new Vector2i(left.X - right.X, left.Y - right.Y); }
    public static Vector2i operator +(Vector2i left, Vector2i right) { return new Vector2i(left.X + right.X, left.Y + right.Y); }    
}
