using InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.right * InputManager.Instance.GetAxisKey(AxisKeyName.Horizontal) * 5;
        _characterMovement.AddForce(direction);
    }
}