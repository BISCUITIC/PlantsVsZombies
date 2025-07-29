using PlantsVsZombies.Abstractions;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.UI;

internal abstract class UIObject<T> : SceneObject
{
    protected UIObject(IBoundsProvider boundsProvider, Vector2i position)
            : base(boundsProvider, position)
    {

    }

    public abstract void ChangeValue(T newValue);
}
