using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class Projectail : MonoBehaviour, IInteractable
{
    [SerializeField] private Spawner<Projectail> _pool;    

    private float _lifeTime = 10f;
    private CollisionHandler _handler;

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;

        StartCoroutine(Count());   
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Deactivate()
    {
        _pool.PutObject(this);
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Player || interactable is Enemy)
        {
            StopCoroutine(Count());

            _pool.PutObject(this);
        }
    }

    private IEnumerator Count()
    {
        yield return new WaitForSeconds(_lifeTime);

        _pool.PutObject(this);
    }
}