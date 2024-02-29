using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private int playerMask;
    [SerializeField] private int wallMask;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float sphereRadius;
    //Dead zone will be seriallized for now until we can figure out this error.
    [SerializeField] private SphereCollider _deadZone;
    public bool PlayerInRange => _detectedPlayer != null;

    [HideInInspector] public Controller _detectedPlayer;

    private MonsterShake causeShake;
    public float camIntensity;
    public float camTimer;

    private float currentHitDistance;
    public AudioSource source;
    public AudioClip clip;

    Vector3 origin;
    Vector3 direction;

    private void Start()
    {
        causeShake = FindObjectOfType<MonsterShake>();
        _deadZone.enabled = false;
    }
    private void FixedUpdate()
    {
        FindingPlayer();
        RaderZone();
    }

    private void FindingPlayer()
    {
        int playerMaskProcessed = 1 << playerMask;
        int wallMaskProcessed = ~(1 << wallMask);

        origin = transform.position;
         direction = transform.forward;



        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, maxDistance, wallMaskProcessed))
        {
            Debug.Log("Ignore Wall");
            if (Physics.Raycast(origin, direction, out hit, maxDistance, playerMaskProcessed))
            {
                _detectedPlayer = hit.collider.GetComponent<Controller>();

            }
        }
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, wallMaskProcessed))
        {
            if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, playerMaskProcessed))
            {
                _detectedPlayer = hit.collider.GetComponent<Controller>();
                currentHitDistance = hit.distance;
            }
            else
            {
                // _detectedPlayer = null;
                currentHitDistance = maxDistance;
            }
        }


        if (_detectedPlayer != null)
        {
            source.PlayOneShot(clip, 0.7f);
            causeShake.camShake(camIntensity, camTimer);
            Debug.Log("Shake");
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawRay(origin, direction * maxDistance, Color.red);
        Gizmos.DrawWireSphere(origin + direction * maxDistance, sphereRadius);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _detectedPlayer = null;
        }
    }

    private void RaderZone()
    {
        if (_detectedPlayer != null)
        {
           _deadZone.enabled = true;
        }
        else if (_detectedPlayer == null)
        {
            _deadZone.enabled = false;
        }
    }
}
