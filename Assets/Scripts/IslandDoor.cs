using UnityEngine;
using System.Collections;

public class IslandDoor : MonoBehaviour {

    // This script should be placed on the door in level 4, it will open when all 3 island triggers have been solved.

    public int count;
	
	void Update () {

        //Debug.Log(count);

	    if (count >= 3)
        {
            Destroy(gameObject);
        }
	}
}
