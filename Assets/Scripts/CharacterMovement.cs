using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterRigidbody _rigidbody;
    private Vector2 _velocity;
    public Vector2 Velocity { get => _velocity; }

    [SerializeField]
    private bool _useGravity;
    [SerializeField]
    private float _gravityScale = 9.8f;

    private void Awake()
    {
        _rigidbody = GetComponent<CharacterRigidbody>();
    }

    public void AddForce(Vector2 force)
    {
        _velocity += force;
    }

    public void SetVelocity(Vector2 velocity)
    {
        _velocity = velocity;
    }

    private void Update()
    {
        if (_useGravity)
        {
            AddForce(Vector2.down * _gravityScale * Time.deltaTime);
        }

        Move(_velocity * Time.deltaTime);
        _velocity.x = Mathf.Lerp(0, _velocity.x, 0.5f);
    }

    // 점프가 부드럽지 않게 작동되는 부분이 있어 
    // https://github.com/vrompasa/2d-platformer-character-controller 에서 참고해서 작업함
    private void Move(Vector2 deltaMovement)
    {
        if (_rigidbody != null)
        {
            _rigidbody.CheckHorizontalCollision(ref deltaMovement);
            _rigidbody.CheckVerticalCollision(ref deltaMovement);
        }
        transform.Translate(deltaMovement);
        if (Time.deltaTime > 0)
            _velocity = deltaMovement / Time.deltaTime;
    }
}
