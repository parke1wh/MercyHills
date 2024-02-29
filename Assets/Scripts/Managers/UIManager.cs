using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    private int activeIndex;
    [SerializeField] private Button[] button;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject winMenu;
    

    public static UIManager Instance
    {
        get
        {
            if (_instance)
            {
                Debug.LogError("UIManager is null");
            }
            return _instance;
        }

    }

    private void Update()
    {
        if (gameOverMenu.activeInHierarchy)
        {
            GameOverController();
        }
        else if(winMenu.activeInHierarchy)
        {
            WinController();
        }
    }

    private void WinController()
    {
        if (!winMenu.activeInHierarchy) { return; }

        int index = 0;

        Debug.Log(index);


        //button[index].image.color = Color.red;

        if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") > -0.1)
        {

            //if (index > 1) { index = 0; }
            //else index++;
            index++;

        }
        if (Input.GetButtonDown("XButton"))
        {
            button[1].onClick.Invoke();
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(activeIndex);
    }

    public void restartGameDEMO()
    {
        SceneManager.LoadScene("FINAL_DEMO");
    }

    public void GameOverController()
    {
        if (!gameOverMenu.activeInHierarchy) { return; }

        int index = 0;

        Debug.Log(index);


        //button[index].image.color = Color.red;
        
        if(Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") > -0.1)
        {

            //if (index > 1) { index = 0; }
            //else index++;
            index++;

        }
        if (Input.GetButtonDown("XButton"))
        {
            button[0].onClick.Invoke();
        }
        else if(Input.GetButtonDown("YButton"))
        {
            button[1].onClick.Invoke();
        }
    }

    public void continueGame()
    {
        //To continue the game
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        activeIndex++;
        SceneManager.LoadScene(activeIndex);
    }

    public void PlayGameDEMO()
    {
        SceneManager.LoadScene("FINAL_DEMO");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

}
