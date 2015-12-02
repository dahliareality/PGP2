using UnityEngine;
using System.Collections;

public class showRotDebug : MonoBehaviour {

	public Vector3 globalRot;
	public Vector3 localRot;
	public Vector3 globalEulerAngles;
	public Vector3 localEulerAngles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
//		globalRot = transform.rotation;
//		localRot = transform.localRotation;
		globalEulerAngles = transform.eulerAngles;
		localEulerAngles = transform.localEulerAngles;

	}
}
