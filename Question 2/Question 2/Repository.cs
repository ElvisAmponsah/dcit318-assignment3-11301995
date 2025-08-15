using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> GetAll()
    {
        return items;
    }

    public T? GetById(Func<T, bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }

    public bool Remove(Func<T, bool> predicate)
    {
        var item = items.FirstOrDefault(predicate);
        if (item != null)
        {
            items.Remove(item);
            return true;
        }
        return false;
    }

    public bool Update(Func<T, bool> predicate, T updatedItem)
    {
        var item = items.FirstOrDefault(predicate);
        if (item != null)
        {
            items.Remove(item);
            items.Add(updatedItem);
            return true;
        }
        return false;
    }

    public List<T> FindAll(Func<T, bool> predicate)
    {
        return items.Where(predicate).ToList();
    }

    public int Count()
    {
        return items.Count;
    }

    public bool Exists(Func<T, bool> predicate)
    {
        return items.Any(predicate);
    }
}
