using UnityEngine;
using System.Collections;

public class SequencePuzzle : MonoBehaviour {

    // This is the controller script for the Sequence puzzle.
    // It should be put onto an empty game object. Preferably you should make the interactable buttons, which the other script is attached to, children of this empty object.

    private int[] correctSequence = { 3, 2, 2, 3, 1 }; // Change this accordenly for whished input sequence.
    public int[] inputSequence = new int[5];
    private bool isCorrect;

    private RayCast rc;

    void Start ()
    {
        rc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCast>();
    }

	void Update () {

        //Debug.Log(inputSequence[0]+" "+inputSequence[1]+" "+inputSequence[2]+" "+inputSequence[3]+" "+inputSequence[4]);

        // Run this when both arrays are the same length
        if (inputSequence != null)
        {
            if (rc.countValue == inputSequence.Length)
            {
                // Run for loop to check each individual element in the array
                for (int i = 0; i < inputSequence.Length; i++)
                {
                    if (inputSequence[i] == correctSequence[i])
                    {
                        // Toggle bool to true
                        isCorrect = true;
                    }
                    else
                    {
                        // Break loop if it's not correct, and toggle bool to false
                        isCorrect = false;
                        break;
                    }
                }
                // After the loop, execute if statements to check the sequence
                if (isCorrect)
                {
                    //Debug.Log("Success!");
                    // Proper function here, for when the sequence is correct
                }
                else
                {
                    //Debug.Log("False!");

                    // Proper function here, for when the sequence is incorrect
                    
                    // Reset all array elements back to zero'
                    for (int j = 0; j < inputSequence.Length; j++)
                    {
                        inputSequence[j] = 0;
                    }
                    rc.countValue = 0;
                }
            }
        }
    }
}