using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    //refrence progress bar
    public Image ProgressBar;

    // Start is called before the first frame update
    void Start()
    {
        //Call coroutine to load the main scene
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        //create an async operation = LoadSceneAsync("Main")
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("FINAL_DEMO");


        //while operation isn't finiashed
        while (!asyncOperation.isDone)
        {

            ProgressBar.fillAmount = asyncOperation.progress;

            //yield wait for frame
            yield return new WaitForEndOfFrame();

        }


    }
}
