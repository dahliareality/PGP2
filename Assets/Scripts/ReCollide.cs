using UnityEngine;
using System.Collections;

public class ReCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("Colls").GetComponent<ExitPoint>().HasEntered)
        {
            for (int i = 1; i < 251; i++)
            {
                GameObject.Find("Box006_Part_" + i).GetComponent<Collider>().enabled = true;
            }
        }

    }
}
