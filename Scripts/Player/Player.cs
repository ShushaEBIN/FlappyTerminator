using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(ScoreCounter), typeof(CollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerProjectailSpawner _pool;

    private PlayerMover _playerMover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _handler;

    public event Action GameOver;

    public void Reset()
    {
        _scoreCounter.Reset();
        _playerMover.Reset();
        _pool.DeactivateObjects();
    }

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<CollisionHandler>();
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
        if (interactable is Obstacle || interactable is Enemy || interactable is Projectail)
        {
            GameOver?.Invoke();
        }
    }   
}