using PlantsVsZombies.Entities.Unites.Zombies;

namespace PlantsVsZombies.Interfaces;

internal interface IEnemyPoolProvider
{
    List<Zombie> GetZombiesPool();
}
