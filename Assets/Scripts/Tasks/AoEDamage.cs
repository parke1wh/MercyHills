using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEDamage : MonoBehaviour
{
    // Start is called before the first frame update

    public Status status;
    

    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            status.check = true;
        }
            
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            status.check = false; ;
        }
    }


}
