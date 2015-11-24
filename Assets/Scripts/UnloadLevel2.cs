using UnityEngine;
using System.Collections;

public class UnloadLevel2 : MonoBehaviour {

    public GameObject lvl2LoadItem;
    public GameObject level;
    public Transform loadSpot;

    private bool hasbeenloaded;

	void Start () {
        if (level.name == "Level 2" || level.name == "Level 3")
        {
            hasbeenloaded = true;
        }
        else
        {
            hasbeenloaded = false;
            Debug.LogWarning("Missing Level");
        }
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && hasbeenloaded)
        {
            if (level.name == "Level2")
            {
                Instantiate(lvl2LoadItem, loadSpot.position, Quaternion.identity);
            }
            Destroy(level);
        }
    }
}
