    using UnityEngine;
using System.Collections;

//Script used by objects that needs to be rotated by the player.
// for most efficient rotation with PS4 controller, turn off
// MouseLook as normal gameplay camera rotation is done by the
//occulus and not the right analog stick
//add a copy of the rotateInteract part in the raycast script
//in raycast and change rotateInteract of the copy into lvl4rotateInteract
public class lvl4RotateInteract : MonoBehaviour {

    private float lookSensitivity = 0.8f;
    private float yRotation;
    private float xRotation;
	private float zRotation;
    private float yRotationV;
    private float xRotationV;
    private float lookSmoothDamp = 0.1f;
    private float currentYRotation;
	private Vector3 startRot = new Vector3(0,0,0);
	private bool isSoundPlaying = false;
	private int testInt = 0;

    void Start()
    {
		xRotation = transform.localEulerAngles.x;
		yRotation = transform.localEulerAngles.y;
		zRotation = transform.localEulerAngles.z;
		yRotationV = yRotation;
		currentYRotation = yRotation;

//		startRot = Quaternion.Euler(;
//		yRotation = startRot.y;
    }

    public void OnInteractHold()
    {
        // Getting inputs from mouse, and storing the values'
        float x = 0f;
        if (Input.GetAxis("PS4_DPadHorizontal") > 0 || Input.GetAxis("PS4_DPadHorizontal") < 0)
        {
            x = Input.GetAxis("PS4_DPadHorizontal");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -10f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 10f * Time.deltaTime;
        }

        yRotation += x * lookSensitivity;



        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

		transform.localEulerAngles = new Vector3 (xRotation,currentYRotation,zRotation);

//        transform.(xRotation, currentYRotation, zRotation);
		if (!isSoundPlaying && Input.GetAxis("PS4_DPadHorizontal")!=0) {
			this.GetComponent<SECTR_PointSource>().Play();
			isSoundPlaying = true;
			Debug.Log ("Pushing this bitch round mah house "+testInt);
		}
    }

	public void Update(){
		if (Input.GetAxis ("PS4_DPadHorizontal") == 0) {
			//Debug.Log ("My arms are tired "+testInt);
			this.GetComponent<SECTR_PointSource> ().Stop (true);
			isSoundPlaying = false;
		}
	}
}