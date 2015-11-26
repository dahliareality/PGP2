using UnityEngine;
using System.Collections;

//Script used by objects that needs to be rotated by the player.
// for most efficient rotation with PS4 controller, turn off
// MouseLook as normal gameplay camera rotation is done by the
//occulus and not the right analog stick
public class lvl4RotateInteract : MonoBehaviour{

    //private float lookSensitivity = 2f;
    private float currentYRotation;
	private Quaternion endPos;
    //private bool isSoundPlaying = false;
    //private int testInt = 0;
	public GameObject lever;
	public float[] rot = new float[3];
	public bool rotating;
	public float misRot = 0;

	private lv4Switch lv4Switch;

    void Start()
    {
		endPos = Quaternion.Euler (rot [0], rot [1], rot [2]);

		lv4Switch = lever.GetComponent<lv4Switch> ();
    }

    public void FixedUpdate()
    {


		if (lv4Switch.isActive)
		{
			misRot = Mathf.Abs(endPos.y) - Mathf.Abs(transform.rotation.y);

			if(this.transform.rotation != endPos)
			{
				this.transform.rotation = Quaternion.Lerp (this.transform.rotation, endPos, Time.fixedDeltaTime * 0.75f);
				rotating = true;
			}
			if (misRot <  0.0005f)
			{
				lever.GetComponent<lv4Switch>().isActive = false;
				rotating = false;
			}

        }

        // Getting inputs from mouse, and storing the values
        //yRotation += x * lookSensitivity;

        /* xRotation = Mathf.Clamp(xRotation, -90f + startRotation.x, 90f + startRotation.x); // Clamping X
         yRotation = Mathf.Clamp(yRotation, -90f + startRotation.y, 90f + startRotation.y); // Clamping Y*/
    }
}