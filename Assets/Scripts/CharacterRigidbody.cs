using System.Collections;
using UnityEngine;

public class CharacterRigidbody : MonoBehaviour
{
    private BoxCollider2D _collider;

    [SerializeField, Range(2, 10)]
    private int _rayCastCount = 3;
    private int _layerMask = (1 << 6) | (1 << 7);
    private float _skinWidth = 0.01f;

    [Header("State")]
    private bool _isGround;
    public bool IsGround { get => _isGround; }

    private void Awake()
    {

        _collider = GetComponent<BoxCollider2D>();
    }

    public void CheckHorizontalCollision(ref Vector2 deltaMovement)
    {
        if (deltaMovement.x == 0)
            return;

        int rightValue = deltaMovement.x > 0 ? 1 : -1;
        for (int i = 0; i < _rayCastCount; i++)
        {
            float offset = (_collider.size.y) / (_rayCastCount - 1) - _skinWidth;
            float rayPositionX = (transform.position.x + (_collider.size.x / 2) * rightValue);
            float rayPositionY = (transform.position.y + (_collider.size.y / 2) - offset * i);
            Vector2 rayPosition = new Vector2(rayPositionX, rayPositionY);
            Vector2 rayDirection = Vector2.right * rightValue;
            float rayDistance = Mathf.Abs(deltaMovement.x);

            Debug.DrawRay(rayPosition, rayDirection * rayDistance, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayDirection, rayDistance, _layerMask);
            if (hit)
            {
                if (hit.collider.gameObject.layer == 7)
                    continue;

                float delta = (Mathf.Abs(hit.point.x - transform.position.x) - (_collider.bounds.size.x) / 2 - _skinWidth) * rightValue;
                deltaMovement.x = delta > _skinWidth ? delta : 0;
            }
        }
    }

    public void CheckVerticalCollision(ref Vector2 deltaMovement)
    {
        if (deltaMovement.y == 0)
            return;

        _isGround = false;
        int upValue = deltaMovement.y > 0 ? 1 : -1;
        for (int i = 0; i < _rayCastCount; i++)
        {
            float offset = (_collider.size.x) / (_rayCastCount - 1);
            float rayPositionX = (transform.position.x + (_collider.size.x / 2) - offset * i);
            float rayPositionY = (transform.position.y + (_collider.size.y / 2) * upValue);
            Vector2 rayPosition = new Vector2(rayPositionX, rayPositionY);
            Vector2 rayDirection = Vector2.up * upValue;
            float rayDistance = Mathf.Abs(deltaMovement.y);

            Debug.DrawRay(rayPosition, rayDirection * rayDistance, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayDirection, rayDistance, _layerMask);
            if (hit)
            {
                if (deltaMovement.y > 0 && hit.collider.gameObject.layer == 7)
                    continue;

                deltaMovement.y = (Mathf.Abs(hit.point.y - transform.position.y) - (_collider.bounds.size.y) / 2) * upValue;
                if (deltaMovement.y <= 0)
                    _isGround = true;
                return;
            }
        }
    }
}
