using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected Transform _container;
    [SerializeField] private T _prefab;

    protected Queue<T> _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public void PutObject(T obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
    
    public void DeactivateObjects()
    {
        foreach (var obj in _container.GetComponentsInChildren<T>())
        {
            PutObject(obj);
        }
    }

    protected T GetObject()
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_prefab);
            obj.transform.parent = _container;

            return obj;
        }

        return _pool.Dequeue();
    }
}