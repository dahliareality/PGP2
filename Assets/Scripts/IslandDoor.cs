using UnityEngine;
using System.Collections;

public class IslandDoor : MonoBehaviour {

    // This script should be placed on the door in level 4, it will open when all 3 island triggers have been solved.

    public Transform endPos;
    //public GameObject[] switches;
	public GameObject switch1;
	public GameObject switch2;
	public GameObject switch3;

    public int count;

	
	void Update () {
		
        //Debug.Log(count)

		if (switch1.GetComponent<lv4Switch> ().isActive && switch2.GetComponent<lv4Switch> ().isActive && switch3.GetComponent<lv4Switch> ().isActive)
		{
			this.transform.position = Vector3.Lerp (this.transform.position, endPos.position, 1.0f * Time.deltaTime);
		}
	}
}
