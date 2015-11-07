using UnityEngine;
using System.Collections;

// -----------------------
// Add to invisible objects which should trigger a door or something to close the exit. 
// -----------------------

public class ExitPoint : MonoBehaviour
{

    private bool hasEntered = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            hasEntered = true;
        }
    }

    public bool HasEntered
    {
        get { return hasEntered; }
    }
}