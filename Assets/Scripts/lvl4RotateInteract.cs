using UnityEngine;
using System.Collections;

//Script used by objects that needs to be rotated by the player.
// for most efficient rotation with PS4 controller, turn off
// MouseLook as normal gameplay camera rotation is done by the
//occulus and not the right analog stick
public class lvl4RotateInteract : MonoBehaviour
{

    //private float lookSensitivity = 2f;
    private float currentYRotation;
    //private bool isSoundPlaying = false;
    //private int testInt = 0;
    public GameObject tileSwitch1, tileSwitch2;
    public float xRot;

    void Awake()
    {
        //currentYRotation = transform.rotation.y;
    }

    public void FixedUpdate()
    {
        if (tileSwitch1.GetComponent<lv4Tiles>().activated)
        {
            currentYRotation -= 0.15f;
        }
        else if (tileSwitch2.GetComponent<lv4Tiles>().activated)
        {
            currentYRotation += 0.15f;
        }

        // Getting inputs from mouse, and storing the values
        //yRotation += x * lookSensitivity;

        /* xRotation = Mathf.Clamp(xRotation, -90f + startRotation.x, 90f + startRotation.x); // Clamping X
         yRotation = Mathf.Clamp(yRotation, -90f + startRotation.y, 90f + startRotation.y); // Clamping Y*/

        transform.rotation = Quaternion.Euler(xRot,transform.position.y + currentYRotation, 0.0f);
    }
}