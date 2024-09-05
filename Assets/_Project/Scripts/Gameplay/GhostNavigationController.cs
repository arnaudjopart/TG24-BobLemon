using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class GhostNavigationController : MonoBehaviour, INavigationController
{
    [SerializeField] private Transform[] _wayPoints;
    private float _timer;
    [SerializeField] private int _globalIndex;
    [SerializeField] private int _loopIndex;

    public Transform[] WayPoints => _wayPoints;

    private NavMeshAgent _agent;
    private Transform _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }


    public void FindNextDestination()
    {
        _timer = 0f;
        _globalIndex = (_globalIndex + 1);
        _loopIndex = _globalIndex%_wayPoints.Length;
        
    }

    public bool HasReachDestination()
    {
        return Vector3.SqrMagnitude(_agent.transform.position - _target.position) < .5f;
    }

    public bool HasWayPoints()
    {
        return _wayPoints == null ? false : _wayPoints.Length > 1; 
    }

    public void StopPatrolling()
    {
        _agent.isStopped = true;
    }

    public void UpdateDestination()
    {
        _target = _wayPoints[_loopIndex];
        _agent.SetDestination(_target.position);
    }

    public bool HasCompletedPatrol()
    {
        return _globalIndex%_wayPoints.Length == 0;
    }

    public bool IsReadyToProceedToNextDestination(float _deltaTime)
    {
        _timer += _deltaTime;
        return _timer > 1;
        
    }

    public void StartPatrolling()
    {
        _agent.isStopped=false;
    }

    public void Move()
    {
        _agent.isStopped = false;
    }

    public void SetDestination(Transform target)
    {
        _target = target;
        _agent.SetDestination(_target.position);
    }
}