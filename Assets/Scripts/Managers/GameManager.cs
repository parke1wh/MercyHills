using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;


/// <summary>
/// This script is used for managing the player death, cutscenes, level specific gameObjects, and some virus bar(Health Bar) effect.
/// Some code may be refactored
/// Methods that might be included:
/// 1. A method to play tutorial level
/// 2. Instances of managing both the UI and Audio Manager for changing scenes or audio related instructions
/// 4. Might move status(health bar) related effects to status bar
/// </summary>
public class GameManager : MonoBehaviour
{


    private MonsterSpawner Spawners; //a reference to the spawner script instead of the GameObject
    private static GameManager _instance;
    [SerializeField ]public bool lightsOff { get; set; }

    //public GameState currentState;
    //public static event Action<GameState> OnGameStateChanged;
    public PlayableDirector introCutscene;

    //Relating to Player's death
    public int numOfDeaths;
    Status status;
    public Transform respawnPoint;
    private Transform Player;

    //For Testing purposes
    [SerializeField] public bool enemyChecker;
    public AudioManager playVirusMusic;
    public Light lightChange;
    JumpScareSpawner spawner;
    Lighting light;

    //Cutscenes
    public PlayableDirector Caught;
    [SerializeField] public PlayableDirector restart;
    [SerializeField] public PlayableDirector gameOver;

    [SerializeField] PostProcessProfile m_profile;
    Vignette vignette;
    ColorGrading grading;


