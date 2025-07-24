using PlantsVsZombies.Entities.Unites.Zombies.Types;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Factories;

internal class SimpleZombieFactory : ZombieFactory
{
    public SimpleZombieFactory(IBoundsProvider bounds, IPlantsPoolProvider plant, IEnemyPoolProvider enemyPool, Action? action)
         : base(bounds, plant, enemyPool, action)
    {

    }
    public override void CreateNew(Vector2i position)
    {
        SimpleZombie zombie = new SimpleZombie(Bounds, Plant, position);
        zombie.AchivedEnd += AchivedEnd;
        Enemies.Add(zombie);
    }
}
