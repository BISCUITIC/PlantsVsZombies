using PlantsVsZombies.Entities.Bullets.Types;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Plants.Types;

internal class PeasShooter : Plant
{
    public PeasShooter(SceneContext sceneContext, Vector2i position)
         : base(sceneContext, position, '#', 100, new PearBullet(sceneContext, position))
    {

    }

    public override void Shoot()
    {
        //Console.WriteLine($"Коичество: {_sceneContext.BulletsPool.Data.Count}");
        _sceneContext.BulletsPool.Add(new PearBullet(_sceneContext, _position));
    }

    public override void DetectEnemy()
    {
        _isEnemyDetected = true;
    }

    public override void Update()
    {
        DetectEnemy();

        if (_isEnemyDetected)
        {
            Shoot();
        }
    }

    public override void Draw()
    {
        base.Draw();
    }
}
