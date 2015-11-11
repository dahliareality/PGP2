using UnityEngine;
using System.Collections;

public class Lvl2ChineseGreatdoor : MonoBehaviour {

	private int keyFrags = 0;
	public bool puzzleDone = false; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (keyFrags == 2)
			Destroy (gameObject);
	}

	public void AddKeyFrag(GameObject keyFrag){

		if (keyFrags == 0 && keyFrag.name == "lv2_Key_Fragment02") {
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
