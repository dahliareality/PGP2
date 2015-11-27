using UnityEngine;
using System.Collections;

public class Level3GateController : MonoBehaviour
{

    // Put this on the first gate object on the boulder progression
    public bool sunPuzzleSolved = false;
    public bool tilePuzzleSolved = false;
    private TriggerFromSunLight sunPuzzle;
    private TilePuzzle tilPzl;
    private bool isSunDone, isTileDone, arePuzzlesDone, isRoomDone;

	public GameObject woodenGrate1, woodenGrate2, plingSoundSun, plingSoundTile;
    private GameObject rollSound1, rollSound2;

    void Start()
    {
        rollSound1 = GameObject.Find("BoulderRollingSound1");
        rollSound2 = GameObject.Find("BoulderRollingSound2");
        //Debug.Log("Starting, yo!");
        tilPzl = GameObject.Find("Tile Puzzle Controller").GetComponent<TilePuzzle>();
        sunPuzzle = GameObject.Find("Sun Room").GetComponent<TriggerFromSunLight>();
		plingSoundSun = GameObject.Find ("PlingSoundSun");
		plingSoundTile = GameObject.Find ("PlingSoundTile");
    }

    void Update()
    {

        //Debug.Log("Updating this ho");
        if (tilPzl.tilePuzzleSolved == true)
        {
            tilePuzzleSolved = true;
        }

        if (sunPuzzle.sunPuzzleSolved == true)
        {
            sunPuzzleSolved = true;
        }
		/*
		if ((sunPuzzle.sunPuzzleSolved || tilPzl.tilePuzzleSolved) && !isPuzzleDone) {
			isPuzzleDone=true;
			Debug.Log ("Pling!");
		}*/
		if ((sunPuzzle.sunPuzzleSolved && !tilPzl.tilePuzzleSolved) && !isSunDone) {
			isSunDone=true;
			//Debug.Log ("Sun is done");
			plingSoundSun.GetComponent<AudioSource>().Play();
		}
		if ((!sunPuzzle.sunPuzzleSolved && tilPzl.tilePuzzleSolved) && !isTileDone) {
			isTileDone=true;
			//Debug.Log ("Tile is done");
			plingSoundTile.GetComponent<AudioSource>().Play();
		}

        if ((tilePuzzleSolved == true && sunPuzzleSolved == true) && !arePuzzlesDone)
        {
            arePuzzlesDone = true;
            //Debug.Log("Raaarg!");
            //rollSound1.GetComponent<SECTR_PropagationSource>().Play();
            rollSound1.GetComponent<AudioSource>().Play();
            Destroy(woodenGrate1);
            //nrOfPuzzlesSolved = 1;
        }
        if ((GameObject.Find("Lammasu Platform").GetComponent<Lammasu>().lammasuTaken == true && arePuzzlesDone) && !isRoomDone)
        {
			isRoomDone = true;
            //Debug.Log("Finally!");
            //rollSound2.GetComponent<SECTR_PropagationSource>().Play();
            rollSound2.GetComponent<AudioSource>().Play();
			//Debug.Log ("RollSound2 playing");
            Destroy(woodenGrate2);
            //nrOfPuzzlesSolved = 2;
        }
        //Debug.Log(nrOfPuzzlesSolved);
    }
}