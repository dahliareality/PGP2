using UnityEngine;
using System.Collections;

public class OpenAction2 : MonoBehaviour {

	private Interact interact;
	
	private bool open = false;
	private Animation animationA;


	
	void Start () {

		interact = GetComponent<Interact>();
		animationA = GetComponent<Animation>();
	}
	


	void Update () {

	
		
		if (interact.activated && !open)
		{
			animationA.Play("Open");
			open = true;
		}

		else if (!interact.activated && open)
		{
			animationA.Play("Close");
			open = false;
		}
		

	}
}
