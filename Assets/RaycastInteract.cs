using UnityEngine;
using System.Collections;

public class RaycastInteract : MonoBehaviour {

	
	public float interactDist = 2.5f;
	
	public RaycastHit hit = new RaycastHit();
	
	
	
	void Start () {
		
	}
	
	
	void Update () {
		
		
		Debug.DrawRay (transform.position, transform.forward * interactDist);
		


		if (Input.GetKeyDown(KeyCode.R))
		if (Physics.Raycast (transform.position, transform.forward, out hit, interactDist )) 
		{

//			Debug.Log(hit.collider.gameObject.name);

			if (hit.collider.gameObject.GetComponent<Interact>() != null )  // check if the object has the interact component
			{
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