using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class MonsterShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimerTotal;
    private float shakeTimer;
    private float startingIntensity;
    [SerializeField] bool seenPlayer = false;

    Status status;




    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        status = FindObjectOfType<Status>();

    }

    private void Update()
    {
        if (seenPlayer == true) 
        {
            Debug.Log("Is player seen: " + seenPlayer);
            PlayerNotSeen(); 
        }
        else
        {
            PlayNormalCam();
        }
    }

    private void PlayNormalCam()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
      cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        float usualIntensity = 0;

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = GameManager.Instance.numOfDeaths >= 4 && GameManager.Instance.lightsOff ? usualIntensity = 4.5f : usualIntensity = 0;
    }

    public void PlayerNotSeen()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime * 2f;
            Debug.Log("The Shake Timer" + shakeTimer);
            if (shakeTimer <= 0f)
            {
                //Time over
             
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
         cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f,( 1 - (shakeTimer / shakeTimerTotal)));
                seenPlayer = false;

            }
        }
    }

    public void camShake(float intensity, float time)
    {
       CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
        seenPlayer = true;

    }
}
