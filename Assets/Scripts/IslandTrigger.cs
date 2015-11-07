using UnityEngine;
using System.Collections;

public class IslandTrigger : MonoBehaviour
{
    // This script should be attached to the triggers for each island in level 4. When the player
    // has been inside of the trigger of each island for 6 seconds then they've solved the puzzle.

    private bool inTrigger;
    private bool isSolved;
    private GameObject door;

    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Island Door");
    }

    // Trigger : Entering it
    void OnTriggerEnter(Collider other)
    {
        // Make sure it only triggers for the object tagged as Player
        if (other.tag == "Player")
        {
            // Toggle when player is standing inside of the trigger
            inTrigger = true;
            //Debug.Log("Enter");
            // If this particular trigger hasn't been solved before, then start a timer
            if (!isSolved)
            {
                StartCoroutine(Timer());
            }
        }
    }

    // Trigger : Leaving it
    void OnTriggerExit(Collider other)
    {
        // Make sure it only triggers for the object tagged as Player
        if (other.tag == "Player")
        {
            // Toggle when player leaves the trigger
            inTrigger = false;
            //Debug.Log("Leave");
        }
    }

    public IEnumerator Timer()
    {
        // Wait 6 seconds, before executing the code below it
        yield return new WaitForSeconds(6);

        // When the player is still inside of the trigger after the timer has run out
        if (inTrigger)
        {
            //Debug.Log("Zing!");
            isSolved = true;
            yield return door.GetComponent<IslandDoor>().count = door.GetComponent<IslandDoor>().count + 1;
        }
        else
        {
            //Debug.Log("Fail!");
            yield return null;
        }
    }
}
