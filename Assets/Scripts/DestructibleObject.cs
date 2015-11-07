using UnityEngine;
using System.Collections;

// -----------------------
// Add to objects which should be destructable from the boulder.
// -----------------------

public class DestructibleObject : MonoBehaviour {

	public int velocityThreshold = 3;

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "boulderTag") 
		{
			Boulder boulderInst = col.gameObject.GetComponent<Boulder> ();
			if(boulderInst.getIsIndestructible () && Mathf.Abs(col.relativeVelocity.x) > velocityThreshold)
				Destroy(this.gameObject);
		}

	}
}
