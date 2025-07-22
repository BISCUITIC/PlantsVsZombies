using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Bullets
{
    internal abstract class Bullet : Entity
    {
        protected int _damage;

        public int Damage => _damage;
        public Bullet(SceneContext sceneContext, Vector2i position) : base(sceneContext, position)
        {

        }
    }
}
