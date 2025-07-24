using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Interfaces.Providers;

namespace PlantsVsZombies.Entities.Bullets;

internal class BulletsPool : EntityPlenty<Bullet>, IBulletPoolProvider
{
}
