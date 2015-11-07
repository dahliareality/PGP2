using UnityEngine;
using System.Collections;

// ----------------------
// Add to whatever is going to be the Light triggering object
// ----------------------

public class LightTriggerScript : MonoBehaviour {

    private bool isLite;
	
	void Update () {
        // placeholder incase of object should react to something.
        if (isLite)
        {

        }
        else
        {

        }
	}

    public bool IsLite
    {
        get { return isLite; }
        set { isLite = value; }
    }
}
