using UnityEngine;
using System.Collections;

public class SequencePuzzle : MonoBehaviour
{

    // This is the controller script for the Sequence puzzle.
    // It should be put onto an empty game object. Preferably you should make the interactable buttons, which the other script is attached to, children of this empty object.

    private bool isCorrect;

	private bool gongHasPlayed;
	private bool bellHasPlayed;
	private bool chimesHasPlayed;
    private bool cog1correcet;
    private bool cog2correcet;
    private bool cog3correcet;

    public bool cogSoundPlayed;
    public bool magicSoundStarted;

    private RayCast rc;
    private GameObject button;

    public int count = 0;
    public int countValue
    {
        get { return count; }
        set { count = value; }
    }

    private GameObject gear1, gear2, gear3;
    private GameObject top1, bot1;
    private GameObject top2, bot2;
    private GameObject top3, bot3;

    public GameObject spawnObject;

    void Start()
    {
        spawnObject.SetActive(true);
        rc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCast>();
        rc.SqnPzl = GameObject.Find("Cogwheel Puzzle").GetComponent<SequencePuzzle>();
        GameObject.Find("DragonEye1").GetComponent<Light>().intensity = 0.0f;
        GameObject.Find("DragonEye2").GetComponent<Light>().intensity = 0.0f;

        gear1 = GameObject.Find("Cog 1");
        gear2 = GameObject.Find("Cog 2");
        gear3 = GameObject.Find("Cog 3");
        // 3 points for left lane
        top1 = GameObject.Find("Trigger 1 - Top");
        bot1 = GameObject.Find("Trigger 1 - Bottom");
        // 3 points for mid lane
        top2 = GameObject.Find("Trigger 2 - Top");
        bot2 = GameObject.Find("Trigger 2 - Bottom");
        // 3 points for left lane
        top3 = GameObject.Find("Trigger 3 - Top");
        bot3 = GameObject.Find("Trigger 3 - Bottom");
    }

    void Update()
    {
        //Debug.Log(count);
        if (!isCorrect)
        {
            if (rc.sequenceButton == 1)
            {
                // Moves gear1 up, and gear2 up
                gear1.transform.position = Vector3.Lerp(gear1.transform.position, top1.transform.position, Time.deltaTime * 5);
                gear2.transform.position = Vector3.Lerp(gear2.transform.position, top2.transform.position, Time.deltaTime * 5);
                cog1correcet = false;
                cog2correcet = false;
                if (!cogSoundPlayed)
                {
                    GameObject.Find("Cog1UpSound").GetComponent<SECTR_PointSource>().Play();
                    GameObject.Find("Cog2UpSound").GetComponent<SECTR_PointSource>().Play();
                    cogSoundPlayed = true;
                }

            }
            else if (rc.sequenceButton == 2)
            {
                // Moves gear1 down, and gear3 up
                gear1.transform.position = Vector3.Lerp(gear1.transform.position, bot1.transform.position, Time.deltaTime * 5);
                gear3.transform.position = Vector3.Lerp(gear3.transform.position, top3.transform.position, Time.deltaTime * 5);
                cog1correcet = true;
                cog3correcet = false;
                if (!cogSoundPlayed)
                {
                    GameObject.Find("Cog1DownSound").GetComponent<SECTR_PointSource>().Play();
                    GameObject.Find("Cog3UpSound").GetComponent<SECTR_PointSource>().Play();
                    cogSoundPlayed = true;
                }
            }
            else if (rc.sequenceButton == 3)
            {
                // Moves gear2 down, and gear3 down
                gear2.transform.position = Vector3.Lerp(gear2.transform.position, bot2.transform.position, Time.deltaTime * 5);
                gear3.transform.position = Vector3.Lerp(gear3.transform.position, bot3.transform.position, Time.deltaTime * 5);
                cog2correcet = true;
                cog3correcet = true;
                if (!cogSoundPlayed)
                {
                    GameObject.Find("Cog2DownSound").GetComponent<SECTR_PointSource>().Play();
                    GameObject.Find("Cog3DownSound").GetComponent<SECTR_PointSource>().Play();
                    cogSoundPlayed = true;
                }
            }
            if (cog1correcet && cog2correcet && cog3correcet)
            {
                isCorrect = true;
            }
        }

        if (isCorrect)
        {
            //Debug.Log("Done!");
            spawnObject.SetActive(true);
            GameObject.Find("DragonEye1").GetComponent<Light>().intensity = 1.0f;
            GameObject.Find("DragonEye2").GetComponent<Light>().intensity = 1.0f;
            if (!magicSoundStarted)
            {
                spawnObject.GetComponent<SECTR_PropagationSource>().Play();
                GameObject.Find("Dragonstatue").GetComponent<SECTR_PointSource>().Play();
                magicSoundStarted = true;
            }
        }
    }
}