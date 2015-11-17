using UnityEngine;
using System.Collections;

public class Level3GateController : MonoBehaviour
{

    // Put this on the first gate object on the boulder progression
    public bool sunPuzzleSolved = false;
    public bool tilePuzzleSolved = false;
    //private int nrOfPuzzlesSolved = 0;
    private TriggerFromSunLight sunPuzzle;
    private TilePuzzle tilPzl;
    private bool isPuzzle1Done, isPuzzle2Done;

    public GameObject woodenGrate1, woodenGrate2;
    private GameObject rollSound1, rollSound2;

    void Start()
    {
        rollSound1 = GameObject.Find("BoulderRollingSound1");
        rollSound2 = GameObject.Find("BoulderRollingSound2");
        Debug.Log("Starting, yo!");
        tilPzl = GameObject.Find("Tile Puzzle Controller").GetComponent<TilePuzzle>();
        sunPuzzle = GameObject.Find("Sun Room").GetComponent<TriggerFromSunLight>();
    }

    void Update()
    {

        Debug.Log("Updating this ho");
        if (tilPzl.tilePuzzleSolved == true)
        {
            tilePuzzleSolved = true;
        }

        if (sunPuzzle.sunPuzzleSolved == true)
        {
            sunPuzzleSolved = true;
        }

        if ((tilePuzzleSolved == true || sunPuzzleSolved == true) && !isPuzzle1Done)
        {
            isPuzzle1Done = true;
            Debug.Log("Raaarg!");
            //rollSound1.GetComponent<SECTR_PropagationSource>().Play();
            rollSound1.GetComponent<AudioSource>().Play();
            Destroy(woodenGrate1);
            //nrOfPuzzlesSolved = 1;
        }
        if (tilePuzzleSolved == true && sunPuzzleSolved == true && !isPuzzle2Done)
        {
            isPuzzle2Done = true;
            Debug.Log("Finally!");
            //rollSound2.GetComponent<SECTR_PropagationSource>().Play();
            rollSound2.GetComponent<AudioSource>().Play();
            Destroy(woodenGrate2);
            //nrOfPuzzlesSolved = 2;
        }
        //Debug.Log(nrOfPuzzlesSolved);
    }
}