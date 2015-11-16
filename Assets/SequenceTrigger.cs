using UnityEngine;
using System.Collections;

public class SequenceTrigger : MonoBehaviour
{
    private GameObject sequenceController;
    private SequencePuzzle sqnPzl;

    // Part of the Sequence puzzle. This should be attached to the trigger objects that will finish the puzzle when all 3 segments have entered them.
    void Start()
    {
        //count = GameObject.Find("Puzzle Controller").GetComponent<SequencePuzzle>();
        sequenceController = GameObject.Find("Cogwheel Puzzle");
    }

    void Update()
    {
        //Debug.Log(count);
        if (sequenceController.GetComponent<SequencePuzzle>().countValue == 3)
        {
            // Function should go here. Currently when all 3 segments are in the triggers, they will all destroy
            Debug.Log("Puzzle completed: Destroying triggers");
            Destroy(gameObject);
        }
    }

    // Trigger : When the moving segments enter it
    void OnCollison(Collider other)
    {
        if (GameObject.FindWithTag("Sequence Mover"))
        {
            Debug.Log("Segment: In");
            sequenceController.GetComponent<SequencePuzzle>().countValue++;
        }
    }

    // Trigger : When the moving segments leave it
    void OnTriggerExit(Collider other)
    {
        if (GameObject.FindWithTag("Sequence Mover"))
        {
            Debug.Log("Segment: Out");
            sequenceController.GetComponent<SequencePuzzle>().countValue--;
        }
    }
}
