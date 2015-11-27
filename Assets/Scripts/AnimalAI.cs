using UnityEngine;
using System.Collections;

public class AnimalAI : MonoBehaviour {
	
	private float distanceToPlayer;
	private Vector3 vectorTowardsPlayer;
	private Vector3 vectorAwayFromPlayer;
	//private float moveSpeed = 15;
	//private float maxSpeed = 2;
	private float triggerDist = 3.0f;
	private float scaredTime = 3.0f;
	
	public bool isScared;
	public bool hasRunAway = true;
	private float timer;
	
	//private Rigidbody rigidbodyR;
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		//rigidbodyR = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		vectorTowardsPlayer = this.gameObject.transform.position - GameObject.FindWithTag ("Player").transform.position;
		distanceToPlayer = vectorTowardsPlayer.magnitude;
		vectorAwayFromPlayer = vectorTowardsPlayer;
		
		if (distanceToPlayer <= triggerDist && hasRunAway) {
			isScared = true;
		}
		
		
		if(isScared){
			
			animator.SetBool("fleeing",true);
			
			timer += Time.deltaTime;
			
			hasRunAway = false;
			
			if (timer >= scaredTime)
			{
				hasRunAway = true;
				isScared = false;
				timer = 0f;
			}
			
			vectorAwayFromPlayer.Normalize();
			
			Vector3 directionToGo = new Vector3(vectorAwayFromPlayer.x, 0, vectorAwayFromPlayer.z);
			
			transform.right  = Vector3.Lerp(transform.right, directionToGo, 0.1f);
			transform.position += new Vector3(vectorAwayFromPlayer.x, 0, vectorAwayFromPlayer.z)/30f;
			//			rigidbodyR.AddForce(new Vector3(vectorAwayFromPlayer.x, 0, vectorAwayFromPlayer.z)*moveSpeed);
		}
		else
			animator.SetBool("fleeing",false);
		
		
		if (transform.eulerAngles.x != 0)
			transform.eulerAngles = new Vector3 (0,transform.localEulerAngles.y,0);
		
		if (transform.eulerAngles.z != 0)
			transform.eulerAngles = new Vector3 (0,transform.localEulerAngles.y,0);
		
	}
}