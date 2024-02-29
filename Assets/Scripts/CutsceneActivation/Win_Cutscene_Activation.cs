using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Cutscene_Activation : MonoBehaviour
{
    public GameObject winCutscene;


    public void EnableCutscene()
    {
       winCutscene.SetActive(true);
    }
}
