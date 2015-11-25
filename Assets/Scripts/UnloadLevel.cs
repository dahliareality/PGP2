using UnityEngine;
using System.Collections;

public class UnloadLevel : MonoBehaviour {

    public GameObject lvlLoadItem;
    private GameObject level;

    void Awake()
    {
        lvlLoadItem.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (GameObject.Find("EntireLevel3"))
            {
                level = GameObject.Find("EntireLevel3");
            }
            else if (GameObject.Find("Level 2"))
            {
                level = GameObject.Find("Level 2");
            }

            //Debug.Log(level.name);
            lvlLoadItem.SetActive(true);
            Destroy(level);
            Destroy(this);
        }
    }
}
