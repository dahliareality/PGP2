using UnityEngine;
using System.Collections;

public class LightTrigger : MonoBehaviour {

	public GameObject[] gameobjectsToActivate;

	private bool allowActivationOnce = true;

	void Start () {
	
	}
	

	void Update () {
	
	}


	void OnTriggerEnter(Collider other)
	{

		if(allowActivationOnce && other.gameObject.tag == "Player")
		{

			for(int i = 0; i < gameobjectsToActivate.Length; i++)
				gameobjectsToActivate[i].GetComponent<Interact>().activated = true;

			allowActivationOnce = false;
		}
	}

}
