using System.Collections;
using UnityEngine;

public class AttackAction : Action
{
    protected override bool CheckCondition()
    {
        // TODO
        // 쿨타입이 아니라면
        return true;
    }

    protected override void Execute()
    {
        // TODO
        // _character의 animationController 변경시키고
        // 전방에 Ray쏴서 Damegeable 컴포넌트가 있는 녀석이라면 데미지 주기
    }
}
