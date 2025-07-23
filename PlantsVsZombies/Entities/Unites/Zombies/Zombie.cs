using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Zombies;

internal class Zombie : Unit
{
    protected IPlantsPoolProvider _plants;
    protected bool _canGo;    
    protected bool _isAchivedEnd;
    protected int _damage;
    protected const int _speed = 1;

    public event Action? AchivedEnd;

    public Zombie(IBoundsProvider bounds, IPlantsPoolProvider plants, Vector2i position, char symbol, int health, int damage)
         : base(bounds, position, symbol, health)
    {         
        _canGo = true;
        _isAchivedEnd = false;
        _plants = plants;
        _damage = damage;
    }
    public override void Update()
    {
        if (!_isAchivedEnd)
        {            
            Go();
            CheckForCollision();
        }
    }

    protected virtual void Go()
    {
        Position.X -= _speed;
    }
    protected virtual void Stay()
    {
        Position.X += _speed;
    }


    protected virtual void CheckForCollision()
    {
        if (Position.IsOnBound)
        {
            _isAchivedEnd = true;
            AchivedEnd?.Invoke();
            return;
        }
        foreach (Plant plant in _plants.GetPlantsPool())
        {
            if (plant.Position == Position)
            {
                plant.TakeDamage(_damage);
                Stay();
                return;
            }
        }
    }



}
