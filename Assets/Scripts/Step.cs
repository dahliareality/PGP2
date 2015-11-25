using UnityEngine;
using System.Collections;

public class Step : MonoBehaviour {
	/* R= Rock
	 * M= Moss
	 * A= Sand on rock
	 * S= Sand
	 * P= Puddle
	 * K= Water (Knee-high)
	 * W= Wood
	*/
	private RaycastHit hit = new RaycastHit();
	private bool isWalking;
	private bool isRPlaying, isMPlaying, isAPlaying, isSPlaying, isPPlaying, isKPlaying, isWPlaying, isAnythingPlaying;
	/*
	private GameObject R1, R2, R3, R4, R5, R6, R7, R8;
	private GameObject M1, M2, M3, M4, M5, M6, M7, M8;
	private GameObject A1, A2, A3, A4, A5, A6, A7, A8;
	private GameObject S1, S2, S3, S4, S5, S6, S7, S8;
	private GameObject P1, P2, P3, P4, P5, P6, P7, P8;
	private GameObject K1, K2, K3, K4, K5, K6, K7, K8;
	private GameObject W1, W2, W3, W4, W5, W6, W7, W8;
	*/
	private InputRound god;
	private GameObject[] RData, MData, AData, SData, PData, KData, WData;
	private int d8, d8old;
	public Texture2D kenny;

