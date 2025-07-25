using PlantsVsZombies.Interfaces;

namespace PlantsVsZombies.CoolDown;

internal interface ICoolDown: IUpdatable
{
    void Update();
    bool IsReady();
}
