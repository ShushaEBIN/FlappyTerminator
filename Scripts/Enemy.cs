using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private EnemySpawner _pool;
    [SerializeField] private EnemyProjectailSpawner _poolProjectail;
    [SerializeField] private ScoreCounter _scoreCounter;

    private CollisionHandler _handler;

    public EnemyProjectailSpawner PoolProjectail { get; private set; }

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
        PoolProjectail = _poolProjectail;
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Projectail)
        {
            _poolProjectail.DeactivateObjects();
            _pool.PutObject(this);
            
            _scoreCounter.IncreaseScore();
        }
    }
}