using UnityEngine;
using System.Collections;

// --------------------------
// Attach this script to the switch object
// --------------------------

public class SwitchScript : MonoBehaviour
{
	
	public bool isActive;
	public AudioClip leverSound;
	
	public GameObject[] objectsToActivate;
	
	private bool allowSendActivation = true;
	
	private bool hasPlayed = false;
	private Animation anima;
	private Interact interact;
	
	
	
	
	void Start()
	{
		anima = GetComponent<Animation> ();
		interact = GetComponent <Interact>();
	}
	
	
	
	void Update()
	{
		if (interact.activated && !isActive ) {
			InteractWithObjects ();
			playSound ();
			anima.Play ("LeverDown");
			isActive = true;
			
		}
		else if (!interact.activated && isActive)
		{
			InteractWithObjects ();
			playSound ();
			anima.Play ("LeverUp");
			isActive = false;
			
		}
	}
	
	
	//--------------------------------------------------------
	
	
	void InteractWithObjects()
	{
		//        if (allowSendActivation)
		//        {
		for (int i = 0; i < objectsToActivate.Length; i++)
		{
			if (objectsToActivate[i].GetComponent<Interact>() == true)
				objectsToActivate[i].GetComponent<Interact>().interact();
		}
		//            allowSendActivation = false; // only activate once! (because the activated is a bool)
		//        }
	}
	
	void playSound()
	{
		if (!hasPlayed)
		{
			gameObject.GetComponent<AudioSource>().PlayOneShot(leverSound, 1.0f);
			hasPlayed = true;
		}
	}
}