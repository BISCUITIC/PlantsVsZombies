using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;
using PlantsVsZombies.Interfaces.Providers;

namespace PlantsVsZombies.Abstractions;

internal abstract class SceneObject : IUpdatable, IDrawable
{
    protected IBoundsProvider _bounds;
    protected SceneObjectPosition _position;
    public SceneObjectPosition Position => _position;

    public SceneObject(IBoundsProvider bounds, Vector2i position)
    {
        _bounds = bounds;
        _position = new SceneObjectPosition(position, bounds.GetRect());
        //Console.WriteLine(_position);
    }

    public abstract void Update();
    public abstract void Draw();
}
