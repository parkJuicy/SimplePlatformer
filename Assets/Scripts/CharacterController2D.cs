using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    private BoxCollider2D _collider;
    private int layerMask = (1 << 6);
    private Vector2 _velocity;

    [SerializeField]
    private bool _useGravity;
    private float _gravityScale = -9.8f;


    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void LateUpdate()
    {
        if (_useGravity)
        {
            ApplyGravity();
        }

        Move(_velocity * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        _velocity.y += _gravityScale;
    }

    private void Move(Vector2 deltaMovement)
    {
        MoveHoriziontal(ref deltaMovement);
        MoveVertical(ref deltaMovement);
        transform.Translate(deltaMovement);
        _velocity = Vector2.Lerp(Vector2.zero, _velocity, 0.5f);
    }

    private void MoveHoriziontal(ref Vector2 deltaMovement)
    {
        var isRight = deltaMovement.x > 0;
        var rayDirection = isRight ? Vector2.right : Vector2.left;
        var rayDistance = (_collider.bounds.size.x) / 2 + Mathf.Abs(deltaMovement.x);

        Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.red);

        var hit = Physics2D.Raycast(transform.position, rayDirection, rayDistance, layerMask);
        if (hit)
        {
            deltaMovement.x = (Mathf.Abs(hit.point.x - transform.position.x) - (_collider.bounds.size.x) / 2) * (isRight ? 1 : -1);
        }
    }

    private void MoveVertical(ref Vector2 deltaMovement)
    {
        var isUp = deltaMovement.y > 0;
        var rayDirection = isUp ? Vector2.up : Vector2.down;
        var rayDistance = (_collider.bounds.size.y) / 2 + Mathf.Abs(deltaMovement.y);

        Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.red);

        var hit = Physics2D.Raycast(transform.position, rayDirection, rayDistance, layerMask);
        if (hit)
        {
            deltaMovement.y = (Mathf.Abs(hit.point.y - transform.position.y) - (_collider.bounds.size.y) / 2) * (isUp ? 1 : -1);
        }
    }

    public void AddForce(Vector2 force)
    {
        _velocity += force;
    }

    public void SetVelocity(Vector2 velocity)
    {
        _velocity = velocity;
    }
}
