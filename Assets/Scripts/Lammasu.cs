using UnityEngine;
using System.Collections;

public class Lammasu : MonoBehaviour {

    public bool lammasuTaken = false;
    private bool hasRisenOnceAgain = false;
    private int lifted;

    private TriggerFromSunLight sunPuzzle;
    private TilePuzzle tilPzl;
    Vector3 riseLamma;


    // Use this for initialization
    void Start () {

        tilPzl = GameObject.Find("Tile Puzzle Controller").GetComponent<TilePuzzle>();
        sunPuzzle = GameObject.Find("Sun Room").GetComponent<TriggerFromSunLight>();
        lifted = 20;
        riseLamma = new Vector3(this.transform.position.x, this.transform.position.y + lifted, this.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {

        if ((tilPzl.tilePuzzleSolved == true && sunPuzzle.sunPuzzleSolved == true) && hasRisenOnceAgain == false)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, riseLamma, 0.52f * Time.deltaTime);

        }
        if (this.gameObject.transform.position == riseLamma)
        {
            GameObject.Find("Lv3_Nabatean_Sandstone_Statue_Platform").GetComponent<Collider>().enabled = true;
            Debug.Log("is this happening?");
            hasRisenOnceAgain = true;
        }

        if (!GameObject.Find("Lammasu").GetComponent<Pickable>().CanPickUp)
        {
            lammasuTaken = true;
        }
    }
}
