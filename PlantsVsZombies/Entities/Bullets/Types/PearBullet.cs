using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Bullets.Types;

internal class PearBullet : Bullet
{
    public PearBullet(IBoundsProvider bounds, IEnemyPoolProvider enemyProvider, Vector2i position)
         : base(bounds, enemyProvider, position, '-', 20)
    {

    }
}
