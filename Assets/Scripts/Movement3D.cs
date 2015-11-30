using UnityEngine;
using System.Collections;

// -----------------------
// Add to the moveable object which is controlled by the player.
// -----------------------

public class Movement3D : MonoBehaviour {

    // Player movement. Attach it to the player object.

//	public Vector3 velocityShow;
//	public float yDifShow;
	private Vector3 oldPos = new Vector3 (0,0,0);

	private float speedOriginal = 5f;
	private float speed = 5f;
	public float sprintMultiplier = 2;
	private float allowedFallSpeed = -0.04f;

	private Rigidbody rb;
	private MouseLook ml;
    private Vector3 moveVector;

    // ---- Start Menu Variables ----
    public float xStartRotation = 275.0f; // Change this Value in the inspector while testing.

    private float requiredTime = 2.0f;
    private float counter = 0.0f;
    private float threshold = 0.7f;
    public bool hasRisen = false; // CHANGE BEFORE EXPORTING FINAL GAME! this is only public because of easy testing other levels.
    private Vector3 startRot;

    // ------------------------------

    void Start () {
        this.gameObject.layer = 2;
        startRot = new Vector3(xStartRotation, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(startRot);
        ml = GameObject.Find("OVRCameraRig").GetComponent<MouseLook>();
		rb = GetComponent<Rigidbody>();
		speed = speedOriginal;
    }

	void Update () {
        counter = Mathf.Clamp(counter, 0.0f, 2.0f);
//		velocityShow = new Vector3 (0,0,0);
//		controlFall ();

		//if (Input.GetKeyDown (KeyCode.Escape))
		//	Application.Quit ();

		controlFall2 ();
		sprintButton ();
        
            //Rotating with the camera
            rb.transform.rotation = Quaternion.Euler(0f, ml.CurrentYRotation, 0f);
            //Walking the direction, of the camera

            moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            rb.transform.Translate(moveVector * speed * Time.deltaTime);

            //--------- START MENU SETTINGS --------
            // Push forward to get up.

//		velocityShow = GetComponent<Rigidbody> ().velocity;
            //-------------------------------------
	}

    public float GetPlayerSpeed()
    {
        return speed;
    }

    public void SetPlayerSpeed(float x)
    {
        speedOriginal = x;
    }

    public bool HasRisen
    {
        get { return hasRisen; }
        set { hasRisen = value; }
    }

	void controlFall()
	{
		if (GetComponent<Rigidbody> ().velocity.y < -1) {
			speed = speedOriginal * 0.5f;
		} 
		else {
			speed = speedOriginal;
		}
	}
	void controlFall2()
	{
		float yDif = transform.position.y - oldPos.y;
//		yDifShow = yDif;

		if (yDif < allowedFallSpeed) {
			speed = speedOriginal * 0.5f;
		} 
		else {
			speed = speedOriginal;
		}

		oldPos = transform.position;
	}
	void sprintButton()
	{
		if (Input.GetKey (KeyCode.Space))
			speed = speedOriginal * sprintMultiplier;



	}

}
