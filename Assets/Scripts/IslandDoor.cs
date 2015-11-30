using UnityEngine;
using System.Collections;

public class IslandDoor : MonoBehaviour {

    // This script should be placed on the door in level 4, it will open when all 3 island triggers have been solved.

    public Transform endPos;
    //public GameObject[] switches;
	public GameObject switch1;
	public GameObject switch2;
	public GameObject switch3;

	private bool soundPlayed;

    public int count;

	
	void Update () {
		
        //Debug.Log(count)

		if (switch1.GetComponent<Interact> ().activated && switch2.GetComponent<Interact> ().activated && switch3.GetComponent<Interact> ().activated)
		{
			this.transform.position = Vector3.Lerp (this.transform.position, endPos.position, 0.4f * Time.deltaTime);
			if(!soundPlayed){
				this.gameObject.GetComponent<SECTR_PointSource>().Play();
				soundPlayed = true;
			}
		}
	}
}
