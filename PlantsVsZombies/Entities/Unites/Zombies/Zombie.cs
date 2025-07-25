using PlantsVsZombies.CoolDown;
using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Zombies;

internal class Zombie : Unit
{
    private IPlantsPoolProvider _plants;
    private ICoolDown _moveCoolDown;
    private bool _canMove;
    private bool _isAchivedEnd;
    private int _damage;    

    public event Action? AchivedEnd;

    public Zombie(IBoundsProvider bounds, IPlantsPoolProvider plants, ICoolDown moveCoolDown, 
                  Vector2i position, char symbol, int health, int damage)
         : base(bounds, position, symbol, health)
    {
        _canMove = true;
        _isAchivedEnd = false;
        _plants = plants;
        _damage = damage;
        _moveCoolDown = moveCoolDown;
    }
    public override void Update()
    {
        _moveCoolDown.Update();

        if (!_isAchivedEnd)
        {
            CheckForCollision();
            if(_canMove && _moveCoolDown.IsReady()) Move();
        }
    }

    protected virtual void Move()
    {
        Position.X -= 1;
    }

    protected virtual void CheckForCollision()
    {
        _canMove = true;
        if (Position.IsOnBound)
        {
            AchivedEnd?.Invoke();
            _isAchivedEnd = true;
            _canMove = false;
            return;
        }
        foreach (Plant plant in _plants.Get())
        {
            if (plant.Position.Y == Position.Y && plant.Position.X == Position.X - 1)
            {
                plant.TakeDamage(_damage);
                _canMove = false;
                return;
            }
        }
    }
}
