using PlantsVsZombies.Abstractions;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities;

internal abstract class Entity : GameObject
{
    protected char _symbol;
    protected bool _isAlive;
    public bool IsAlive => _isAlive;
    
    protected Entity(SceneContext sceneContext, Vector2i position, char symbol) 
            : base(sceneContext, position)
    {
        _isAlive = true;
        _symbol = symbol;
    }

    public override void Update() {    }

    public override void Draw()
    {
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write(_symbol);
    }
}
