using PlantsVsZombies.Entities.Unites.Plants.Types;
using PlantsVsZombies.Interfaces.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsVsZombies.Factories
{
    abstract class PlantFactory: Factory
    {
        private readonly IBoundsProvider _bound;
        private readonly IBulletPoolProvider _bulletPool;
        private readonly IEnemyPoolProvider _enemyPool;
        private readonly IPlantsPoolProvider _plantsPool;

        protected IBoundsProvider Bound => _bound;
        protected IBulletPoolProvider BulletPool => _bulletPool ;
        protected IEnemyPoolProvider EnemyPool => _enemyPool ;
        protected IPlantsPoolProvider PlantsPool => _plantsPool;

        protected PlantFactory(IBoundsProvider bound, IBulletPoolProvider bulletPool, IEnemyPoolProvider enemyPool, IPlantsPoolProvider plantsPool)
        {
            _bound = bound;
            _bulletPool = bulletPool;
            _enemyPool = enemyPool;
            _plantsPool = plantsPool;
        }
        
    }
}
