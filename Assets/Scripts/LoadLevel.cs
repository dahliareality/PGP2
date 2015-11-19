using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	//private bool scene2Loaded = false;
    //private Level1Door door;
    private bool level2Load;
    private LevelPrep prepare2;

	// Use this for initialization
	void Start () {

        //door = GameObject.Find("Door").GetComponent<Level1Door>();
        prepare2 = GameObject.Find("LevelLoader").GetComponent<LevelPrep>();
        prepare2.StartLoading();
        level2Load = true;

    }
	
	// Update is called once per frame
	void Update () {



        if (level2Load == true)
        {
            prepare2.ActivateScene();
            //scene2Loaded = true;
            level2Load = false;
        }
    }

	public void OnTriggerEnter(Collider col){
		
	}
}
