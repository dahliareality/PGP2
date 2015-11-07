using UnityEngine;
using System.Collections;

// --------------------------
// Attach this script to the switch object
// --------------------------

public class SwitchScript : MonoBehaviour {

    public bool isActive;
	//public bool playSound;

        
	void Update () {
        if (isActive)
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
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
}
