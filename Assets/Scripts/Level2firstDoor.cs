using UnityEngine;
using System.Collections;

public class Level2firstDoor : MonoBehaviour {

	public bool firstStatuePlaced;
	private bool animationStarted;
	private bool soundplayed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor> ().correctStatues == 1) {
			firstStatuePlaced = true;
			if(!animationStarted){
				this.gameObject.GetComponent<Animation>().Play();
				this.gameObject.GetComponent<SECTR_PointSource>().Play ();
				animationStarted = true;
			}

			if(GameObject.Find ("lvl2_Chinese_Gate").GetComponent<Level2CaveDoor> ().correctStatues == 0){
				soundplayed = false;
			}
		}
	}
}
