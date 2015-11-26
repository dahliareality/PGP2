using UnityEngine;
using System.Collections;

public class EndFloatingObjects : MonoBehaviour {

    private float speed = 0.009f;

	void Start () {
	
	}

	void FixedUpdate () {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0.0f, 1.0f, 0.0f) * speed;
	}
}
