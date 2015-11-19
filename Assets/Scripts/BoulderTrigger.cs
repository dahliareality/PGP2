using UnityEngine;
using System.Collections;

// -----------------------
// Add to invisible objects which should trigger a door or something to close the exit. 
// -----------------------

public class BoulderTrigger : MonoBehaviour {


    private bool hasCollided = false;

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "boulderTag")
        {
            hasCollided = true;
        }
    }

    public bool HasCollided
    {
        get { return hasCollided; }
    }
}
