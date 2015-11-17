using UnityEngine;
using System.Collections;

public class SequencePuzzle : MonoBehaviour
{

    // This is the controller script for the Sequence puzzle.
    // It should be put onto an empty game object. Preferably you should make the interactable buttons, which the other script is attached to, children of this empty object.

    private bool isCorrect;

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

    void Start()
    {
        rc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCast>();
        rc.SqnPzl = GameObject.Find("Cogwheel Puzzle").GetComponent<SequencePuzzle>();

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
        Debug.Log(count);

        if (rc.sequenceButton == 1)
        {
            // Moves gear1 up, and gear2 up
            //gear1.transform.position = Vector3.Lerp(gear1.transform.position, top1.transform.position, Time.deltaTime * 5);
            //gear2.transform.position = Vector3.Lerp(gear2.transform.position, top2.transform.position, Time.deltaTime * 5);
			gear1.transform.position = Vector3.Lerp(gear1.transform.position, bot1.transform.position, Time.deltaTime * 5);
            GameObject.Find("Chinese Gong").GetComponent<SECTR_PointSource>().Play();


        }
        else if (rc.sequenceButton == 2)
        {
            // Moves gear1 down, and gear3 up
            //gear1.transform.position = Vector3.Lerp(gear1.transform.position, bot1.transform.position, Time.deltaTime * 5);
            //gear3.transform.position = Vector3.Lerp(gear3.transform.position, top3.transform.position, Time.deltaTime * 5);

            gear2.transform.position = Vector3.Lerp(gear2.transform.position, bot2.transform.position, Time.deltaTime * 5);
			GameObject.Find("Chinese Bell").GetComponent<SECTR_PointSource>().Play();

        }
        else if (rc.sequenceButton == 3)
        {
            // Moves gear2 down, and gear3 down
            //gear2.transform.position = Vector3.Lerp(gear2.transform.position, bot2.transform.position, Time.deltaTime * 5);
            //gear3.transform.position = Vector3.Lerp(gear3.transform.position, bot3.transform.position, Time.deltaTime * 5);

            gear3.transform.position = Vector3.Lerp(gear3.transform.position, bot3.transform.position, Time.deltaTime * 5);
			GameObject.Find("Chinese Windchime").GetComponent<SECTR_PointSource>().Play();

        }

        if (count == 3)
        {
            Destroy(gameObject);
        }
    }
}