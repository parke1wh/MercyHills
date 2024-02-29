using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    PathConfig currentWave;
    [SerializeField] List<PathConfig> pathConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    private Coroutine spawnCoroutine;


    public void StartSpawners()
    {
        if(spawnCoroutine != null)
        {
            Debug.LogWarning("Spawner already running");
        }
        else
        {
            spawnCoroutine = StartCoroutine(SpawnMonsterWaves());
        }
    }

    public void StopSpawnWaves()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    public PathConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnMonsterWaves()
    {
        Debug.Log("Hello");
        foreach(PathConfig wave in pathConfigs)
        {
            currentWave = wave;
            Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    }

