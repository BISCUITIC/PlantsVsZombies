using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Abstractions;

internal abstract class GameObject : SceneObject, IUpdatable
{
    public GameObject(IBoundsProvider bounds, Vector2i position) : base(bounds, position) { }

    public abstract void Update();
}
