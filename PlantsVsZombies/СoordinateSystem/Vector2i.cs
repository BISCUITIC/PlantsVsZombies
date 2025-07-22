namespace PlantsVsZombies.СoordinateSystem;

internal class Vector2i
{
    protected int _x;
    protected int _y;

    virtual public int X { get => _x; set => _x = value; }
    virtual public int Y { get => _y; set => _y = value; }

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
}
