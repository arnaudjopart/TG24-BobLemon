using UnityEngine;

internal class FakeTargetDetector : ITargetDetector
{
    private readonly Transform transform;

    public FakeTargetDetector(Transform _transform)
    {
        transform = _transform;
    }

    public Transform Target => transform;

    public bool HasDetectedTarget()
    {
        return true;
    }

    public void ReachTarget()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateDetection(float deltaTime)
    {
        Debug.Log("FakeTargetDetector - UpdateDetection");
    }
}