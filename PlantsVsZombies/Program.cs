using PlantsVsZombies.Game;

namespace PlantsVsZombies;

internal class Program
{
    static void Main(string[] args)
    {        
        Console.CursorVisible = false;        

        Scene scene = new Scene();

        //Task.Delay(5000).Wait();
        while (scene.IsActive)
        {
            scene.Update();
            scene.Draw();
            Task.Delay(200).Wait();
        }
    }
}
