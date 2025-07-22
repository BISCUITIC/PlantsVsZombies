namespace PlantsVsZombies.СoordinateSystem;

internal class SceneObjectPosition : Vector2i
{
    private int _maxX;
    private int _maxY;
    public override int X
    {
        get => _x;
        set => _x = SetInBounders(value, 0, _maxX);
    }
    public override int Y
    {
        get => _y;
        set => _y = SetInBounders(value, 0, _maxY);
    }

    private int SetInBounders(int checkableValue, int lowerBound, int upperBound)
    {
        if (checkableValue < lowerBound) return lowerBound;
        if (checkableValue > upperBound - 1) return upperBound - 1;
        return checkableValue;
    }


    public SceneObjectPosition(int x, int y, int maxX, int maxY)
    {
        _maxX = maxX;
        _maxY = maxY;
        X = x;
        Y = y;     
    }

    public SceneObjectPosition(int maxX, int maxY)
        : this(0, 0, maxX, maxY) { }

    public SceneObjectPosition(Vector2i maxValue)
       : this(0, 0, maxValue.X, maxValue.Y) { }

    public SceneObjectPosition(int x, int y, Vector2i maxValue)
        : this(x, y, maxValue.X, maxValue.Y) { }

    public SceneObjectPosition(Vector2i position, Vector2i maxValue)
        : this(position.X, position.Y, maxValue.X, maxValue.Y) { }

    public static bool operator ==(SceneObjectPosition left, SceneObjectPosition right) { return left.X == right.X && left.Y == right.Y; }
    public static bool operator !=(SceneObjectPosition left, SceneObjectPosition right) { return left.X != right.X && left.Y != right.Y; }
}
