using UnityEngine;
using System.Collections;

public class AnimalAI : MonoBehaviour {

	private float distanceToPlayer;
	private Vector3 vectorTowardsPlayer;
	private Vector3 vectorAwayFromPlayer;
	private float moveSpeed;
	private float triggerDist = 3.0f;
	private float scaredTime = 3.0f;

	public bool isScared;
	public bool hasRunAway = true;
	private float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		vectorTowardsPlayer = this.gameObject.transform.position - GameObject.Find ("Player_Character").transform.position;
		distanceToPlayer = vectorTowardsPlayer.magnitude;
		vectorAwayFromPlayer = vectorTowardsPlayer;

		if (distanceToPlayer <= triggerDist && hasRunAway) {
			isScared = true;
		}

		if(isScared){
			timer += Time.deltaTime;
			transform.position += vectorAwayFromPlayer.normalized/30f;
			hasRunAway = false;
			if (timer >= scaredTime){
				hasRunAway = true;
				isScared = false;
				timer = 0f;
			}
		}
	}
}
