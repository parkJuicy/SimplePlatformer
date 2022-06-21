using UnityEngine;

public abstract class Action : MonoBehaviour
{
    protected Character _character;

    abstract protected bool CheckCondition();

    abstract protected void Execute();

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    public void Process()
    {
        if(CheckCondition())
        {
            Execute();
        }
    }
}