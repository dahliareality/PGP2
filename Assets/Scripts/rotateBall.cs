using UnityEngine;
using System.Collections;

public class rotateBall : MonoBehaviour {

	public float activationDist = 2f;
	
	RaycastHit hit = new RaycastHit();
	
	public Transform playerCam;

	public float force = 7;
	public float rotSpeed = 5;
	public float damping = 1.02f;


	public Vector3 cToP = new Vector3(0,0,0);
	public Vector3 rotV = new Vector3(0,0,0);



	void Start () {
		
	}
	
	
	void Update () {
		
		
		Debug.DrawRay (transform.position, cToP * activationDist, Color.white);
		Debug.DrawRay (transform.position, rotV * activationDist, Color.red);
		
		
		if (Physics.Raycast ( playerCam.position, playerCam.forward, out hit, activationDist ) && Input.GetKeyDown(KeyCode.Mouse0)) 
		{
			
			if (hit.collider.gameObject.name == gameObject.GetComponent<Collider>().gameObject.name)
			{
				cToP = hit.point - transform.position;
				rotV =  Quaternion.AngleAxis(-90, playerCam.transform.forward) * cToP;
				rotSpeed += force;
			}
		}

		transform.RotateAround(transform.position,rotV, rotSpeed * Time.deltaTime);

		if (rotSpeed > 0)
			rotSpeed /= damping;
		else
			rotSpeed = 0;


	}
}
