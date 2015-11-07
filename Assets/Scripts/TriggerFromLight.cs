using UnityEngine;
using System.Collections;
//Add to whatever is going to be the triggering object
public class TriggerFromLight : MonoBehaviour {

    GameObject movingCube;
    RaycastHit rayHit;
    public string triggerAction;

	// Use this for initialization
	void Start () {
        movingCube = GameObject.FindGameObjectWithTag(triggerAction);
	}
	
	// Update is called once per frame
	void Update () {
        //checks to see if the light-ray from Light Test 2 hits a trigger
        //and then gives it an action
        rayHit = GameObject.FindGameObjectWithTag("LightSource").GetComponent<lvl4LightReflection>().getRayHit();
        if (rayHit.collider.gameObject.tag == "Trigger")
        {
            movingCube.transform.Rotate(1, 0, 0);
            
        }//else if (rayHit.collider.gameObject.tag != "untagged") { movingCube.transform.Rotate(0, 1, 0); }
	}
}
