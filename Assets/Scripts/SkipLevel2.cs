using UnityEngine;
using System.Collections;

public class SkipLevel2 : MonoBehaviour {

    public bool skipLvl2 = false;
    private Level2CaveDoor caveDoor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("ExitPoint").GetComponent<ExitPoint>().HasEntered)
        {
            if (skipLvl2 == true)
            {
                GameObject.Find("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor>().correctStatues = 5;
                GameObject.Find("Player Oculus Animations").transform.position = new Vector3(-116.8f, 133f, 359.6f);
                skipLvl2 = false;
            }
            //Destroy(GameObject.Find("EntireLevel1"));
            //hasNotDeleted = false;
        }

    }
}
