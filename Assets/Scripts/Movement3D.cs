using UnityEngine;
using System.Collections;

// -----------------------
// Add to the moveable object which is controlled by the player.
// -----------------------

public class Movement3D : MonoBehaviour {

    // Player movement. Attach it to the player object.

	private float speed = 5f;

	private GameObject cameraObj;
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
        startRot = new Vector3(xStartRotation, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(startRot);
		ml = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
		rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
        counter = Mathf.Clamp(counter, 0.0f, 2.0f);

        if (hasRisen)
        {
            //Rotating with the camera
            rb.transform.rotation = Quaternion.Euler(0f, ml.CurrentYRotation, 0f);
            //Walking the direction, of the camera

            moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            rb.transform.Translate(moveVector * speed * Time.deltaTime);
        }
            //--------- START MENU SETTINGS --------
            // Push forward to get up.
        else
        {
            if (Input.GetAxis("Vertical") > threshold)
            {
                if (counter < requiredTime)
                {
                    counter += Time.deltaTime;
                    transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f) * (45 * Time.deltaTime));
                }
                else if(counter >= requiredTime)
                {
                    hasRisen = true;
                }
            }
            else if (Input.GetAxis("Vertical") < threshold && counter != 0.0f)
            {
                counter -= Time.deltaTime;
                transform.Rotate(new Vector3(-1.0f, 0.0f, 0.0f) * (45 * Time.deltaTime));
            }
        }
            //-------------------------------------
	}

    public float GetPlayerSpeed()
    {
        return speed;
    }

    public void SetPlayerSpeed(float x)
    {
        speed = x;
    }

    public bool HasRisen
    {
        get { return hasRisen; }
        set { hasRisen = value; }
    }
}
