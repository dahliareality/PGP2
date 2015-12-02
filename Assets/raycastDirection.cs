using UnityEngine;
using System.Collections;

public class raycastDirection : MonoBehaviour {

	public float multiplier = 0.25f;

	public Transform parent;

	public float value;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (parent.localEulerAngles.x > 0 && parent.localEulerAngles.x < 90 )
			value = parent.localEulerAngles.x * multiplier;
		else
			value = 0;

		transform.localEulerAngles = new Vector3 (value,0,0);

	}
}
