using UnityEngine;
using System.Collections;
//Add to whatever is going to be the triggering object
public class TriggerFromSunLight : MonoBehaviour {

    GameObject movingCube;
    RaycastHit rayHit;
    private int i = 1;
    //public string triggerAction; remains from original script
    private bool sunOneActive = true;
    private bool sunTwoActive = false;
    private bool sunThreeActive = false;
    private bool sunFourActive = false;
    private bool sunOneTriggered = false;
    private bool sunTwoTriggered = false;
    private bool sunThreeTriggered = false;
    private bool sunFourTriggered = false;
    public bool sunPuzzleSolved = false;

	// Use this for initialization
	void Start () {
       // movingCube = GameObject.FindGameObjectWithTag(triggerAction);
	}
	
	// Update is called once per frame
	void Update () {
        //checks to see if the light-ray hits a trigger
        //and then gives it an action
        rayHit = GameObject.FindGameObjectWithTag("LightSource").GetComponent<SunPuzzle>().getRayHit();
        if (rayHit.collider.gameObject.tag == "Sun"+i)
        {

//            Debug.Log("Sun" + i);
            if (sunOneActive == true)
            {
                sunOneActive = false;
                sunOneTriggered = true;
                sunTwoActive = true;
                i += 1;
                Debug.Log("Hitting 1");
            }
            else if (sunTwoActive == true)
            {
                sunTwoActive = false;
                sunTwoTriggered = true;
                sunThreeActive = true;
                i += 1;
                //Debug.Log("Hitting 2");
            }
            else if (sunThreeActive == true)
            {
                sunThreeActive = false;
                sunThreeTriggered = true;
                sunFourActive = true;
                i += 1;
                //Debug.Log("Hitting 3");
            }
            else if (sunFourActive == true)
            {
                sunFourActive = false;
                sunFourTriggered = true;
            }
            if (sunFourTriggered == true)
            {

                /*GetComponent<Level3GateController>().*/sunPuzzleSolved = true;
            }
            /*Debug.Log(i);
            Debug.Log(sunOneActive);
            Debug.Log("Sun" + i);*/
        }//else if (rayHit.collider.gameObject.tag != "untagged") { movingCube.transform.Rotate(0, 1, 0); }
	}
}
