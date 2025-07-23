namespace PlantsVsZombies.СoordinateSystem;

internal class SceneObjectPosition : Vector2i
{
    private int _maxX, _minX;
    private int _maxY, _minY;
    private bool _isOnBound;
    public bool IsOnBound => _isOnBound;
    public override int X
    {
        get => _x;
        set => _x = SetInBounders(value, _minX, _maxX);
    }
    public override int Y
    {
        get => _y;
        set => _y = SetInBounders(value, _minY, _maxY);
    }

    private int SetInBounders(int checkableValue, int lowerBound, int upperBound)
    {
        _isOnBound = true;
        if (checkableValue < lowerBound + 1) return lowerBound + 1;
        if (checkableValue > upperBound - 2) return upperBound - 2;
        _isOnBound = false;
        return checkableValue;
    }

    public SceneObjectPosition(Vector2i position, Rect bounds)
    {
        _maxX = bounds.RightBottomCorner.X;
        _maxY = bounds.RightBottomCorner.Y;
        _minX = bounds.LeftTopCorner.X;
        _minY = bounds.LeftTopCorner.Y;
        //Console.WriteLine($"min X:{_minX}, Y{_minY}");
        //Console.WriteLine($"max X:{_maxX}, Y{_maxY}");
        X = position.X + _minX;
        Y = position.Y + _minY;
    }
    public SceneObjectPosition(int x, int y, Rect bounds) : this(new Vector2i(x, y), bounds) { }

    public override string ToString() => $"X:{X}, Y:{Y}";

    public static bool operator ==(SceneObjectPosition left, SceneObjectPosition right) { return left.X == right.X && left.Y == right.Y; }
    public static bool operator !=(SceneObjectPosition left, SceneObjectPosition right) { return left.X != right.X && left.Y != right.Y; }
}
