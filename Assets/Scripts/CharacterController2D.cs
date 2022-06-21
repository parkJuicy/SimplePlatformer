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

    [SerializeField, Range(2, 10)]
    private int raycastCount = 3;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
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
        int rightOffset = deltaMovement.x > 0 ? 1 : -1;

        for (int i = 0; i < raycastCount - 1; i++)
        {
            float yOffset = (_collider.size.y) / (raycastCount - 1);
            float xPosition = (transform.position.x + (_collider.size.x / 2) * rightOffset);
            float yPosition = (transform.position.y + (_collider.size.y / 2) - yOffset * i);
            Vector2 rayOrigin = new Vector2(xPosition, yPosition);
            Vector2 rayDirection = Vector2.right * rightOffset;
            float rayDistance = Mathf.Abs(deltaMovement.x);

            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);
            var hit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, layerMask);
            if (hit)
            {
                deltaMovement.x = (Mathf.Abs(hit.point.x - transform.position.x) - (_collider.bounds.size.x) / 2) * rightOffset;
            }
        }
    }

    private void MoveVertical(ref Vector2 deltaMovement)
    {
        int upOffset = deltaMovement.y > 0 ? 1 : -1;

        for (int i = 0; i < raycastCount; i++)
        {
            float xOffset = (_collider.size.x) / (raycastCount - 1);
            float xPosition = (transform.position.x + (_collider.size.x / 2) - xOffset * i);
            float yPosition = (transform.position.y + (_collider.size.y / 2) * upOffset);
            Vector2 rayOrigin = new Vector2(xPosition, yPosition);
            Vector2 rayDirection = Vector2.right * upOffset;
            float rayDistance = Mathf.Abs(deltaMovement.y);

            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);
            var hit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, layerMask);
            if (hit)
            {
                deltaMovement.y = (Mathf.Abs(hit.point.y - transform.position.y) - (_collider.bounds.size.y) / 2) * upOffset;
            }
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
