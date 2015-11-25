using UnityEngine;
using System.Collections;

public class InputRound : MonoBehaviour {

	public float LV, LH, RV, RH;

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Debug.Log ("LH: " + Input.GetAxis ("Horizontal"));
		Debug.Log ("LV: " + Input.GetAxis ("Vertical"));
		Debug.Log ("RH: " + Input.GetAxis ("PS4_RightAnalogHorizontal"));
		Debug.Log ("RV: " + Input.GetAxis ("PS4_RightAnalogVertical"));
		*/
		LH = Input.GetAxis ("Horizontal");
		LV = Input.GetAxis ("Vertical");
		RH = Input.GetAxis ("PS4_RightAnalogHorizontal");
		RV = Input.GetAxis ("PS4_RightAnalogVertical");
		if (Input.GetAxis ("Horizontal") < 0.01f && Input.GetAxis ("Horizontal") > -0.01f) {
			LH = 0.0f;
		}
		if (Input.GetAxis ("Vertical") < 0.01f && Input.GetAxis ("Vertical") > -0.01f) {
			LV = 0.0f;
		}
		if (Input.GetAxis ("PS4_RightAnalogHorizontal") < 0.01f && Input.GetAxis ("PS4_RightAnalogHorizontal") > -0.01f) {
			RH = 0.0f;
		}
		if (Input.GetAxis ("PS4_RightAnalogVertical") < 0.01f && Input.GetAxis ("PS4_RightAnalogVertical") > -0.01f) {
			RV = 0.0f;
		}
		//Debug.Log (LV);
		/*

		*/
		//R1
		if (Input.GetKey ("joystick button 4") == true) {
			//Debug.Log ("Click, ho");
			//masterBus.Volume -= 0.1f;
		}
	}
}
