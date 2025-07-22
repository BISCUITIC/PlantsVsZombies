using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Game;

internal class SceneContext
{
    private Vector2i _size = new Vector2i(120, 30);
    public Vector2i Size { get => _size; }
}
