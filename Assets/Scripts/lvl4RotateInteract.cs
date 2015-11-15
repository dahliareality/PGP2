using UnityEngine;
using System.Collections;

//Script used by objects that needs to be rotated by the player.
// for most efficient rotation with PS4 controller, turn off
// MouseLook as normal gameplay camera rotation is done by the
//occulus and not the right analog stick
//add a copy of the rotateInteract part in the raycast script
//in raycast and change rotateInteract of the copy into lvl4rotateInteract
public class lvl4RotateInteract : MonoBehaviour {

    private float lookSensitivity = 1.2f;
    private float yRotation;
    private float xRotation;
    private float yRotationV;
    private float xRotationV;
    private float lookSmoothDamp = 0.1f;
    private float currentYRotation;
    public float startxRot;

    void Start()
    {
        currentYRotation = transform.rotation.y;
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
            x = -.15f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            x = .15f;
        }

        yRotation += x * lookSensitivity;

       /* xRotation = Mathf.Clamp(xRotation, -90f + startRotation.x, 90f + startRotation.x); // Clamping X
        yRotation = Mathf.Clamp(yRotation, -90f + startRotation.y, 90f + startRotation.y); // Clamping Y*/
        

        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

        transform.rotation = Quaternion.Euler(startxRot, currentYRotation, 0f);
		//(play sound) 
		//this.gameObject.getComponent<SECTR_PointSource>().Play();
    }
}