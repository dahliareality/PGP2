using UnityEngine;
using System.Collections;

public class Level1Mover : MonoBehaviour {

    private LoadLevel3Skip2 moveIt;

	// Use this for initialization
	void Start () {

        moveIt = GameObject.Find("LoadLevel3").GetComponent<LoadLevel3Skip2>();

    }
	
	// Update is called once per frame
	void Update () {
        if (moveIt.skipLvl2 == true)
        {
            GameObject.Find("Level1Mover").transform.position = new Vector3(-138f, 134f, 804f);
        }
	}
}
