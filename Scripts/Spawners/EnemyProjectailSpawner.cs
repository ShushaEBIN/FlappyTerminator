using System.Collections;
using UnityEngine;

public class EnemyProjectailSpawner : Spawner<Projectail>
{
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        StartCoroutine(GenerateProjectail());
    }

    private IEnumerator GenerateProjectail()
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
        float spawnPositionX = transform.position.x - 1f;
        float spawnPositionZ = 0;
        var projectail = GetObject();

        projectail.gameObject.SetActive(true);
        projectail.transform.position = new Vector3(spawnPositionX, transform.position.y, spawnPositionZ);
    }
}