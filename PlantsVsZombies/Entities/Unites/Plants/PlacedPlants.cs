using PlantsVsZombies.Interfaces;

namespace PlantsVsZombies.Entities.Unites.Plants;

internal class PlacedPlants : EntityPlenty<Plant>, IPlantsPoolProvider
{
    public List<Plant> GetPlantsPool()
    {
        return Data;
    }
}
