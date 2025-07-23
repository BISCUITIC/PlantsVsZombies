using PlantsVsZombies.Interfaces;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;

namespace PlantsVsZombies.Entities.Unites.Zombies;

internal class ZombiesPool : EntityPlenty<Zombie>, IEnemyPoolProvider
{
    public List<Zombie> GetZombiesPool()
    {
        return Data;
    }
}
