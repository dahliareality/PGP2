using UnityEngine;
using System.Collections;

//Script used by objects that needs to be rotated by the player.
// for most efficient rotation with PS4 controller, turn off
// MouseLook as normal gameplay camera rotation is done by the
//occulus and not the right analog stick
public class RotateInteract : MonoBehaviour {

    private float lookSensitivity = 2f;
    private float yRotation;
    private float xRotation;
    private float yRotationV;
    private float xRotationV;
    private float lookSmoothDamp = 0.1f;
    private float currentYRotation;
    private float currentXRotation;
	private bool isSoundPlaying = false;
	private int testInt = 0;

    void Awake()
    {
        currentYRotation = transform.rotation.y;
        currentXRotation = transform.rotation.x;

    }

    public void OnInteractHold()
    {
        // Getting inputs from mouse, and storing the values
        yRotation += Input.GetAxis("PS4_DPadHorizontal") * lookSensitivity;

       /* xRotation = Mathf.Clamp(xRotation, -90f + startRotation.x, 90f + startRotation.x); // Clamping X
        yRotation = Mathf.Clamp(yRotation, -90f + startRotation.y, 90f + startRotation.y); // Clamping Y*/

        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

        transform.rotation = Quaternion.Euler(0, -currentYRotation*0.3f, 90);
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