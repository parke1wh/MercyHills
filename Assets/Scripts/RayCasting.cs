 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    //Distance from what you are pointing at to the player, target is a redundant variable for tracking purposes 
    public static float distance;
    public float target;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //If "Ray" hits a target, set target to the distance from that point and the distance variable to that same number
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            target = hit.distance;
            distance = target;


        }
    }
}
