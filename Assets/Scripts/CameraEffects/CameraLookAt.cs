using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    //Variable to hold the object you want to look at
    [SerializeField] private Transform FollowObject;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(FollowObject);
    }
}
