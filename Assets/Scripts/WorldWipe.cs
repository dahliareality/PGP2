using UnityEngine;
using System.Collections;

public class WorldWipe : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L)) { Application.LoadLevel("Level1");

        }

    }
}
