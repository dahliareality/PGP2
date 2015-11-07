using UnityEngine;
using System.Collections;

// -----------------------
// Add to a boulder object.
// -----------------------

public class Boulder : MonoBehaviour {

	private bool isIndestructible = true; //Used to set whether or not the boulder can destroy other objects

	public bool getIsIndestructible()
	{
		return isIndestructible;
	}

	public void setIsIndestructible(bool value)
	{
		isIndestructible = value;		
	}

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Rigidbody> ().angularDrag = 0.05f;

	}
	
	// Update is called once per frame
	void Update () {
	
		//Debug.Log (gameObject.GetComponent<Rigidbody> ().velocity.magnitude.ToString());
		if(gameObject.GetComponent<Rigidbody> ().velocity.magnitude < 1) gameObject.GetComponent<Rigidbody> ().angularDrag = 2f;
		else gameObject.GetComponent<Rigidbody> ().angularDrag = 0.05f;
	}
}
