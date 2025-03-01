using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectailMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }
}