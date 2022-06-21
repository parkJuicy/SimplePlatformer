using System.Collections;
using UnityEngine;

public class CharacterRigidbody : MonoBehaviour
{
    private BoxCollider2D _collider;
    private CharacterMovement _movement;

    [SerializeField]
    private bool _useGravity;
    [SerializeField]
    private float _gravityScale = -9.8f;

    [SerializeField, Range(2,10)]
    private int _rayCastCount = 3;
    private int _layerMask = (1 << 6);
    private const float _skinWidth = 0.02f;

    private void Awake()
    {
        _movement = GetComponent<CharacterMovement>();
        _collider = GetComponent<BoxCollider2D>();
    }

    // 다른 이동관련 로직 먼저 처리하고 Late에서 충돌파악후 최종적인 포지션으로 옮겨주기 위해 LateUpdate
    private void LateUpdate()
    {
        if(_useGravity)
        {
            _movement.AddForce(Vector2.down * _gravityScale);
        }

        CheckHorizontalCollision();
        CheckVerticalCollision();
    }

    private void CheckHorizontalCollision()
    {


    }

    private void CheckVerticalCollision()
    {
        


    }
}
