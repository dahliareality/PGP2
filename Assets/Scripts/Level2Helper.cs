using UnityEngine;
using System.Collections;
//Adds the Resource Controller and Fog of War scripts to the main camera
//and the Line of Sight empty
public class Level2Helper : MonoBehaviour {

    private bool activate = true;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

	    if (GameObject.Find("FogActivater").GetComponent<ExitPoint>().HasEntered && activate == true)
        {
            activate = false;
            GameObject.Find("LoS").AddComponent<FOW>();
            GameObject.Find("Main Camera").GetComponent<ResourceController>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<ResourceController>().threshold = 3;

        }

        if (Input.GetKeyDown(KeyCode.H) == true)
        {
            Destroy(GameObject.Find("Main Camera").GetComponent<ResourceController>());
        }
	}
}
