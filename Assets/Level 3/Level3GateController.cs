using UnityEngine;
using System.Collections;

public class Level3GateController : MonoBehaviour {

    // Put this on the first gate object on the boulder progression
    public bool sunPuzzleSolved = false;
    public bool tilePuzzleSolved = false;
    //private int nrOfPuzzlesSolved = 0;
    private TriggerFromSunLight sunPuzzle;
    private TilePuzzle tilPzl;

    void Start ()
    {
        tilPzl = GameObject.Find("Tile Puzzle Controller").GetComponent<TilePuzzle>();
        sunPuzzle = GameObject.Find("Sun Room").GetComponent<TriggerFromSunLight>();
    }
	
	void Update () {

        if (tilPzl.tilePuzzleSolved == true)
        {
            tilePuzzleSolved = true;
        }

        if (sunPuzzle.sunPuzzleSolved == true)
        {
            sunPuzzleSolved = true;
        }
	
        if (tilePuzzleSolved == true || sunPuzzleSolved == true)
        {
            Destroy(GameObject.Find("Wooden Grate 01"));
            //nrOfPuzzlesSolved = 1;
        }
        if (tilePuzzleSolved == true && sunPuzzleSolved == true)
        {
            Destroy(GameObject.Find("Wooden Grate 02"));
            //nrOfPuzzlesSolved = 2;
        }
        //Debug.Log(nrOfPuzzlesSolved);
	}
}
