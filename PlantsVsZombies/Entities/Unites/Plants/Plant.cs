using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Plants;

internal abstract class Plant : Unit
{
    protected bool _isEnemyDetected;
    protected Bullet _bullet;
    
    protected Plant(SceneContext sceneContext, Vector2i position, char symbol, int health, Bullet bullet)
            : base(sceneContext, position, symbol, health)
    {
        _isEnemyDetected = false;
        _bullet = bullet;
        Health = health;
    }

    public abstract void Shoot();
    public abstract void DetectEnemy();
}
