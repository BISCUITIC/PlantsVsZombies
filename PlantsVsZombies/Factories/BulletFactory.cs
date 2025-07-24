using PlantsVsZombies.Interfaces.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsVsZombies.Factories
{
    abstract class BulletFactory: Factory
    {
        private readonly IBoundsProvider _bounds;
        private readonly IEnemyPoolProvider _enemyProvider;
        private readonly IBulletPoolProvider _bullets;

        protected IBoundsProvider Bounds => _bounds;
        protected IEnemyPoolProvider EnemyProvider => _enemyProvider;
        protected IBulletPoolProvider Bullets => _bullets;

        public BulletFactory(IBoundsProvider bounds, IEnemyPoolProvider enemyProvider, IBulletPoolProvider bullets)
        {
            _bounds = bounds;
            _bullets = bullets;
            _enemyProvider = enemyProvider;        
        }
    }
}
