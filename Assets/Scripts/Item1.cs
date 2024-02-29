using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour
{
    public float distance;

    //Game objects referencing the on screen text objects (button/description) and the door itself.
    public GameObject buttonDescription;
    public GameObject item;
    public GameObject innerCross;
    //public AudioSource doorOpening;

    void Update()
    {
        //Setting distance variable to the distance from the target in the RayCasting script
        distance = RayCasting.distance;

    }

    //Enable on screen text when looking at object & perform actions on button press
    void OnMouseOver()
    {
        //If you are within 2.5 units of the door, display the button and its description by setting it to true
        if (distance < 2.5)
        {
            buttonDescription.SetActive(true);
            innerCross.SetActive(true);
        }
        else
        {
            buttonDescription.SetActive(false);
            innerCross.SetActive(false);
        }

        //If correct button is pressed, continue to next if
        if (Input.GetButtonDown("XButton"))
        {
            /*If you are within 2.5 units of the door and have pressed button assigned above
            disable on screen text, disable the door box collider (can cause issues), open the door, and make a sound if wanted*/
            if (distance < 2.5)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                buttonDescription.SetActive(false);
                item.SetActive(false);
                innerCross.SetActive(false);
                Debug.Log("Item1");
                //doorOpening.Play();
            }
        }
    }

    //Disable on screen text when looking away
    void OnMouseExit()
    {
        buttonDescription.SetActive(false);
        innerCross.SetActive(false);
    }
}
