using PlantsVsZombies.Entities.Unites.Zombies.Types;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Factories;

abstract class ZombieFactory:Factory
{
    private readonly IEnemyPoolProvider _enemies;
    private readonly IPlantsPoolProvider _plant;
    private readonly IBoundsProvider _bounds;
    private readonly Action? _achivedEnd;

    protected IEnemyPoolProvider Enemies => _enemies;
    protected IPlantsPoolProvider Plant => _plant;
    protected IBoundsProvider Bounds  => _bounds;
    protected Action? AchivedEnd  => _achivedEnd;

    public ZombieFactory(IBoundsProvider bounds, IPlantsPoolProvider plant, IEnemyPoolProvider enemyPool, Action? action)
    {
        _plant = plant;
        _achivedEnd = action;
        _bounds = bounds;
        _enemies = enemyPool;
    }
  
}