    [SerializeField] bool test;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null) { Debug.LogError("GameManager is Null!!!"); }
            return _instance;
        }


        
    }

    ////void OnEnable()
    ////{
    ////    introCutscene.played += OnPlayableDirectorPlayed;
    ////    introCutscene.played -= IntroCutscene_stopped;
    ////}

    ////private void IntroCutscene_stopped(PlayableDirector obj)
    ////{
    ////    if (introCutscene != obj)
    ////    {
    ////        Debug.Log("PlayableDirector named " + obj.name + " is now playing.");
    ////        test = false;
    ////    }
    ////}

    ////void OnPlayableDirectorPlayed(PlayableDirector aDirector)
    ////{
    ////    if (introCutscene == aDirector)
    ////    {
    ////        Debug.Log("PlayableDirector named " + aDirector.name + " is now playing.");
    ////        test = true;
    ////    }
    ////}

    //void OnDisable()
    //{
    //    introCutscene.played -= OnPlayableDirectorPlayed;
    //    //introCutscene.played += IntroCutscene_stopped;

    //}


    private void Awake()
    {
        Spawners = FindObjectOfType<MonsterSpawner>();
        status = FindObjectOfType<Status>();
        Player = GameObject.Find("Player(CM Prefab)").transform;

        m_profile.TryGetSettings(out vignette);
        m_profile.TryGetSettings(out grading);


        _instance = this;
        Caught.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        spawner = FindObjectOfType<JumpScareSpawner>();
        light = FindObjectOfType<Lighting>();
        introCutscene.gameObject.SetActive(true);
  
    }
    private void FixedUpdate()
    {

        if (lightsOff == true)
        {
            Debug.Log("Play Music");
            ChangeMusic();
            StatusBarEffects();
        }
        else
        {
            ChangeMusic();
            StatusBarEffects();
        }

 
        ActivateDeactivateSpawner();
        SkipCutscene();

        if(Caught.time >= 1.66f)
        {
            Debug.Log("it's off");
            Caught.gameObject.SetActive(false);
            Caught.time = 0f;
            PlayerRestartOrDeath();
        }
    }

    //private IEnumerator PlayTimelineRoutine()
    //{
    //    test = false;
    //    Debug.Log(restart.duration);
    //    yield return new WaitForSeconds((float)restart.duration);
    //    test = true;

    //}

    public void StatusBarEffects()
    {
        vignette.color.value = numOfDeaths >= 3 && lightsOff ? new Color(255f/255f,74f/255f,47f/255f,255f/255f) : Color.white;
        grading.colorFilter.value = numOfDeaths >= 3 && lightsOff ? new Color(255f / 255f, 0f / 255f, 0f / 255f) : Color.white;
        vignette.intensity.value = numOfDeaths >= 3 && lightsOff ? (((vignette.intensity.value * 2f) + numOfDeaths) / 2f) : vignette.intensity.value;

        if (!lightsOff) { spawner.JumpScareSpawnAwake(); }
        else if(lightsOff) { spawner.StopJumpScares(); }
   
    }
   

    private void ChangeMusic()
    {
        switch (numOfDeaths)
        {
            case int n when ((!lightsOff)):
                playVirusMusic.Stop("Background Music 3");
                playVirusMusic.Stop("Background Music 4");
                playVirusMusic.Stop("Background Music 5");
                playVirusMusic.Stop("Background Music 2");
                playVirusMusic.Play("Lights On Background");
                playVirusMusic.Stop("Background Music 1");
                break;
            case int n when ((n >= 0 && n < 1) && (lightsOff)):
                Debug.Log("Play 1");
                playVirusMusic.Stop("Background Music 3");
                playVirusMusic.Stop("Background Music 4");
                playVirusMusic.Stop("Background Music 5");
                playVirusMusic.Stop("Background Music 2");
                playVirusMusic.Play("Background Music 1");
                playVirusMusic.Stop("Lights On Background");
                break;
            case int n when ((n >= 1 && n < 2) && (lightsOff)):
                Debug.Log("Play 2");
                playVirusMusic.Stop("Background Music 3");
                playVirusMusic.Stop("Background Music 4");
                playVirusMusic.Stop("Background Music 5");
                playVirusMusic.Stop("Background Music 1");
                playVirusMusic.Play("Background Music 2");
                playVirusMusic.Stop("Lights On Background");
                break;
            case int n when ((n >= 2 && n < 3) && (lightsOff)):
                Debug.Log("Play 3");
                playVirusMusic.Stop("Background Music 2");
                playVirusMusic.Stop("Background Music 4");
                playVirusMusic.Stop("Background Music 5");
                playVirusMusic.Stop("Background Music 1");
                playVirusMusic.Play("Background Music 3");
                playVirusMusic.Stop("Lights On Background");
                break;
            case int n when ((n >= 3 && n < 4) && (lightsOff)):
                Debug.Log("Play 4");
                playVirusMusic.Stop("Background Music 2");
                playVirusMusic.Stop("Background Music 3");
                playVirusMusic.Stop("Background Music 5");
                playVirusMusic.Stop("Background Music 1");
                playVirusMusic.Play("Background Music 4");
                playVirusMusic.Stop("Lights On Background");
                break;
            case int n when ((n >= 4 && n < 5) && (lightsOff)):
                Debug.Log("Play 5");
                playVirusMusic.Stop("Background Music 2");
                playVirusMusic.Stop("Background Music 3");
                playVirusMusic.Stop("Background Music 4");
                playVirusMusic.Stop("Background Music 1");
                playVirusMusic.Play("Background Music 5");
                playVirusMusic.Stop("Lights On Background");
                break;
            default:
                playVirusMusic.Stop("Background Music 2");
                playVirusMusic.Stop("Background Music 3");
                playVirusMusic.Stop("Background Music 4");
                playVirusMusic.Stop("Background Music 1");
                playVirusMusic.Stop("Background Music 5");
                playVirusMusic.Stop("Lights On Background");
                break;

        }
    }

    //Plays the restart cutscene and transports player back to starting point
    private void PlayerRestartOrDeath()
    {
        Player.transform.position = respawnPoint.transform.position;
        if (Player == null) { Debug.Log("No Player"); }
        Debug.Log("Check to see null status for " + status.getValue() + "and " + status);
        if (status.getValue() < status.getValueFull())
        {
            restart.gameObject.SetActive(true);
            //StartCoroutine(PlayTimelineRoutine());
            //if (test)
            //{
            //    restart.gameObject.SetActive(false);
            //    enemyChecker = true;
            //    Debug.Log("Restart Finished");
            //    light.check = true;
            //    return;
            //}
        }

        //else if to see if a day task has the virus leakage on
        else
        {
            gameOver.gameObject.SetActive(true);
        }
    }

    //Might move this method to a diffrent script
    private void ActivateDeactivateSpawner()
    {
        if (lightsOff)
        {
            Spawners.StartSpawners();
        }
        else
        {
            Spawners.StopSpawnWaves();
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(o);
            }

        }
    }



    private void SkipCutscene()
    {
        if(Input.GetButtonDown("XButton"))
        {
            introCutscene.time = 46f;
        }
    }


    //void Start()
    //{
    //    ChangeState(GameState.Normal);
    //}

    //public void ChangeState(GameState changeState)
    //{
    //    currentState = changeState;

    //    switch (changeState)
    //    {
    //        case GameState.Normal:
    //            break;
    //        case GameState.Death:
    //            PlayerRestartOrDeath();
    //            break;
    //        case GameState.Pause:
    //            break;
    //    }

    //    OnGameStateChanged?.Invoke(changeState);
    //}



}

//public enum GameState
//{
//    Normal,
//    Pause,
//    Death
//}

