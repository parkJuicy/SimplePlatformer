using UnityEngine;

public abstract class Action : MonoBehaviour
{
    abstract protected bool CheckCondition();

    abstract protected void Execute();

    public void Process()
    {
        if(CheckCondition())
        {
            Execute();
        }
    }
}