using UnityEngine;
using System.Collections;

public class DemoCamera : MonoBehaviour {

	Vector3 mouseStartPosition;

	// Use this for initialization
	void Start () {
		mouseStartPosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("QE_UpDown"), Input.GetAxis("Vertical")) * Time.deltaTime * 5);

		transform.rotation = Quaternion.LookRotation(
			Quaternion.Euler(
					Mathf.Clamp(-Input.mousePosition.y + mouseStartPosition.y, -85f, 85f),
					Input.mousePosition.x - mouseStartPosition.x,
					0
				) * Vector3.forward);
	}
}
