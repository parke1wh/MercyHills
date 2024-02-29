using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunnedMode : IState
{
    private readonly Monster _monster;
    private readonly NavMeshAgent navMesh;
    private float _initialSpeed;
    private float  stunCounter;
    private bool isStun;
    float perservedStunCounter;

    public StunnedMode(Monster monster, NavMeshAgent meshAgent, float counter)
    {
        stunCounter = counter;
        navMesh = meshAgent;
        _monster = monster;
    }
    public void OnEnter()
    {
        Debug.Log("Total Stun " + stunCounter);
        _initialSpeed = navMesh.speed;
        navMesh.speed = 0;
        isStun = true;
        perservedStunCounter = stunCounter;
    }

    public void OnExit()
    {
        Debug.Log("My navMesh Speed " + navMesh.speed);
        isStun = false;
        navMesh.enabled = false;
    }

    public void Tick()
    {
        
        if(perservedStunCounter > 0f && isStun)
        {
            perservedStunCounter -= Time.deltaTime * 2f;
            Debug.Log("I am stunned");
             Debug.Log("Time Left for being stunned " + perservedStunCounter);
            if(perservedStunCounter <= 0f)
            {
               Debug.Log("Done being stunned");
                _monster.isNotStun = false;
            }
        }
    }

}
