using PlantsVsZombies.Abstractions;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities;

internal abstract class Entity : GameObject
{
    private char _symbol;
    private bool _isAlive;
    public bool IsAlive{ get => _isAlive; protected set => _isAlive = value; }
    
    protected Entity(IBoundsProvider bounds, Vector2i position, char symbol) 
            : base(bounds, position)
    {
        _isAlive = true;
        _symbol = symbol;
    }

    public override void Draw()
    {
        if (!_isAlive) return;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(_symbol);
    }

}
