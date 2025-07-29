using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;
using PlantsVsZombies.Interfaces.Providers;

namespace PlantsVsZombies.Abstractions;

internal abstract class SceneObject : IDrawable
{
    private IBoundsProvider _bounds;
    private SceneObjectPosition _position;

    public SceneObjectPosition Position => _position;
    protected IBoundsProvider Bounds => _bounds;

    public SceneObject(IBoundsProvider bounds, Vector2i position)
    {
        _bounds = bounds;
        _position = new SceneObjectPosition(position, bounds.GetRect());        
    }
    
    public abstract void Draw();
}
