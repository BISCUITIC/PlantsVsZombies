using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Abstractions
{
    internal abstract class GameObject : SceneObject
    {
        public GameObject(IBoundsProvider bounds, Vector2i position) : base(bounds, position) { }
    }
}
