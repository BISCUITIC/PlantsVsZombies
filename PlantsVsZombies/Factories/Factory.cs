using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Factories;

abstract class Factory
{
    public abstract void AddNewObjectAtPool(Vector2i position);
}
