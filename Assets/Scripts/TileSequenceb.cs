using UnityEngine;
using System.Collections;

public class TileSequenceb : MonoBehaviour {

    // This script is part of the Tile puzzle and should be put on each individual floor tile used for the puzzle. Make sure these objects have a box collider that the player can enter

    public int tileNumber;
    private TilePuzzle tilPzl;
    private bool hasInputNumber;

    void Start ()
    {
        tilPzl = GameObject.Find("Tile Puzzle Controller").GetComponent<TilePuzzle>();
    }

    // Trigger testing : When entering it
    void OnTriggerEnter(Collider other)
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, transform.position.z);

        // Only input the number into the sequence once
        if (!hasInputNumber) {
            tilPzl.inputSequence[tilPzl.countValue] = tileNumber;
            tilPzl.countValue++;
            hasInputNumber = true;
			this.gameObject.GetComponent<SECTR_PointSource>().Play ();
			Debug.Log ("Stepped on tile "+tileNumber);
        }
    }

    // Trigger testing : When leaving it
    void OnTriggerExit(Collider other)
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
        if (hasInputNumber)
        {
            hasInputNumber = false;
        }
    }
}
