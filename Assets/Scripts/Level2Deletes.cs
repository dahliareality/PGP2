using UnityEngine;
using System.Collections;

public class Level2Deletes : MonoBehaviour {


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("L2Deleter").GetComponent<ExitPoint>().HasEntered)
        {
            Destroy(GameObject.Find("1 to 2 transition"));
            Destroy(GameObject.Find("Entire level 2"));
        }

    }
}
