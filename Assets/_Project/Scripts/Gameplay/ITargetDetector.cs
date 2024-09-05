
using UnityEngine;

internal interface ITargetDetector
{
    Transform Target { get; }

    bool HasDetectedTarget();
    void ReachTarget();
    void UpdateDetection(float deltaTime);
}