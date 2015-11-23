using UnityEngine;
using System.Collections;

public class Lammasu : MonoBehaviour {

    public bool lammasuTaken = false;
    private bool hasRisenOnceAgain = false;
    private int lifted;

    private TriggerFromSunLight sunPuzzle;
    private TilePuzzle tilPzl;
    Vector3 riseLamma;
    Vector3 riseLamma2;


    // Use this for initialization
    void Start () {

        tilPzl = GameObject.Find("Tile Puzzle Controller").GetComponent<TilePuzzle>();
        sunPuzzle = GameObject.Find("Sun Room").GetComponent<TriggerFromSunLight>();
        lifted = 20;
        riseLamma = new Vector3(this.transform.position.x, 132.5535f, this.transform.position.z);
        riseLamma2 = new Vector3(GameObject.Find("Lammasu").transform.position.x, 132.97f, GameObject.Find("Lammasu").transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {

        if ((tilPzl.tilePuzzleSolved == true && sunPuzzle.sunPuzzleSolved == true) && hasRisenOnceAgain == false)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, riseLamma, 0.52f * Time.deltaTime);
            GameObject.Find("Lammasu").transform.position = Vector3.Lerp(GameObject.Find("Lammasu").transform.position, riseLamma2, 0.52f * Time.deltaTime);


        }

        if (!GameObject.Find("Lammasu").GetComponent<Pickable>().CanPickUp)
        {
            lammasuTaken = true;
            hasRisenOnceAgain = true;
        }
    }
}
