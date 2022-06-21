using InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour
{
    private CharacterController2D _characterController;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.right * InputManager.Instance.GetAxisKey(AxisKeyName.Horizontal) * 5;
        _characterController.AddForce(direction);

        if(InputManager.Instance.GetKey(KeyName.Jump).IsKeyDown)
        {
        }
    }
}