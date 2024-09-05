using ajc.BehaviourTree;

internal class WaitForSecondsStrategy : IStrategy
{
    private float v;
    private float _timer;

    public WaitForSecondsStrategy(float v)
    {
        this.v = v;
    }

    public Node.STATUS Process(float _deltaTime)
    {
        _timer += _deltaTime;
        if( _timer > v ) 
        {
            _timer = 0;
            return Node.STATUS.Success;
        }
        return Node.STATUS.Running;

    }
}