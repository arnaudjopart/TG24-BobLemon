using UnityEngine;
using UnityEngine.AI;

public interface INavigationController
{
    Transform[] WayPoints { get; }

    void FindNextDestination();
    bool HasCompletedPatrol();
    bool HasReachDestination();
    bool HasWayPoints();
    bool IsReadyToProceedToNextDestination(float _deltaTime);
    void Move();
    void SetDestination(Transform target);
    void StartPatrolling();
    void StopPatrolling();
    void UpdateDestination();
}