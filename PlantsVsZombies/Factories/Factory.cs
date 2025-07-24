using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Factories;

abstract class Factory
{
    public abstract void CreateNew(Vector2i position);
}
