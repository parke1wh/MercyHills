using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day1Animations : MonoBehaviour
{

    Animator animText;


    IEnumerator ResetAnimation;
       

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

    public void playAnimation(string text)
    {
        dayTasksText.text = text;
        timer = 2f;
        animText.SetBool("check", true);
        check = true;

        //StartCoroutine(ResetAnimation);

    }


    



}

//animText.SetBool("check", false);