using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : IState
{
    private readonly Monster _monster;
    private NavMeshAgent _navmeshAgent;
    private readonly PlayerDetector _playerDetector;
    private readonly Animator _animator;

    private float _initialSpeed;
    private float monSpeed;
    private float monAngular;
    private float monAccelerate;
    private float distanceToPlayer;


    Status status;


    public ChasePlayer(Monster monster, NavMeshAgent navMeshAgent, PlayerDetector playerDetector, float monSpeed, float monAngular, float monAccelerate, Status patrolSpeed, Animator animator)
    {
        _monster = monster;
        _navmeshAgent = navMeshAgent;
        _playerDetector = playerDetector;
        this.monSpeed = monSpeed;
        this.monAngular = monAngular;
        this.monAccelerate = monAccelerate;
        status = patrolSpeed;
        _animator = animator;

    }
    public void OnEnter()
    {
        _navmeshAgent.enabled = true;
        _initialSpeed = _navmeshAgent.speed;
        _navmeshAgent.speed = GameManager.Instance.numOfDeaths >= 2? monSpeed * 2: monSpeed;
        _navmeshAgent.angularSpeed = GameManager.Instance.numOfDeaths >= 2? monAngular * 2: monAngular;
        _navmeshAgent.acceleration = GameManager.Instance.numOfDeaths >= 2? monAccelerate * 2 : monAccelerate;
    }
    public void Tick()
    {
        Vector3 direction = (_playerDetector._detectedPlayer.transform.position - _monster.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _monster.transform.rotation = Quaternion.Slerp(_monster.transform.rotation, lookRotation, Time.deltaTime * 10f);
        distanceToPlayer = Vector3.Distance(_monster.transform.position, _playerDetector._detectedPlayer.transform.position);
        DealingWithPlayer();
    }

    private void DealingWithPlayer()
    {
        if(distanceToPlayer >= _navmeshAgent.stoppingDistance)
        {
            _navmeshAgent.SetDestination(_playerDetector._detectedPlayer.transform.position);
            _animator.SetBool("Chase", true);
            _animator.SetBool("Move", false);
            _animator.SetBool("Attack", false);
        }
        else if(distanceToPlayer <= _navmeshAgent.stoppingDistance)
        {
            Debug.Log("Attack Player");
            _animator.SetBool("Chase", false);
            _animator.SetBool("Attack", true);
            GameManager.Instance.Caught.gameObject.SetActive(true);
            GameManager.Instance.enemyChecker = false;
        }
    }

    public void OnExit()
    {
        _navmeshAgent.speed = _initialSpeed;
        _navmeshAgent.enabled = false;
    }

}
