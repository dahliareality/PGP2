using UnityEngine;
using System.Collections;

public class LoadLevel3 : MonoBehaviour {
    //private bool scene3Loaded = false;
    //private Level1Door door;
    private Level2CaveDoor giantDoor;
    private bool level3Load;
    private Level3Prep prepare3;

    void Start()
    {
        giantDoor = GameObject.Find("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor>();
        prepare3 = GameObject.Find("Level3Loader").GetComponent<Level3Prep>();
        prepare3.StartLoading();
    }

    void Update()
    {

        if (giantDoor.puzzleDone == true)
        {
            level3Load = true;
        }

        if (level3Load == true)
        {
            prepare3.ActivateScene();
            //scene3Loaded = true;
        }
    }

    public void OnTriggerEnter(Collider col)
    {

    }
}
