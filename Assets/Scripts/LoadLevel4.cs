using UnityEngine;
using System.Collections;

public class LoadLevel4 : MonoBehaviour {

    private bool scene4Loaded = false;
    private bool level4Load;
    private Level4Prep prepare4;
    private TriggerFromSunLight sunPuzzle;
    private TilePuzzle tilPzl;
    public bool tilePuzzleSolved;
    public bool sunPuzzleSolved;

    // Use this for initialization
    void Start()
    {

        tilPzl = GameObject.Find("Tile Puzzle Controller").GetComponent<TilePuzzle>();
        sunPuzzle = GameObject.Find("Sun Room").GetComponent<TriggerFromSunLight>();
        prepare4 = GameObject.Find("Level4Loader").GetComponent<Level4Prep>();
        prepare4.StartLoading();

    }

    // Update is called once per frame
    void Update()
    {


        if (tilPzl.tilePuzzleSolved == true)
        {
            tilePuzzleSolved = true;
        }

        if (sunPuzzle.sunPuzzleSolved == true)
        {
            sunPuzzleSolved = true;
        }

        if (sunPuzzleSolved == true && tilePuzzleSolved == true)
        {
            prepare4.ActivateScene();
            scene4Loaded = true;
        }

        if (level4Load == true)
        {
            
        }
        //Debug.Log(level4Load);
    }

    public void OnTriggerEnter(Collider col)
    {

    }
}
