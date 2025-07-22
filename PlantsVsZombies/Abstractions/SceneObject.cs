using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Abstractions;

internal abstract class SceneObject : IUpdatable, IDrawable
{
    protected SceneObjectPosition _position;
    protected SceneContext _sceneContext;

    public SceneObject(SceneContext sceneContext, Vector2i position)
    {
        _sceneContext = sceneContext;
        _position = new SceneObjectPosition(position, _sceneContext.Size);
    }

    public abstract void Update();
    public abstract void Draw();
}
