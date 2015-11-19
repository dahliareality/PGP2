using UnityEngine;
using System.Collections;

public class LoadLevel3Skip2 : MonoBehaviour {

    private bool level3Load;
    private Level3Prep prepare3;
    public bool skipLvl2 = false;

    // Use this for initialization
    void Start () {
        if (skipLvl2 == true)
        {
            GameObject.Find("LevelLoader").GetComponent<LoadLevel>().enabled = false;
            prepare3 = GameObject.Find("LoadLevel3").GetComponent<Level3Prep>();
            prepare3.StartLoading();
            level3Load = true;
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (level3Load == true)
        {
            prepare3.ActivateScene();
            //scene2Loaded = true;
            level3Load = false;
        }
    }
}
