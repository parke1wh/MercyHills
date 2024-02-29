using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneTrigger : MonoBehaviour
{

    PlayerDetector _playerDetector;

    void Start()
    {
        _playerDetector = FindObjectOfType<PlayerDetector>();
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("left");
        if (other.gameObject.CompareTag("Player"))
        {
            _playerDetector._detectedPlayer = null;
        }
    }
}
