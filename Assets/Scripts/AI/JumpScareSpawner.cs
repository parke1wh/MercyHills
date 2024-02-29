using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> triggerZones;
    int randomize;
    public bool PlayerTouchedATrigger = false;
    Lighting lighting;
    private Coroutine spawnCoroutine;

    private void Start()
    {
        triggerZones = TurnOffALLTrigger(triggerZones);
        lighting = FindObjectOfType<Lighting>();

    }
 
    public void JumpScareSpawnAwake()
    {
        if (spawnCoroutine != null)
        {
            Debug.LogWarning("Spawner already running");
        }
        else if(spawnCoroutine == null && GameManager.Instance.numOfDeaths >= 1)
        {
            spawnCoroutine = StartCoroutine(TurnOffSomeTrigger(triggerZones));
        }

    }

    public void JumpScareSpawnAllDisbaled()
    {
        triggerZones = TurnOffALLTrigger(triggerZones);
    }


    IEnumerator  TurnOffSomeTrigger(List<GameObject> zones)
    {
        List<GameObject> placeholder = zones;
        foreach(GameObject child in placeholder)
        {
            child.SetActive(false);
        }
        randomize = Random.RandomRange(0, placeholder.Count);
        placeholder[randomize].SetActive(true);
        randomize = Random.RandomRange(0, placeholder.Count);
        placeholder[randomize].SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

    public void StopJumpScares()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            Debug.Log("Null");
            triggerZones = TurnOffALLTrigger(triggerZones);
            spawnCoroutine = null;
        }
    }

    private List<GameObject> TurnOffALLTrigger(List<GameObject> zones)
    {
        List<GameObject> placeholder = zones;
        foreach (GameObject child in placeholder)
        {
            child.SetActive(false);
        }
        return placeholder;
    }

    public void RandomizeTriggers(Collider other, Vector3 childPosition, bool isHit)
    {
        //After the player hits a trigger we will signal this method
        //to turn off a trigger and return a new one
        //triggerZones.OnCh
        Debug.Log(other + " Has collided in this position " + childPosition);
        List<GameObject> childTriggers = new List<GameObject>();
        childTriggers = triggerZones;
        foreach (GameObject child in childTriggers)
        {
            if(child.transform.position == childPosition) { child.SetActive(false); }
        }
        randomize = Random.RandomRange(0, childTriggers.Count);
        triggerZones[randomize].SetActive(true);
        randomize = Random.RandomRange(0, childTriggers.Count);
        triggerZones[randomize].SetActive(true);
        randomize = Random.RandomRange(0, childTriggers.Count);
        triggerZones[randomize].SetActive(true);

    }

}
