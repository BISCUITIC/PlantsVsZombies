using PlantsVsZombies.Interfaces;

namespace PlantsVsZombies.Entities;

internal class EntityPlenty<T> : IUpdatable, IDrawable where T : Entity
{
    protected List<T> _data;
    public List<T> Data { get => _data; }

    public EntityPlenty()
    {
        _data = new List<T>();
    }

    public virtual void Add(T plant)
    {
        _data.Add(plant);
    }

    public virtual void Remove(List<T> removeList)
    {
        foreach (T item in removeList)
        {
            _data.Remove(item);
        }
    }

    public virtual void Update()
    {
        List<T> removeList = new List<T>();
        foreach (T? entity in _data)
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
        foreach (T entity in _data)
        {
            entity.Draw();
        }
    }
}
