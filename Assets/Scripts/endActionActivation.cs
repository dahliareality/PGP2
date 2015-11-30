using UnityEngine;
using System.Collections;

public class endActionActivation : MonoBehaviour {

	public bool gravitation = false;

	float speed = 0.015f;

	GameObject player;

	float timer = 0;
	float endTime = 20;

	public int sceneToGoTo = 5;


	void Start () {
		 player = GameObject.FindGameObjectWithTag ("Player");

	}
	

	void Update () {
	


		if (gravitation)
		{
			timer += Time.deltaTime;
			if (timer < 3)
				player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + speed/2, player.transform.position.z);
			else
				player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + speed, player.transform.position.z);

			if (timer > endTime)
				goToNextScene();
		}

	}



	void OnTriggerEnter(Collider other) {
		GameObject.FindGameObjectWithTag ("Animator").GetComponent<Animator> ().SetBool ("ending", true);


		player.GetComponent<Movement3D> ().enabled = false;
		player.GetComponent<Rigidbody> ().useGravity = false;

		gravitation = true;
	
	}

	void goToNextScene()
	{
		Debug.Log ("Next Scene");
        player.GetComponent<Timer>().createLog();
        Application.LoadLevel (sceneToGoTo);
//		AutoFade.LoadLevel(0 ,3,3,Color.white);
	}

}
