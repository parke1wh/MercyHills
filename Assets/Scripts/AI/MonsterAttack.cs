using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MonsterAttack : MonoBehaviour
{
    Status status;

    private void Awake()
    {
        status = FindObjectOfType<Status>();
    }

    public void AttackHitEvent()
    {
        Debug.Log("Hey");
        //GameManager.Instance.numOfDeaths += 1;
        status.resetStatus();
    }
}
