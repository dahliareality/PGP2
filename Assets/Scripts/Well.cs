using UnityEngine;
using System.Collections;

public class Well : MonoBehaviour {

    // Put this script on a well, that will be used to spawn an item

    //public GameObject spawnObject;
    //public Transform spawnPos;
    private bool finished;
    public GameObject basket;

	void Start () {
        //spawnObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
	
	public void SpawnObject()
    {
            /*Instantiate(spawnObject, spawnPos.position, Quaternion.identity);
            hasSpawned = true;
            this.gameObject.name = "totes";*/
            if (!finished)
            {
                basket.GetComponent<Animation>().Play();
                this.GetComponent<Animation>().Play();

                finished = true;
            }
    }
}
