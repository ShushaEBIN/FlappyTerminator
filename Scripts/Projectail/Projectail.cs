using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ProjectailMover), typeof(CollisionHandler))]
public class Projectail : MonoBehaviour, IInteractable
{
    [SerializeField] private Spawner<Projectail> _pool;    

    private float _lifeTime = 2.5f;
    private ProjectailMover _mover;
    private CollisionHandler _handler;

    private void Awake()
    {
        _mover = GetComponent<ProjectailMover>();
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

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Player || interactable is Enemy || interactable is Projectail)
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