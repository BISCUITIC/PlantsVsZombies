using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Abstractions
{
    internal abstract class GameObject : SceneObject
    {
        public GameObject(SceneContext sceneContext, Vector2i position) : base(sceneContext, position) { }
    }
}
