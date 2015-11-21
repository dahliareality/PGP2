using UnityEngine;
using System.Collections;

public class Level1Mover : MonoBehaviour {

    private LoadLevel3Skip2 moveIt;
    private GameObject childObject;
    private GameObject parentObject;

	// Use this for initialization
	void Start () {

        moveIt = GameObject.Find("LoadLevel3").GetComponent<LoadLevel3Skip2>();
        childObject = GameObject.FindGameObjectWithTag("Player");
        parentObject = GameObject.Find("PlayerHolder");

    }
	
	// Update is called once per frame
	void Update () {
        if (moveIt.skipLvl2 == true)
        {
            GameObject.Find("Level1Mover").SetActive(false);
            childObject.transform.parent = parentObject.transform;
        }
        else
        {
            GameObject.Find("Level1Mover (1)").SetActive(false);
            childObject.transform.parent = parentObject.transform;
        }
	}
}
