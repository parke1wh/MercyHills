using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public float distance;

    //Game objects referencing the on screen text objects (button/description) and the door itself.
    public GameObject buttonDescription;
    public GameObject hinge;
    public GameObject innerCross;

    public AudioClip doorOpening;
    public AudioClip doorClosing;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
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
                innerCross.SetActive(false);
                hinge.GetComponent<Animation>().Play("DoorOpening");
                source.PlayOneShot(doorOpening, 0.7f);
                //doorOpening.Play();

                StartCoroutine(timer());
                

            }
        }
    }

    //Disable on screen text when looking away
    void OnMouseExit()
    {
        buttonDescription.SetActive(false);
        innerCross.SetActive(false);
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(6);
        hinge.GetComponent<Animation>().Play("DoorClosing");
        source.PlayOneShot(doorClosing, 0.7f);
        yield return new WaitForSeconds(2);
        this.GetComponent<BoxCollider>().enabled = true;
    }
}