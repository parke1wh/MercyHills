using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractions : MonoBehaviour
{
    public float distance;

    //Game objects referencing the on screen text objects (button/description) and the door itself.
    public GameObject buttonDescription;
    public GameObject buttonActiveDescription;
    public GameObject item;
    public GameObject innerCross;
    public Text buttonDeactivate;
    //public AudioSource doorOpening;

    [SerializeField] private GameObject triggerArea;

    public Tasks tasks;
    public bool check;
    public int taskNum;
    public int dayNum;

    void Update()
    {
        //Setting distance variable to the distance from the target in the RayCasting script
        distance = RayCasting.distance;

    }

    //Enable on screen text when looking at object & perform actions on button press
    void OnMouseOver()
    {
        //If you are within 2.5 units of the door, display the button and its description by setting it to true
        if (distance < 3.5 && check)
        {
            buttonDescription.SetActive(false);
            buttonActiveDescription.SetActive(true);
            innerCross.SetActive(true);
        }
        else if (distance < 3.5 && !check)
        {
            buttonDescription.SetActive(true);
            buttonActiveDescription.SetActive(false);
            innerCross.SetActive(false);
        }

        //If correct button is pressed, continue to next if
        if (Input.GetButtonDown("XButton"))
        {
            /*If you are within 2.5 units of the door and have pressed button assigned above
            disable on screen text, disable the door box collider (can cause issues), open the door, and make a sound if wanted*/
            if (distance < 3.5 && check)
            {
                //this.GetComponent<BoxCollider>().enabled = false;

                buttonDescription.SetActive(false);
                buttonActiveDescription.SetActive(false);
                //buttonDeactivate.text = " ";

                innerCross.SetActive(false);

                Debug.Log("Button " + taskNum);
                //doorOpening.Play();

                //Tasks check
                if (dayNum == 1)
                    tasks.day1Tasks(taskNum);
                else
                    tasks.day2Tasks(taskNum);

            }
        }
    }

    //Disable on screen text when looking away
    void OnMouseExit()
    {
        buttonDescription.SetActive(false);
        buttonActiveDescription.SetActive(false);
        innerCross.SetActive(false);
    }

    public void turnOff()
    {
        triggerArea.SetActive(false);
    }

    public void turnOn()
    {
        triggerArea.SetActive(true);
    }
}
