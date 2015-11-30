using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    // Used to control the time, and tempo parameters in the sudoku game.
    // Use the Unity Editor to change the values
    public bool logCreated;
    public bool startUp;
    private float playedTime;
    private int presenceBroken;
    private string presenceBrokenWhen;

    void Update()
    {
        if (startUp)
        {
            Debug.Log("Timer started");
            playedTime += Time.deltaTime;

            if (Input.GetButton("PS4_PSN"))
            {
                presenceBroken++;
                presenceBrokenWhen += "Presence broken at: " + playedTime + "\r\n";
            }

            if (playedTime >= 1800f)
            {
                createLog();
            }
        }
    }

    // Used to create a log when the game session ends, and then load a new level
    public void createLog()
    {
        System.IO.Directory.CreateDirectory("C:\\Logs\\");
        System.IO.File.WriteAllText("C:\\Logs\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt",
                                    presenceBrokenWhen + "\r\n"
                                    + "Total time played: " + playedTime + "\r\n"
                                    + "How many times was presence broken? " + presenceBroken + "\r\n");
        logCreated = true;
    }
}