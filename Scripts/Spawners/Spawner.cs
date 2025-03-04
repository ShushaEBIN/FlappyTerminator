using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected Transform Container;
    [SerializeField] protected List<T> Objects;
    [SerializeField] private T _prefab;

    protected Queue<T> Pool;

    private void Awake()
    {
        Pool = new Queue<T>();
        Objects = new List<T>();
    }

    public void PutObject(T obj)
    {
        Objects.Remove(obj);
        Pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
    
    public void DeactivateObjects()
    {
        var objectsToDeactivate = new List<T>(Objects);

        foreach (T obj in objectsToDeactivate)
        {
            PutObject(obj);
        }
    }

    protected T GetObject()
    {
        if (Pool.Count == 0)
        {
            T obj = Instantiate(_prefab);
            obj.transform.parent = Container;
            Objects.Add(obj);

            return obj;
        }
        else
        {
            T obj = Pool.Dequeue();
            Objects.Add(obj);

            return obj;
        }   
    }
}