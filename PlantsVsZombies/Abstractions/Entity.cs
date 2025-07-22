using PlantsVsZombies.Game;

namespace PlantsVsZombies.Abstractions;

internal abstract class Entity : GameObject
{
    protected int _health;
    public Entity(SceneContext sceneContext) : base(sceneContext) { }
}
