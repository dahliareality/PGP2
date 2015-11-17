using UnityEngine;
using System.Collections;

public class TilePuzzle : MonoBehaviour {

    // This is the controller script for the Tile puzzle.
    // It should be put onto an empty game object. Preferably you should make the interactable tile
    // which the other script is attached to, children of this empty object.

    public int[] correctSequence = new int[5];
    public int[] inputSequence = new int[5];
    public bool isCorrect;
    public bool tilePuzzleSolved;
    private int count = 0;
    private GameObject upSound1, upSound2;
    public int countValue

    {
        get { return count; }
        set { count = value; }
    }
    public bool reset;

    void  Start()
    {
        upSound1 = GameObject.Find("ButtonUpSound1");
        upSound2 = GameObject.Find("ButtonUpSound2");
    }
	
	void Update ()
    {
        //Debug.Log(inputSequence[0] + " " + inputSequence[1] + " " + inputSequence[2] + " " + inputSequence[3] + " " + inputSequence[4]);
        // Run this when both arrays are the same length
        if (inputSequence != null)
        {
            if (count == inputSequence.Length)
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
                    tilePuzzleSolved = true;
					Debug.Log ("Tile is solved, asshole");
                }
                else
                {
                    // Proper function here, for when the sequence is incorrect
                    // Reset all array elements back to zero
                    Reset();
                }
            }
        }
    }

    // Starts the couroutine which handles the entire reset process
    public void Reset()
    {
        upSound1.GetComponent<SECTR_PointSource>().Play();
        upSound2.GetComponent<SECTR_PointSource>().Play();
        StartCoroutine(ResetSequence());
    }

    // Function for resetting the puzzle. First it will toggle rest to true so that each individual tile can reset itself
    // then it will run the for loop to reset the array, and finally wait 0.5 seconds before setting the reset back to false
    private IEnumerator ResetSequence()
    {
        yield return reset = true;
        for (int j = 0; j < inputSequence.Length; j++)
        {
            inputSequence[j] = 0;
        }
        count = 0;

        yield return new WaitForSeconds(0.5f);
        yield return reset = false;
    }
}
