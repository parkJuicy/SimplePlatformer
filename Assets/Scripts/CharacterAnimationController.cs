using System.Collections;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private CharacterMovement _movement;
    private CharacterRigidbody _rigidbody;
    private Animator _animator;
    private bool _isRightFace = true;

    private const string _horizontalVelocity = "HorizontalVelocity";
    private const string _verticalVelocity = "VerticalVelocity";
    private const string _isGround = "IsGround";

    private void Awake()
    {
        _movement = GetComponent<CharacterMovement>();
        _rigidbody = GetComponent<CharacterRigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CheckCharacterFlip(_movement.Velocity.x);
        SetVelocityValue(_movement.Velocity);
        SetGroundValue(_rigidbody.IsGround);
    }

    public void SetVelocityValue(Vector2 velocity)
    {
        _animator.SetFloat(_horizontalVelocity, Mathf.Abs(velocity.x));
        _animator.SetFloat(_verticalVelocity, velocity.y);
    }

    private void SetGroundValue(bool isGround)
    {
        _animator.SetBool(_isGround, isGround);
    }

    private void CheckCharacterFlip(float horizontalVelocity)
    {
        if ((horizontalVelocity > 0 && !_isRightFace) || (horizontalVelocity < 0 && _isRightFace))
            Flip();
    }

    private void Flip()
    {
        _isRightFace = !_isRightFace;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
