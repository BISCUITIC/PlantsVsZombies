using PlantsVsZombies.Abstractions;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities;

internal abstract class Entity : GameObject
{   
    protected bool _isAlive;
    protected char _symbol;
    public Entity(SceneContext sceneContext, Vector2i position) : base(sceneContext, position) { }
}