	void Start () {
		god = GameObject.Find ("InputRound").GetComponent<InputRound> ();
		RData = new GameObject[8];
		MData = new GameObject[8];
		AData = new GameObject[8];
		SData = new GameObject[8];
		PData = new GameObject[8];
		KData = new GameObject[1];
		WData = new GameObject[8];
		//Rock
		RData[0] = GameObject.Find ("R1");
		RData[1] = GameObject.Find ("R2");
		RData[2] = GameObject.Find ("R3");
		RData[3] = GameObject.Find ("R4");
		RData[4] = GameObject.Find ("R5");
		RData[5] = GameObject.Find ("R6");
		RData[6] = GameObject.Find ("R7");
		RData[7] = GameObject.Find ("R8");
		//Moss
		MData[0] = GameObject.Find ("M1");
		MData[1] = GameObject.Find ("M2");
		MData[2] = GameObject.Find ("M3");
		MData[3] = GameObject.Find ("M4");
		MData[4] = GameObject.Find ("M5");
		MData[5] = GameObject.Find ("M6");
		MData[6] = GameObject.Find ("M7");
		MData[7] = GameObject.Find ("M8");
		//Sand on Rock
		AData[0] = GameObject.Find ("A1");
		AData[1] = GameObject.Find ("A2");
		AData[2] = GameObject.Find ("A3");
		AData[3] = GameObject.Find ("A4");
		AData[4] = GameObject.Find ("A5");
		AData[5] = GameObject.Find ("A6");
		AData[6] = GameObject.Find ("A7");
		AData[7] = GameObject.Find ("A8");
		//Sand
		SData[0] = GameObject.Find ("S1");
		SData[1] = GameObject.Find ("S2");
		SData[2] = GameObject.Find ("S3");
		SData[3] = GameObject.Find ("S4");
		SData[4] = GameObject.Find ("S5");
		SData[5] = GameObject.Find ("S6");
		SData[6] = GameObject.Find ("S7");
		SData[7] = GameObject.Find ("S8");
		//Puddle
		PData[0] = GameObject.Find ("P1");
		PData[1] = GameObject.Find ("P2");
		PData[2] = GameObject.Find ("P3");
		PData[3] = GameObject.Find ("P4");
		PData[4] = GameObject.Find ("P5");
		PData[5] = GameObject.Find ("P6");
		PData[6] = GameObject.Find ("P7");
		PData[7] = GameObject.Find ("P8");
		//Water
		KData[0] = GameObject.Find ("K1");
		//Wood
		WData[0] = GameObject.Find ("W1");
		WData[1] = GameObject.Find ("W2");
		WData[2] = GameObject.Find ("W3");
		WData[3] = GameObject.Find ("W4");
		WData[4] = GameObject.Find ("W5");
		WData[5] = GameObject.Find ("W6");
		WData[6] = GameObject.Find ("W7");
		WData[7] = GameObject.Find ("W8");

	}
    void OnGUI(){
        if (isAnythingPlaying) {
            //GUI.DrawTexture (new Rect(0,0, Screen.width/10, Screen.height/10), kenny);
        }
    }
	void Update () {
		//Debug.Log (isAnythingPlaying);
		//Checks if player is walking
		if (god.LH != 0.0f || god.LV != 0.0f) {
			//Debug.Log ("Walking, bitch");
			isWalking = true;
			d8old = d8;
			while(d8==d8old){
				d8=Random.Range(0, 7);
			}
			//Debug.Log (d8);
		} else {
			//Debug.Log("Standing still dude");
			isWalking = false;
		}
		isRPlaying = false;
		isMPlaying = false;
		isAPlaying = false;
		isSPlaying = false;
		isPPlaying = false;
		isKPlaying = false;
		isWPlaying = false;
		//Checks if there is a surface beneath the player
		if (isWalking == true && Physics.Raycast (transform.position, -Vector3.up, out hit, 3)) {
			//Debug.Log ("There is a floor beneath me");
			if(/*hit.collider.gameObject.tag == "Puddle Floor" && */isAnythingPlaying == false){
				//Stops all sounds, plays a footstep, then starts playing a new footstep every .5 sec
				switch(hit.collider.gameObject.tag){
				case "Stone Floor":
					isRPlaying = true;
					ShutUp();
					RData[d8].GetComponent<AudioSource>().Play ();
					RData[d8].GetComponent<AudioSource>().volume=1;
					StartCoroutine(RPlayer());
					break;
				case "Moss Floor":
					isMPlaying = true;
					ShutUp();
					MData[d8].GetComponent<AudioSource>().Play ();
					MData[d8].GetComponent<AudioSource>().volume=1;
					StartCoroutine(MPlayer());
					break;
				case "Sand on Stone Floor":
					isAPlaying = true;
					ShutUp();
					AData[d8].GetComponent<AudioSource>().Play ();
					AData[d8].GetComponent<AudioSource>().volume=1;
					StartCoroutine(APlayer());
					break;
				case "Sand Floor":
					isSPlaying = true;
					//ShutUp();
					SData[d8].GetComponent<AudioSource>().Play ();
					//SData[d8].GetComponent<AudioSource>().volume=1;
					StartCoroutine(SPlayer());
					break;
				case "Puddle Floor":
					isPPlaying = true;
					ShutUp();
					PData[d8].GetComponent<AudioSource>().Play ();
					PData[d8].GetComponent<AudioSource>().volume=1;
					StartCoroutine(PPlayer());
					break;
				case "Water Floor":
					isKPlaying = true;
					ShutUp();
					KData[d8].GetComponent<AudioSource>().Play ();
					KData[d8].GetComponent<AudioSource>().volume=1;
					StartCoroutine(KPlayer());
					break;
				case "Wooden Floor":
					isWPlaying = true;
					ShutUp();
					WData[d8].GetComponent<AudioSource>().Play ();
					WData[d8].GetComponent<AudioSource>().volume=1;
					StartCoroutine(WPlayer());
					break;
				case "Room1Tablet":
					ShutUp();
					StartCoroutine(WPlayer());
					break;
				default:
					StartCoroutine(NPlayer());
					break;
				}
				isAnythingPlaying=true;
				//Debug.Log ("Walking in a puddle");
				//Debug.Log (d8);

			}
		}
	}
	//Plays a footstep after a .5 sec wait
	private IEnumerator RPlayer(){
		yield return new WaitForSeconds (0.5f);
		if (isRPlaying) {
			RData[d8].GetComponent<AudioSource>().Play ();
		}
		isRPlaying = false;
		isAnythingPlaying = false;
	}
	private IEnumerator MPlayer(){
		yield return new WaitForSeconds (0.5f);
		if (isMPlaying) {
			MData[d8].GetComponent<AudioSource>().Play ();
		}
		isMPlaying = false;
		isAnythingPlaying = false;
	}
	private IEnumerator APlayer(){
		yield return new WaitForSeconds (0.5f);
		if (isAPlaying) {
			AData[d8].GetComponent<AudioSource>().Play ();
		}
		isAPlaying = false;
		isAnythingPlaying = false;
	}
	private IEnumerator SPlayer(){
		yield return new WaitForSeconds (0.5f);
		if (isSPlaying) {
			SData[d8].GetComponent<AudioSource>().Play ();
		}
		isSPlaying = false;
		isAnythingPlaying = false;
	}
	private IEnumerator PPlayer(){
		yield return new WaitForSeconds (0.5f);
		if (isPPlaying) {
			PData[d8].GetComponent<AudioSource>().Play ();
		}
		isPPlaying = false;
		isAnythingPlaying = false;
	}
	private IEnumerator KPlayer(){
		yield return new WaitForSeconds (0.5f);
		if (isKPlaying) {
			KData[d8].GetComponent<AudioSource>().Play ();
		}
		isKPlaying = false;
		isAnythingPlaying = false;
	}
	private IEnumerator WPlayer(){
		yield return new WaitForSeconds (0.5f);
		if (isWPlaying) {
			WData [d8].GetComponent<AudioSource> ().Play ();
		}
		isWPlaying = false;
		isAnythingPlaying = false;
	}
	private IEnumerator NPlayer(){
		yield return new WaitForSeconds (0.5f);

		isAnythingPlaying = false;
	}
	//Stops all sounds
	void ShutUp(){
		/*
		for(int i=0; i<RData.Length; i++){
			RData[i].GetComponent<AudioSource>().volume-=0.4f;
		}
		for(int i=0; i<MData.Length; i++){
			MData[i].GetComponent<AudioSource>().volume-=0.4f;
		}
		for(int i=0; i<PData.Length; i++){
			PData[i].GetComponent<AudioSource>().volume-=0.4f;
		}
		for(int i=0; i<WData.Length; i++){
			WData[i].GetComponent<AudioSource>().volume-=0.4f;
		}*/
	}

}
