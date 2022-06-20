using System.Collections;
using UnityEngine;

public class HoriziontalMoveAction : Action
{
    private float axisValue;
    public float AxisValue { set => axisValue = value; }

    protected override bool CheckCondition()
    {
        // TODO
        // 이동가능한 상태라면
        return true;
    }

    protected override void Execute()
    {
        // TODO
        // _character의 RigidBody에 속도넣어주기
    }
}
