using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    // Used to control the time, and tempo parameters in the sudoku game.
    // Use the Unity Editor to change the values
    public bool logCreated;
    public bool startUp;
    public bool logLevel2;
    public bool logLevel3;
    public bool logLevel4;
    private float level1Time;
    private float level2Time;
    private float level3Time;
    private float level4Time;
    private float playedTime;
    private int presenceBroken;
    private string presenceBrokenWhen;
    private string level1CompletionTime;
    private string level2CompletionTime;
    private string level3CompletionTime;
    private string level4CompletionTime;

    void Update()
    {
        if (startUp)
        {
            Debug.Log("Timer started");
            playedTime += Time.deltaTime;
            Level1Timer();

            if (logLevel2)
            {
                Level2Timer();
            }
            else if (logLevel3)
            {
                Level3Timer();
            }
            else if (logLevel4)
            {
                Level4Timer();
            }

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

    public void Level1Timer()
    {
        level1Time += Time.deltaTime;
    }

    public void Level2Timer()
    {
        level2Time += Time.deltaTime;
        level1CompletionTime += "Level 1 completion time: " + level1Time + "\r\n";
    }

    public void Level3Timer()
    {
        level3Time += Time.deltaTime;
        level2CompletionTime += "Level 2 completion time: " + level2Time + "\r\n";
    }

    public void Level4Timer()
    {
        level4Time += Time.deltaTime;
        level3CompletionTime += "Level 3 completion time: " + level3Time + "\r\n";
    }

    // Used to create a log when the game session ends, and then load a new level
    public void createLog()
    {
        level4CompletionTime += "Level 4 completion time: " + level4Time + "\r\n";
        System.IO.Directory.CreateDirectory("C:\\Logs\\");
        System.IO.File.WriteAllText("C:\\Logs\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt",
                                    presenceBrokenWhen + "\r\n"
                                    + level1CompletionTime + level2CompletionTime + level3CompletionTime + level4CompletionTime
                                    + "Total time played: " + playedTime + "\r\n"
                                    + "How many times was presence broken? " + presenceBroken + "\r\n");
        logCreated = true;
    }
}