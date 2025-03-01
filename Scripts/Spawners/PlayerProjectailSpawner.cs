using UnityEngine;

public class PlayerProjectailSpawner : Spawner<Projectail>
{
    [SerializeField] private InputHandler _handler;

    private void Update()
    {
        if (_handler.ReturnShootPressed())
        {
            GenerateProjectail();
        }
    }

    private void GenerateProjectail()
    {
        float spawnPositionX = transform.position.x + 1f;
        float spawnPositionZ = 0;
        var projectail = GetObject();

        projectail.gameObject.SetActive(true);
        projectail.transform.position = new Vector3(spawnPositionX, transform.position.y, spawnPositionZ);
    }
}