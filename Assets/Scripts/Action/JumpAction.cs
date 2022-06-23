using System.Collections;
using UnityEngine;

public class JumpAction : Action
{
    private CharacterMovement _movement;
    private CharacterRigidbody _rigidbody;

    [SerializeField]
    private int jumpPower = 1000;

    private void Awake()
    {
        _movement = GetComponent<CharacterMovement>();
        _rigidbody = GetComponent<CharacterRigidbody>();
    }

    protected override bool CheckCondition()
    {
        return _rigidbody.IsGround;
    }

    protected override void Execute()
    {
        _movement.AddForce(Vector2.up * jumpPower);
    }
}
