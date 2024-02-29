using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Path Config", fileName = "New Path Config")]
public class PathConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float chaseSpeed = 8f;

    public float GetChaseSpeed() 
    {
        return chaseSpeed;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

}
