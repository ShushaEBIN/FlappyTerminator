using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    public void Reset()
    {
        foreach (var enemy in _container.GetComponentsInChildren<Enemy>())
        {
            enemy.PoolProjectail.DeactivateObjects();
            PutObject(enemy);
        }
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    private IEnumerator GenerateEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        var enemy = GetObject();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        float spawnPositionX = transform.position.x + 12f;
        float spawnPositionZ = 0f;
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);

        return new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
    }   
}