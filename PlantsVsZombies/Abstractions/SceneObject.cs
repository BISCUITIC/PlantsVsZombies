using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Abstractions;

internal abstract class SceneObject : IUpdatable, IDrawable
{
    protected SceneContext _sceneContext;
    protected SceneObjectPosition _position;
    public SceneObjectPosition Position => _position;

    public SceneObject(SceneContext sceneContext, Vector2i position)
    {
        _sceneContext = sceneContext;
        _position = new SceneObjectPosition(position, _sceneContext.Size);
    }

    public abstract void Update();
    public abstract void Draw();
}
