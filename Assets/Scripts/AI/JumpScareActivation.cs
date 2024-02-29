using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class JumpScareActivation : MonoBehaviour
{
    [SerializeField] private PlayableDirector jumpScareCutscene;
    private bool cutsceneIsDone = false;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            StartCoroutine(startCutscene());
            transform.parent.gameObject.GetComponent<JumpScareSpawner>().RandomizeTriggers(other, this.transform.position, false);
        }
    }

    private void Update()
    {
        //if(jumpScareCutscene.time >= 1.50f)
        //{
        //    cutsceneIsDone = false;
        //}
    }

    IEnumerator startCutscene()
    {
        jumpScareCutscene.gameObject.SetActive(true);
        yield return new WaitForSeconds(((float)jumpScareCutscene.time));
    }

}
