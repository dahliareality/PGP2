using UnityEngine;
using System.Collections;

// --------------------------
// Attach this script to the switch object
// --------------------------

public class SwitchScript : MonoBehaviour
{

    public bool isActive;
    //public bool playSound;

    public GameObject[] objectsToActivate;

    private bool allowSendActivation = true;

    void Update()
    {
        if (isActive)
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
            activateObjects();
            //playSound = true;

        }
        else
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
            //playSound = true;
        }

        //if (playSound) {
        //	this.GetComponent<SECTR_PointSource>().Play();
        //	playSound = false;
        //}
    }

    void activateObjects()
    {
        if (allowSendActivation)
        {
            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                if (objectsToActivate[i].GetComponent<Activated>().enabled == true)
                    objectsToActivate[i].GetComponent<Activated>().activate();
            }
            allowSendActivation = false; // only activate once! (because the activated is a bool)
        }
    }

}