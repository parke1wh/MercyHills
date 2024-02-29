using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    MonsterSpawner monsterSpawner;
    PathConfig pathConfig;
    public List<Transform> waypoints { get; set; }
    public bool canMove { get; set; }
    public int currentWaypointIndex { get; set; }
    private bool reverse;
    public bool firstTime = true;
    [SerializeField] private float _ExpectedWaitTime = 5f;

    private StateMachine _stateMachine;
    [SerializeField] private float _enemyDistance;
    private NavMeshAgent navMeshAgent;
    Status status;
    private Animator animator;

    [Tooltip("Values Relating to Patroling")]
    [Header("Patrol Speeds")]
    [SerializeField] private float PatrolSpeed = 15f;
    [SerializeField] private float PatrolAngularSpeed = 35f;
    [SerializeField] private float PatrolAccelerate = 20f;



    [Tooltip("Values Relating To Chasing")]
    [Header("Chase Speeds")]
    [SerializeField] private float chaseSpeed = 150f;
    [SerializeField] private float AngularSpeed = 350f;
    [SerializeField] private float eneAccelerate = 200f;


    [SerializeField] float stunnedCounter = 0;
    [SerializeField] public bool isNotStun = false;


    private void Awake()
    {
        monsterSpawner = FindObjectOfType<MonsterSpawner>();
        pathConfig = monsterSpawner.GetCurrentWave();
        navMeshAgent = GetComponent<NavMeshAgent>();
        var playerDetector = gameObject.GetComponentInChildren<PlayerDetector>();
        animator = GetComponent<Animator>();
        waypoints = pathConfig.GetWaypoints();
        status = FindObjectOfType<Status>();


        _stateMachine = new StateMachine();

        var SearchForWaypoint = new NextWaypoint(this, reverse, navMeshAgent);
        var moveToSelected = new PatrolNextWaypoint(this, navMeshAgent, currentWaypointIndex, PatrolSpeed, PatrolAngularSpeed, PatrolAccelerate, status, animator);
        var Idle = new WaitOnWaypoint(this, animator);
        var chase = new ChasePlayer(this, navMeshAgent, playerDetector, chaseSpeed, AngularSpeed, eneAccelerate, status, animator);
        var stun = new StunnedMode(this, navMeshAgent, stunnedCounter);


        At(SearchForWaypoint, moveToSelected, MoveToNextWaypoint());
        //At(moveToSelected, SearchForWaypoint, StuckForOverASecond());
        At(moveToSelected, Idle, ReachedWaypoint());
        At(Idle, SearchForWaypoint, WaitTimeIsOver());

        _stateMachine.AddAnyTransition(chase, () => (playerDetector.PlayerInRange && isNotStun != true));
        At(chase, SearchForWaypoint, () => playerDetector.PlayerInRange == false);


        _stateMachine.AddAnyTransition(stun, () => (isNotStun == true));
        At(chase, stun, StunnedByLight());
        At(stun, SearchForWaypoint, StunnedISOver());
        


        _stateMachine.SetState(SearchForWaypoint);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);
        Func<bool> MoveToNextWaypoint() => () => canMove != false;
        Func<bool> ReachedWaypoint() => () => canMove != false && _enemyDistance < 2.2f;
        Func<bool> StunnedByLight() => () => isNotStun == true;
        Func<bool> StunnedISOver() => () => isNotStun != true;
        Func<bool> WaitTimeIsOver() => () => canMove == true;
    }

    // Update is called once per frame
    private void Update()
    {
        _enemyDistance = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        //Debug.Log("The enemy's distance " + enemyDistance);
        _stateMachine.Tick();
        //Debug.Log("Can the enemy move? " + canMove);
        
    }

    public IEnumerator WaitBeforeMoving()
    {
        //This will be were we will put our animation for the enemy
        navMeshAgent.speed = 0f;
        navMeshAgent.angularSpeed = 0f;
        navMeshAgent.acceleration = 0f;
        canMove = false;
        animator.SetBool("Move", canMove);
        yield return new WaitForSeconds(_ExpectedWaitTime);
        animator.SetBool("Move", canMove);
        canMove = true;
        navMeshAgent.speed = PatrolSpeed;
        navMeshAgent.angularSpeed = PatrolAngularSpeed;
        navMeshAgent.acceleration = PatrolAccelerate;

    }
}
