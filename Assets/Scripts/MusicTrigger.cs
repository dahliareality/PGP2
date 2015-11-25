using UnityEngine;
using System.Collections;

public class MusicTrigger : MonoBehaviour {

	private GameObject music1, music2, music3, music4;
	public int musicNum;
	private bool hasMusic1Played, hasMusic2Played, hasMusic3Played, hasMusic4Played;

	// Use this for initialization
	void Start () {
		music1 = GameObject.Find ("Level1Music");
		music2 = GameObject.Find ("Level2Music");
		music3 = GameObject.Find ("Level3Music");
		music4 = GameObject.Find ("Level4Music");
	}

	void OnTriggerEnter(){
		switch (musicNum) {
		case 1:
			music1.GetComponent<SECTR_PointSource>().Play ();
			hasMusic1Played = true;
			//Debug.Log ("Playing Music for lvl 1");
			break;
		case 2:
			music2.GetComponent<SECTR_PointSource>().Play ();
			hasMusic2Played = true;
			//Debug.Log ("Playing Music for lvl 2");
			break;
		case 3:
			music3.GetComponent<SECTR_PointSource>().Play ();
			hasMusic3Played = true;
			//Debug.Log ("Playing Music for lvl 3");
			break;
		case 4:
			music4.GetComponent<SECTR_PointSource>().Play ();
			hasMusic4Played = true;
			//Debug.Log ("Playing Music for lvl 4");
			break;
		}
	}
}
