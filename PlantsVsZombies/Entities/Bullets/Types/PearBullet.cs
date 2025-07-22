using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Bullets.Types;

internal class PearBullet : Bullet
{
    public PearBullet(SceneContext sceneContext, Vector2i position) 
         : base(sceneContext, position, '-', 20)
    {

    }       
}
