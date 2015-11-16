using UnityEngine;
using System.Collections;

// --------------------------
// Attach this script to the switch object
// --------------------------

public class SwitchScript : MonoBehaviour
{

    public bool isActive;
    public AudioClip leverSound;

    public GameObject[] objectsToActivate;

    private bool allowSendActivation = true;

    private bool hasPlayed = false;

    void Update()
    {
        if (isActive)
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
            activateObjects();
            playSound();
        }
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

    void playSound()
    {
        if (!hasPlayed)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(leverSound, 1.0f);
            hasPlayed = true;
        }
    }
}