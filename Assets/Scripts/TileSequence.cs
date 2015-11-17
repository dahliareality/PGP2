using UnityEngine;
using System.Collections;

public class TileSequence : MonoBehaviour {

    // This script is part of the Tile puzzle and should be put on each individual floor tile used for the puzzle.
    // Make sure these objects have a box collider that the player can enter

    // KEEP THE FIRST TWO PUBLIC!
    public int TileNumber;
    public bool trueTile;
    private bool steppedOnTile;
    private TilePuzzle tilPzl;
    
    void Start ()
    {
        tilPzl = GameObject.Find("Tile Puzzle Controller").GetComponent<TilePuzzle>();
    }

    void Update()
    {
        // When resetting the puzzle
        if (tilPzl.reset)
        {
            steppedOnTile = false;
        }
    }

    // Trigger : When entering it
    void OnTriggerEnter(Collider other)
    {
        // Only work when the object tagged as Player enters the trigger
        if (other.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            this.gameObject.GetComponent<SECTR_PointSource>().Play();

            // Prevent the player from stepping on the same tile again before the puzzle has been reset
            if (!steppedOnTile && !tilPzl.isCorrect)
            {
                steppedOnTile = true;
                
                // Check if the player steps on the correct tile, then insert the number into the sequence
                // if it's not the correct tile, then reset the sequence
                if (trueTile)
                {
                    tilPzl.inputSequence[tilPzl.countValue] = TileNumber;
                    tilPzl.countValue++;
                }
                else
                {
                    tilPzl.Reset();
                }
            }
        }
    }

    // Trigger : When leaving it
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            // Put up sound here, when player leaves the tile
        }
    }
}