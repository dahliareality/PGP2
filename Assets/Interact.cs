using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	public bool activated;



	public void interact()
	{
		if (!activated)
			activated = true;
		else
			activated = false;
	}

}
