using InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    private JumpAction _jumpAction;
    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _jumpAction = GetComponent<JumpAction>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.right * InputManager.Instance.GetAxisKey(AxisKeyName.Horizontal) * 4;
        _characterMovement.AddForce(direction);


        if (InputManager.Instance.GetKey(KeyName.Jump).IsKeyDown)
        {
            _jumpAction.Process();
        }
    }
}