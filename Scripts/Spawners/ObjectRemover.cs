using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemySpawner _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.PoolProjectail.DeactivateObjects();
            _pool.PutObject(enemy);
        }
    }
}