using UnityEngine;
using System.Collections;

//Script used by objects that needs to be rotated by the player.
// for most efficient rotation with PS4 controller, turn off
// MouseLook as normal gameplay camera rotation is done by the
//occulus and not the right analog stick
public class RotateInteract : MonoBehaviour {

    //private float lookSensitivity = 2f;
    private float yRotation;
    private float xRotation;
    private float yRotationV;
    private float xRotationV;
    private float lookSmoothDamp = 0.1f;
    private float currentYRotation;
	//private bool isSoundPlaying = false;
	//private int testInt = 0;
    public GameObject leftSwitch;
	public GameObject rightSwitch;
	private bool isSoundPlaying = false;

    void Awake()
    {
        currentYRotation = transform.rotation.y;
    }

    public void FixedUpdate()
    {
        float x = 0f;
        if (leftSwitch.GetComponent<RotateSwitch>().activated)
        {
            x = -1;
			if(!isSoundPlaying){
				//this.GetComponent<AudioSource> ().Play ();
				isSoundPlaying = true;
				Debug.Log ("Playing sound");

			}
			Debug.Log ("Turning counter clockwise");
        }
        else if (rightSwitch.GetComponent<RotateSwitch>().activated)
        {
            x = 1;
			if(!isSoundPlaying){
				//this.GetComponent<AudioSource> ().Play ();
				isSoundPlaying = true;
				Debug.Log ("Playing sound");
			}
			Debug.Log ("Turning clockwise");
        }
		/*
		//Stops the sound
		if (leftSwitch.GetComponent<RotateSwitch>().activated==false)
		{
			if(isSoundPlaying){
				this.GetComponent<SECTR_PointSource> ().Stop (true);
				isSoundPlaying = false;
				Debug.Log ("Stopping sound");
			}
			Debug.Log ("Boop!");
		}
		else if (rightSwitch.GetComponent<RotateSwitch>().activated==false)
		{
			if(isSoundPlaying){
				this.GetComponent<SECTR_PointSource> ().Stop (true);
				isSoundPlaying = false;
				Debug.Log ("Stopping sound");
			}
			Debug.Log ("Boop!");
		}*/
        // Getting inputs from mouse, and storing the values
        //yRotation += x * lookSensitivity;
        yRotation += x;

        /* xRotation = Mathf.Clamp(xRotation, -90f + startRotation.x, 90f + startRotation.x); // Clamping X
         yRotation = Mathf.Clamp(yRotation, -90f + startRotation.y, 90f + startRotation.y); // Clamping Y*/

        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

        transform.rotation = Quaternion.Euler(0, currentYRotation * 1.5f, 90);
    }

}