using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heard_Player : MonoBehaviour
{
    [SerializeField] PlayerDetector heardPlayer;
     private Controller playerSpeed;

    private void Start()
    {
        playerSpeed = FindObjectOfType<Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Player is moving
            if (playerSpeed.isMoving)
            {
                heardPlayer._detectedPlayer = other.gameObject.GetComponent<Controller>();
            }
        }
    }
}
