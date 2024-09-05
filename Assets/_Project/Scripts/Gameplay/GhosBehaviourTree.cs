using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ajc.BehaviourTree;
using System;

public class GhosBehaviourTree : MonoBehaviour
{
    private BehaviourTree _tree;
    private INavigationController _ghost;
    [SerializeField] private GameObject _detectorGameObject;
    private ITargetDetector _targetDetector;
    [SerializeField] private float _stamina =10;
    [SerializeField] private GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
        _ghost = GetComponent<INavigationController>();
        _targetDetector = _detectorGameObject.GetComponent<ITargetDetector>();

        _tree = new BehaviourTree();

        var mainPatrollingSelector = new AcrossSelector("Patrolling Logic");

        var targetDetectionSequence = new SequenceNode("Detecting Player");
        targetDetectionSequence.AddNode(new Leaf("Player Is in Sight", new TellSomethingStrategy("Detecting...")));
        targetDetectionSequence.AddNode(new Leaf("Has enough stamina", new Condition(() => _stamina > 8)));
        targetDetectionSequence.AddNode(new Leaf("Player Is in Sight", new DetectTargetStrategy(_targetDetector)));
        targetDetectionSequence.AddNode(new Leaf("Player Is in Sight", new TellSomethingStrategy("Detected")));
        targetDetectionSequence.AddNode(new Leaf("React To Sight", new ActionStrategy(() => 
        { 
            _ghost.StopPatrolling();
            _camera.SetActive(true);
        })));
        targetDetectionSequence.AddNode(new Leaf("React To Sight", new WaitForSecondsStrategy(3f)));

        var patrollingSequence = new AcrossSequenceNode("Patrolling");

        patrollingSequence.AddNode(new Leaf("Healing",new ActionStrategy(() => { 
            _stamina += Time.deltaTime;
            _stamina = Mathf.Min(_stamina, 10);
        })));
        patrollingSequence.AddNode(new Leaf("Patrolling Waypoints", new EntityPatrolStrategy(_ghost)));
        patrollingSequence.AddNode(new Leaf("Patrolling End", new TellSomethingStrategy("Finish patrol")));

        var chasingNode = new AcrossSequenceNode("Chasing");
        chasingNode.AddNode(new Leaf("Player Is in Sight", new ActionStrategy(()=> {
            _camera.SetActive(false);
        
        })));
        chasingNode.AddNode(new Leaf("Has enough stamina", new Condition(() => _stamina > 0)));
        chasingNode.AddNode(new Leaf("Has enough stamina", new ActionStrategy(() => { _stamina -= Time.deltaTime; })));
        chasingNode.AddNode(new Leaf("Chasing Target", new ChaseTargetStrategy(_ghost, _targetDetector)));
        chasingNode.AddNode(new Leaf("Chasing Target", new ActionStrategy(()=> {

            _targetDetector.ReachTarget();
            }
        )));

        mainPatrollingSelector.AddNode(targetDetectionSequence);
        mainPatrollingSelector.AddNode(patrollingSequence);
        _tree.AddNode(mainPatrollingSelector);
        _tree.AddNode(chasingNode);
    }


    // Update is called once per frame
    void Update()
    {
        _tree.Tick (Time.deltaTime);
    }
}

internal class Condition : IStrategy
{
    private Func<bool> value;

    public Condition(Func<bool> value)
    {
        this.value = value;
    }

    public Node.STATUS Process(float _deltaTime)
    {
        return value.Invoke() ? Node.STATUS.Success : Node.STATUS.Failure;
    }
}

internal class ChaseTargetStrategy : IStrategy
{
    private INavigationController ghost;
    private ITargetDetector target;

    public ChaseTargetStrategy(INavigationController ghost, ITargetDetector target)
    {
        this.ghost = ghost;
        this.target = target;
    }

    public Node.STATUS Process(float _deltaTime)
    {
        Debug.Log("Process");
        if (target.Target == null) return Node.STATUS.Failure;
        ghost.SetDestination(target.Target);
        ghost.Move();
        if(ghost.HasReachDestination())
        {
            return Node.STATUS.Success;

        }

        return Node.STATUS.Running;

    }
}

