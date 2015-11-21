using UnityEngine;
using System.Collections;

public class Level1Mover : MonoBehaviour {

    private LoadLevel3Skip2 moveIt;
    private GameObject childObject;
    private GameObject parentObject;
    //public GameObject player1;

	// Use this for initialization
	void Start () {

        moveIt = GameObject.Find("LoadLevel3").GetComponent<LoadLevel3Skip2>();
        parentObject = GameObject.Find("PlayerHolder");

    }
	
	// Update is called once per frame
	void Update () {
        //skips level 2
        if (moveIt.skipLvl2 == true)
        {
            GameObject.Find("Level1Mover").SetActive(false);
            childObject = GameObject.FindGameObjectWithTag("Player");
            childObject.transform.parent = parentObject.transform;
        }
        //does not skip level 2
        else
        {
            GameObject.Find("Level1Mover (1)").SetActive(false);
            childObject = GameObject.FindGameObjectWithTag("Player");
            childObject.transform.parent = parentObject.transform;
        }
    }
}
