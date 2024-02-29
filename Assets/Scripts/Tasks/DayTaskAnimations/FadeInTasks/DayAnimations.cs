using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayAnimations : MonoBehaviour
{

    Animator animText;      

    public Text dayTasksText;

    public bool check = true;

    public float timer = 2f;



    // Start is called before the first frame update
    void Start()
    {
        animText = GetComponent<Animator>();
    }

    private void Update()
    {



        if (check)
        {
            timer -= Time.deltaTime;

            if(timer < 0f)
            {
                check = false;
                animText.SetBool("check", false);
            }
        }
        
        
     
        
    }

    public void playAnimation()
    {
        dayTasksText.text = "New Task Available";
        timer = 2f;
        animText.SetBool("check", true);
        check = true;

        //StartCoroutine(ResetAnimation);

    }

}

//animText.SetBool("check", false);