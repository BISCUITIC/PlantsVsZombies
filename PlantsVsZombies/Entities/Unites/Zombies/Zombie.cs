using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Zombies;

internal class Zombie : Unit, IMoveable
{
    protected IPlantsPoolProvider _plants;
    protected bool _canMove;    
    protected bool _isAchivedEnd;
    protected int _damage;    

    public event Action? AchivedEnd;

    private const int _moveCoolDown = 4;
    private int _deltaTicks;

    public Zombie(IBoundsProvider bounds, IPlantsPoolProvider plants, Vector2i position, char symbol, int health, int damage)
         : base(bounds, position, symbol, health)
    {
        _canMove = true;
        _isAchivedEnd = false;
        _plants = plants;
        _damage = damage;
    }
    public override void Update()
    {
        _deltaTicks++;

        if (!_isAchivedEnd)
        {
            CheckForCollision();
            if(_canMove && MoveCoolDownIsComplited()) Move();
        }
    }

    public virtual void Move()
    {
        Position.X -= 1;
    }

    public bool MoveCoolDownIsComplited()
    {
        if (_deltaTicks >= _moveCoolDown) { _deltaTicks = 0; return true; }
        return false;
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
