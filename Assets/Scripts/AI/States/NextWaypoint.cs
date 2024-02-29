using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

internal class NextWaypoint : IState
{

    public int _LastSavedWaypointIndex = -1;
    private readonly Monster _monster;
    private readonly int _WaypointLength;
    private bool _reverseDirection;
    private readonly NavMeshAgent _navMeshAgent;

    public NextWaypoint(Monster monster, bool reverse, NavMeshAgent meshAgent)
    {
        _monster = monster;
        _WaypointLength = monster.waypoints.Count;
        _reverseDirection = reverse;
        _navMeshAgent = meshAgent;


    }
    public void OnEnter()
    {
        _navMeshAgent.speed = 5f;

    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        _monster.canMove = OntoNextWaypoint(_WaypointLength);
        _monster.currentWaypointIndex = EmergencyWaypointIndex();
    }

    private bool OntoNextWaypoint(int Length)
    {
        bool canMove = false;
        if (Length != 0 && _monster.firstTime != true)
        {
            if (_reverseDirection != true)
            {
                if (Length - 1  != _LastSavedWaypointIndex)
                {
                    _LastSavedWaypointIndex++;
                    canMove = true;
                }
                else if (Length - 1 == _LastSavedWaypointIndex)
                {
                    _reverseDirection = true;
                    _LastSavedWaypointIndex--;
                    canMove = true;
                }
            }
            else
            {
                _LastSavedWaypointIndex--;
                canMove = true;
                if (_LastSavedWaypointIndex == -1)
                {
                    //Debug.Log("Hey");
                    _reverseDirection = false;
                    _LastSavedWaypointIndex++;
                    canMove = true;
                }
            }
        }
        else if(_monster.firstTime == true)
        {
            _LastSavedWaypointIndex = 0;
            canMove = true;
            _monster.firstTime = false;
        }
        else
        {
            canMove = false;
        }

        return canMove;
    }

    public int EmergencyWaypointIndex()
    {
       // Debug.Log("My Waypoint " + _LastSavedWaypointIndex);
        return _LastSavedWaypointIndex;
    }
}
