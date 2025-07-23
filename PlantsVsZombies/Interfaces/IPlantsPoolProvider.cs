using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Entities.Unites.Zombies;

namespace PlantsVsZombies.Interfaces;

internal interface IPlantsPoolProvider
{
    List<Plant> GetPlantsPool();
}
