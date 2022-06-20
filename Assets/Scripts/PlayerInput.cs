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
        // ��ü List�� Process�� �������ְ�
        // InputCheck�� ���ִ� ������� ����

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