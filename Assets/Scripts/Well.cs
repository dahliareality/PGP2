using UnityEngine;
using System.Collections;

public class Well : MonoBehaviour {

    // Put this script on a well, that will be used to spawn an item

    //public GameObject spawnObject;
    //public Transform spawnPos;
    private bool hasSpawned = false;
    private bool finished;
    public GameObject basket;

	void Start () {
        GameObject.Find("Lv2_Statue_BlackTurtle").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Lv2_Statue_BlackTurtle").GetComponent<Collider>().enabled = false;
        //spawnObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
	
	public void SpawnObject()
    {

        if (!hasSpawned)
        {
            /*Instantiate(spawnObject, spawnPos.position, Quaternion.identity);
            hasSpawned = true;
            this.gameObject.name = "totes";*/
            GameObject.Find("Lv2_Statue_BlackTurtle").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Lv2_Statue_BlackTurtle").GetComponent<Collider>().enabled = true;
            if (!finished)
            {
                basket.GetComponent<Animation>().Play();
                this.GetComponent<Animation>().Play();

                finished = true;
            }
            
            hasSpawned = true;
        }
    }
}
