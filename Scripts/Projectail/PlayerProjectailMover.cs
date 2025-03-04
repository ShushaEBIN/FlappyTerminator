using UnityEngine;

public class PlayerProjectailMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerMover _playerMover;

    private Vector2 _direction;

    private void OnEnable()
    {
        _direction = _playerMover.Direction;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}