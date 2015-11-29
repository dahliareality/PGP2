using UnityEngine;
using System.Collections;

public class RaycastInteract : MonoBehaviour {
	
	
	public float interactDist = 2.5f;
	
	public RaycastHit hit = new RaycastHit();
	
	
	
	void Start () {
		
	}
	
	
	void Update () {
		
		
		Debug.DrawRay (transform.position, transform.forward * interactDist);
		
		
		
		if (Input.GetButton("PS4_X") || Input.GetKeyDown(KeyCode.E))
			if (Physics.Raycast (transform.position, transform.forward, out hit, interactDist )) 
		{
			GameObject hitObject = hit.collider.gameObject;
			//			Debug.Log(hit.collider.gameObject.name);
			
			if (hitObject.GetComponent<Interact>() != null )  // check if the object has the interact component
			{
				if (hitObject.GetComponent<Interact>().interactableByPlayer)  // check if the player is allowed to interact with object
					hit.collider.gameObject.GetComponent<Interact>().interact();
				//				Debug.Log("Interacted");
			}
			
		}
		
		
		
	}
	
	
	
	
	public GameObject rayTrace()
	{
		if (Physics.Raycast (transform.position, transform.forward, out hit, interactDist )) 
		{
			return hit.collider.gameObject;
		}
		else
			return null;
	}
}