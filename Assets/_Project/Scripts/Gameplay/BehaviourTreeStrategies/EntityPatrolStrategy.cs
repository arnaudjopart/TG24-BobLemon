using ajc.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPatrolStrategy : IStrategy
{
    private INavigationController _controller;

    public EntityPatrolStrategy(INavigationController controller)
    {
        _controller = controller;
    }

    public Node.STATUS Process(float _deltaTime)
    {
        Debug.Log("EntityPatrolStrategy - Process");
        _controller.StartPatrolling();
        if (!_controller.HasWayPoints())
        {
            _controller.StopPatrolling();
            return Node.STATUS.Failure;
        }
        _controller.UpdateDestination();

        if (_controller.HasReachDestination())
        {
            if (_controller.IsReadyToProceedToNextDestination(_deltaTime))
            {
                _controller.FindNextDestination();
                if (_controller.HasCompletedPatrol()) return Node.STATUS.Success;
            }
            
        }
        
        

        return Node.STATUS.Running;
    }


}
