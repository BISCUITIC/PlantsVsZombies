using PlantsVsZombies.Interfaces;

namespace PlantsVsZombies.Entities;

internal class EntityPlenty : IUpdatable, IDrawable
{
    protected List<Entity> _data;
    public List<Entity> Data { get => _data; }

    public EntityPlenty()
    {
        _data = new List<Entity>();
    }

    public virtual void Add(Entity plant)
    {
        _data.Add(plant);
    }

    public virtual void Remove(List<Entity> removeList)
    {
        foreach (Entity item in removeList)
        {
            _data.Remove(item);
        }
    }

    public virtual void Update()
    {
        List<Entity> removeList = new List<Entity>();
        foreach (Entity? entity in _data)
        {
            if (entity.IsAlive)
            {
                entity.Update();
            }
            else
            {
                removeList.Add(entity);
            }
        }
        Remove(removeList);
    }

    public virtual void Draw()
    {
        foreach (Entity entity in _data)
        {
            entity.Draw();
        }
    }
}
