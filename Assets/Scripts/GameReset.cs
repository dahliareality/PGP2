using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("World Reset Cube").GetComponent<ExitPoint>().HasEntered)
        {
            Application.LoadLevel("Level1");
        }

    }
}
