using PlantsVsZombies.Abstractions;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities;

internal abstract class Entity : GameObject
{
    protected char _symbol;
    protected bool _isAlive;
    public bool IsAlive => _isAlive;
    
    protected Entity(IBoundsProvider bounds, Vector2i position, char symbol) 
            : base(bounds, position)
    {
        _isAlive = true;
        _symbol = symbol;
    }

    public override void Update() {    }

    public override void Draw()
    {
        if (!_isAlive) return;
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write(_symbol);
    }
}
