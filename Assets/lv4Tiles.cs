using UnityEngine;
using System.Collections;

public class lv4Tiles : MonoBehaviour
{

    // This script is part of the Tile puzzle and should be put on each individual floor tile used for the puzzle.
    // Make sure these objects have a box collider that the player can enter

    // KEEP THE FIRST TWO PUBLIC!
    public bool activated;

    // Trigger : When entering it
    void OnTriggerEnter(Collider other)
    {
        // Only work when the object tagged as Player enters the trigger
        if (other.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            this.gameObject.GetComponent<SECTR_PointSource>().Play();
            activated = true;
        }
    }

    // Trigger : When leaving it
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            activated = false;
            // Put up sound here, when player leaves the tile
        }
    }
}