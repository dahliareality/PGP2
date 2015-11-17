using UnityEngine;
using System.Collections;

public class Lvl2ChineseGreatdoor : MonoBehaviour {

	private int keyFrags = 0;
	public bool puzzleDone = false;
    private bool finished;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (keyFrags == 2)
        {
            //Destroy (gameObject);
            GameObject.Find("lvl2_Chinese_Greatdoor_(Optional)").GetComponent<Collider>().enabled = false;
            
            /*if (!finished)
            {
                this.gameObject.GetComponent<Animation>().Play();
                finished = true;
            }*/
        }	
	}

	public void AddKeyFrag(GameObject keyFrag){

		if (keyFrags == 0 && keyFrag.name == "Key Fragment 2") {
			GameObject arm = GameObject.FindGameObjectWithTag ("Arm");
			arm.GetComponent<ArmsScript>().RemoveItem(keyFrag);
			Destroy(keyFrag);
			keyFrags++;
		} else if (keyFrags == 1 && keyFrag.name == "Key Fragment 3") {
			keyFrags++;
			GameObject arm = GameObject.FindGameObjectWithTag ("Arm");
			arm.GetComponent<ArmsScript>().RemoveItem(keyFrag);
			Destroy(keyFrag);
			Destroy(keyFrag);
		}
	}
}
