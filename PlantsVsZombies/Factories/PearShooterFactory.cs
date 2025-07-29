using PlantsVsZombies.Entities.Unites.Plants.Types;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Factories;

internal class PearShooterFactory : PlantFactory
{
    public PearShooterFactory(IBoundsProvider bound, IBulletPoolProvider bulletPool, IEnemyPoolProvider enemyPool, IPlantsPoolProvider plantsPool)
         : base(bound, bulletPool, enemyPool, plantsPool)
    {
    }

    public override void AddNewObjectAtPool(Vector2i position)
    {
        PlantsPool.Add(new PearShooter(Bound, BulletPool, EnemyPool, position));
    }
}
