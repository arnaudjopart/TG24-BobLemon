using ajc.BehaviourTree;
using System;

internal class ActionStrategy : IStrategy
{
    private Action value;

    public ActionStrategy(Action value)
    {
        this.value = value;
    }

    public Node.STATUS Process(float _deltaTime)
    {
        value.Invoke();
        return Node.STATUS.Success;
    }
}