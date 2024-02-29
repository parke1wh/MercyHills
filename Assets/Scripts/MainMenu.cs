using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGameDemo()
    {
        SceneManager.LoadScene("Loading_Scene");
    }

    public void PlayGameFinal()
    {
        //SceneManager.LoadScene("Tasks");
    }

    public void QuitGame()
    {
        Debug.Log("quit is working");
        Application.Quit();
    }
}
