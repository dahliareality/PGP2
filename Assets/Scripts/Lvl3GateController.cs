using UnityEngine;
using System.Collections;

public class Lvl3GateController : MonoBehaviour {

    // Put this on the first gate object on the boulder progression
    public bool sunPuzzleSolved = false;
    public bool tilePuzzleSolved = false;
    private int nrOfPuzzlesSolved = 0;
    private TriggerFromSunLight sunPuzzle;
    private TilePuzzle tilPzl;

    private bool finished;

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
            nrOfPuzzlesSolved++;
        }

        if (tilePuzzleSolved == true && sunPuzzleSolved == true)
        {
            Destroy(GameObject.Find("Wooden Grate 02"));
            nrOfPuzzlesSolved++;
        }

        /*if (nrOfPuzzlesSolved == 2)
        {
            if (!finished)
            {
                this.GetComponent<Animation>().Play();

                finished = true;
            }
        }*/
        //Debug.Log(nrOfPuzzlesSolved);
	}
}
