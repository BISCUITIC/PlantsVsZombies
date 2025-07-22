﻿using PlantsVsZombies.Interfaces;

namespace PlantsVsZombies.User;

internal class PlayerInput : IUpdatable
{
    private ConsoleKeyInfo _lastPressedKey;
    public void Update()
    {
        while (Console.KeyAvailable)
            _lastPressedKey = Console.ReadKey(true);
    }
    public ConsoleKeyInfo GetLastPressedKey() => _lastPressedKey;
}
