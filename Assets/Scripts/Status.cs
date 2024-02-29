using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{

    private const int full = 100;
    private int status;
    public int minimumStatus;
    public Image Overlay;
    public Text Percentage;
    public bool check;
    public bool virusLeak;
    public float timer;
    private Lighting lighting;
    //public int deaths;


    //private AudioManager playVirusMusic;




    private void Start()
    {
        //playVirusMusic = FindObjectOfType<AudioManager>();
        //ChangeMusic();
        lighting = FindObjectOfType<Lighting>();
    }

    // Update is called once per frame
    void Update()
    {
        //Boolean check to see if player is in contaminated zone or not.
        if (check || lighting.generatorOn == true || virusLeak)
        {
            if (status <= 100)
                setTimeStatus();
            else
            {
                GameManager.Instance.gameOver.gameObject.SetActive(true);
            }
        }

        //resetStatus();
        getStatus();

    }

    //private void ChangeMusic()
    //{
    //    switch (timer)
    //    {
    //        case float n when (n >= 0 && n < 20):
    //            Debug.Log("Play 1");
    //            playVirusMusic.Stop("Background Music 3");
    //            playVirusMusic.Stop("Background Music 4");
    //            playVirusMusic.Stop("Background Music 5");
    //            playVirusMusic.Stop("Background Music 2");
    //            playVirusMusic.Play("Background Music 1");
    //            break;
    //        case float n when (n >= 20 && n < 40):
    //            Debug.Log("Play 2");
    //            playVirusMusic.Stop("Background Music 3");
    //            playVirusMusic.Stop("Background Music 4");
    //            playVirusMusic.Stop("Background Music 5");
    //            playVirusMusic.Stop("Background Music 1");
    //            playVirusMusic.Play("Background Music 2");
    //            break;
    //        case float n when (n >= 40 && n < 60):
    //            Debug.Log("Play 3");
    //            playVirusMusic.Stop("Background Music 2");
    //            playVirusMusic.Stop("Background Music 4");
    //            playVirusMusic.Stop("Background Music 5");
    //            playVirusMusic.Stop("Background Music 1");
    //            playVirusMusic.Play("Background Music 3");
    //            break;
    //        case float n when (n >= 60 && n < 80):
    //            Debug.Log("Play 4");
    //            playVirusMusic.Stop("Background Music 2");
    //            playVirusMusic.Stop("Background Music 3");
    //            playVirusMusic.Stop("Background Music 5");
    //            playVirusMusic.Stop("Background Music 1");
    //            playVirusMusic.Play("Background Music 4");
    //            break;
    //        case float n when (n >= 80 && n < 100):
    //            Debug.Log("Play 5");
    //            playVirusMusic.Stop("Background Music 2");
    //            playVirusMusic.Stop("Background Music 3");
    //            playVirusMusic.Stop("Background Music 4");
    //            playVirusMusic.Stop("Background Music 1");
    //            playVirusMusic.Play("Background Music 5");
    //            break;
    //        default:
    //            playVirusMusic.Stop("Background Music 2");
    //            playVirusMusic.Stop("Background Music 3");
    //            playVirusMusic.Stop("Background Music 4");
    //            playVirusMusic.Stop("Background Music 1");
    //            playVirusMusic.Stop("Background Music 5");
    //            break;

    //    }
    //}

    void getStatus()
    {
       //minimumStatus = (GameManager.Instance.numOfDeaths * 20);
       //status = minimumStatus;


        /*
        if(Thing you want to trigger)
        {
           status += AMOUNTYOUWANTTOADD;
        }
        */

        float fillAmount = (float)status/(float)full;
        Overlay.fillAmount = fillAmount;
        Percentage.text = getValue().ToString() + "%";
    }

    //For setting a new status value, FYI it will add to the already existing value, not reset it
    public void setStatus(int add)
    {
        status += add;
    }


    //For setting up a new status while in contaminated area.
    void setTimeStatus()
    {
        timer += Time.deltaTime * 2;
        status = (int)timer;
    }

    //After decomtanmination cleaning, includes player deaths part of the calculation
    public void resetStatus()
    {
        timer = (GameManager.Instance.numOfDeaths * 20.0f);
        status = (GameManager.Instance.numOfDeaths * 20);

        //minimumStatus = (GameManager.Instance.numOfDeaths * 20);
        //status = minimumStatus;

        //minimumStatus = (deaths * 20);
        //status = minimumStatus;
    }

    public void IncreaseStatus()
    {
        GameManager.Instance.numOfDeaths += 1;
        timer = (GameManager.Instance.numOfDeaths * 20.0f);
        status = (GameManager.Instance.numOfDeaths * 20);
        Debug.Log("Increase");
        GameManager.Instance.lightsOff = false;
        //lighting.check = false;
        //lighting.generatorOn = true;
        //spawner.JumpScareSpawnAwake();
        //lightChange.color = getValue() >= 20 ? Color.red : Color.black;
        //lightChange.intensity = getValue() >= 20 ? lightChange.intensity * 2 : lightChange.intensity;
        //ChangeMusic();

        //minimumStatus = (GameManager.Instance.numOfDeaths * 20);
        //status = minimumStatus;

        //minimumStatus = (deaths * 20);
        //status = minimumStatus;
    }

    //A method for calling the status effects


    // for obtaining the status value in other scripts
    public int getValue()
    {
        return status;
    }
    public int getValueFull()
    {
        return full;
    }
}

