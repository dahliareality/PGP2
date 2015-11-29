using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
	
	public bool interactableByPlayer = true;
	public bool activated;
	
	
	
	public void interact()
	{
//		Debug.Log ("interacted");
		if (!activated)
			activated = true;
		else
			activated = false;
	}
	
}

