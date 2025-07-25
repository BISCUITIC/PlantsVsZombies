using PlantsVsZombies.Abstractions;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.User;

internal class Cursor : SceneObject
{
    private readonly PlayerInput _playerInput;
    private const char _symbol = ':';

    public Cursor(IBoundsProvider bounds, Vector2i position, PlayerInput playerInput) : base(bounds, position)
    {
        _playerInput = playerInput;
    }

    public override void Update()
    {
        ConsoleKeyInfo? key = _playerInput.GetLastPressedKey();
        switch (key?.Key)
        {
            case ConsoleKey.W:
                Position.Y -= 1;
                break;
            case ConsoleKey.S:
                Position.Y += 1;
                break;
            case ConsoleKey.A:
                Position.X -= 1;
                break;
            case ConsoleKey.D:
                Position.X += 1;
                break;
            case null:
                break;
        }
    }

    public override void Draw()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(_symbol);
    }

}
