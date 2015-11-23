using UnityEngine;
using System.Collections;

public class IslandDoor : MonoBehaviour {

    // This script should be placed on the door in level 4, it will open when all 3 island triggers have been solved.

    public Transform endPos;
    public GameObject[] switches;

    public int count;
	
	void Update () {

        //Debug.Log(count);

        for (int i = 0; i < switches.Length; i++)
        {
            //Debug.Log("test");
            if (switches[i].GetComponent<lv4Switch>().isActive == true)
            {
                //Destroy(gameObject);
                this.transform.position = Vector3.Lerp(this.transform.position, endPos.position, 1.0f * Time.deltaTime);
            }
        }
	}
}
