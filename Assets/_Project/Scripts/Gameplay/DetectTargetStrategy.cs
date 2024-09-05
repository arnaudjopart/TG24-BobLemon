using ajc.BehaviourTree;

internal class DetectTargetStrategy : IStrategy
{
    private ITargetDetector _targetDetector;

    public DetectTargetStrategy(ITargetDetector targetDetector)
    {
        _targetDetector = targetDetector;
    }

    public Node.STATUS Process(float _deltaTime)
    {
        _targetDetector.UpdateDetection(_deltaTime);
        return _targetDetector.HasDetectedTarget()? Node.STATUS.Success : Node.STATUS.Failure;
    }
}