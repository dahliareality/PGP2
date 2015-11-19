using UnityEngine;
using System.Collections;

public class Level3AntiBacktrack : MonoBehaviour {

    private Vector3 slideVector;

    // Use this for initialization
    void Start () {

        slideVector = new Vector3(this.transform.position.x, this.transform.position.y- 26f, this.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
	    
        if (GameObject.Find("L2Deleter").GetComponent<ExitPoint>().HasEntered)
        { 
            this.transform.position = Vector3.Lerp(this.transform.position, slideVector, 0.52f * Time.deltaTime);
            Destroy(GameObject.Find("Level1Mover"));
        }

    }
}
