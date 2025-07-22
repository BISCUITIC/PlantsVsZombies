using PlantsVsZombies.Game;

namespace PlantsVsZombies.Abstractions
{
    abstract class GameObject : SceneObject
    {
        public GameObject(SceneContext sceneContext) : base(sceneContext) { }
    }
}
