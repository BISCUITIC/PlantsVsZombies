using PlantsVsZombies.Abstractions;
using PlantsVsZombies.Game;

namespace PlantsVsZombies.User;

internal class Cursor : SceneObject
{
    private readonly PlayerInput _playerInput;
    private const char _symbol = '*';

    public Cursor(SceneContext sceneContext, PlayerInput playerInput) : base(sceneContext)
    {
        _playerInput = playerInput;
    }

    public override void Update()
    {
        ConsoleKeyInfo key = _playerInput.GetLastPressedKey();
        switch (key.Key)
        {
            case ConsoleKey.W:
                _position.Y -= 1;
                break;
            case ConsoleKey.S:
                _position.Y += 1;
                break;
            case ConsoleKey.A:
                _position.X -= 1;
                break;
            case ConsoleKey.D:
                _position.X += 1;
                break;
        }
    }

    public override void Draw()
    {
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write(_symbol);
    }

}
