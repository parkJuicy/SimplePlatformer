using InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Action Attack;
    private Action Jump;
    private Action Dash;
    private HoriziontalMoveAction HoriziontalMove;

    private void Update()
    {
        // 전체 List로 Process로 실행해주고
        // InputCheck를 해주는 방식으로 수정

        if (InputManager.Instance.GetKey(KeyName.Attack).IsKeyDown)
        {
            Attack.Process();
        }

        if (InputManager.Instance.GetKey(KeyName.Jump).IsKeyDown)
        {
            Jump.Process();
        }

        if (InputManager.Instance.GetKey(KeyName.Dash).IsKeyDown)
        {
            Dash.Process();
        }

        HoriziontalMove.AxisValue = InputManager.Instance.GetAxisKey(AxisKeyName.Horizontal);
        HoriziontalMove.Process();
    }
}