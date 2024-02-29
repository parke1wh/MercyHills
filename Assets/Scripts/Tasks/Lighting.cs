using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public bool check;
    public bool generatorOn;
    public float timer;

    public Light[] securityLights;
    public Light[] officeLights;
    public Light[] labLights;
    public Light[] bedroomLights;
    public Light[] bathroomLights;
    public Light[] hallway1_5Lights;
    public Light[] hallway1Lights;
    public Light[] eletricLights;
    public Light[] cornersLights;

    private void Start()
    {
        
        generatorOn = false;
        check = false;
    }
    public void Update()
    {
        if (check)
        {
            if (generatorOn)
            {
                turnOn();
                GameManager.Instance.lightsOff = false;
                generatorOn = false;
            }

            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                GameManager.Instance.lightsOff = true;
                generatorOn = true;
                check = false;
                turnOff();
                timer = 45f;
            }
        }
    }
    public void turnOff()
    {

        for (int i = 0; i < securityLights.Length; i++)
        {
            securityLights[i].intensity = 0f;
        }

        for (int i = 0; i < officeLights.Length; i++)
        {
            officeLights[i].intensity = 0f;
        }

        for (int i = 0; i < labLights.Length; i++)
        {
            labLights[i].intensity = 0f;
        }

        for (int i = 0; i < bedroomLights.Length; i++)
        {
            bedroomLights[i].intensity = 0f;
        }

        for (int i = 0; i < bathroomLights.Length; i++)
        {
            bathroomLights[i].intensity = 0f;
        }

        for (int i = 0; i < hallway1_5Lights.Length; i++)
        {
            hallway1_5Lights[i].intensity = 0f;
        }

        for (int i = 0; i < hallway1Lights.Length; i++)
        {
            hallway1Lights[i].intensity = 0f;
        }

        for (int i = 0; i < eletricLights.Length; i++)
        {
            eletricLights[i].intensity = 0f;
        }

        for (int i = 0; i < cornersLights.Length; i++)
        {
            cornersLights[i].intensity = 0f;
        }
    }

    public void turnOn()
    {
        for (int i = 0; i < securityLights.Length; i++)
        {
            securityLights[i].intensity = 1.5f;
        }

        for (int i = 0; i < officeLights.Length; i++)
        {
            officeLights[i].intensity = 1.5f;
        }

        for (int i = 0; i < labLights.Length; i++)
        {
            labLights[i].intensity = 1.5f;
        }

        for (int i = 0; i < bedroomLights.Length; i++)
        {
            bedroomLights[i].intensity = 1.5f;
        }

        for (int i = 0; i < bathroomLights.Length; i++)
        {
            bathroomLights[i].intensity = 1.5f;
        }

        for (int i = 0; i < hallway1_5Lights.Length; i++)
        {
            hallway1_5Lights[i].intensity = 1.5f;
        }

        for (int i = 0; i < hallway1Lights.Length; i++)
        {
            hallway1Lights[i].intensity = 1.0f;
        }

        for (int i = 0; i < eletricLights.Length; i++)
        {
            eletricLights[i].intensity = 0.25f;
        }

        for (int i = 0; i < cornersLights.Length; i++)
        {
            cornersLights[i].intensity = 0.2f;
        }
    }
}
