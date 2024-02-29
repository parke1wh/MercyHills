using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationTrigger : MonoBehaviour
{

    public Tasks tasks;

    public bool check;
    public int taskNum;
    public int dayNum;

    [SerializeField] private GameObject triggerArea;

    
    

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && check)
        {
            //Debug.Log("Task " + taskNum + " complete");

            if (dayNum == 1)
                tasks.day1Tasks(taskNum);
            else
                tasks.day2Tasks(taskNum);
                //Debug.Log("Task " + taskNum + " was triggered");

            triggerArea.SetActive(false);
            
        }
        else
            Debug.Log("Task " + taskNum + " can't be completed");
    }

    public void turnOff()
    {
        triggerArea.SetActive(false);
    }
}
