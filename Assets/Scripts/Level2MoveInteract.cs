using UnityEngine;
using System.Collections;

//Script used by objects that needs to be pushed and or pulled by the player.

public class Level2MoveInteract : MonoBehaviour {
    private GameObject player;

    public float force = 795;
    private float slow = 1.4f;
    private float normalSpeed = 5.0f;

    private Vector3 heading;
    private float distance;
    private Vector3 direction;
    private Rigidbody rb;

    public GameObject[] toTrigger;
    public bool canMove;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        canMove = true;
    }

    // when interaction starts.
    public void OnInteractEnter()
    {
        //generate normal vector between object and player.
        DetermenDirection();
    }

    //while interaction is held.
    public void OnInteractHold()
    {
        rb.isKinematic = false;
        player.GetComponent<Movement3D>().SetPlayerSpeed(slow);

        //generate normal vector between object and player.
        DetermenDirection();

        rb.AddForce(new Vector3(Input.GetAxis("Vertical") * -direction.x, 0f, Input.GetAxis("Vertical") * -direction.z) * force * Time.deltaTime);
            
        DiagonalMoveClamp();
        CardianlMoveClamp();
	    //this.GetComponent<SECTR_PointSource>().Play();
    }

    //When interaction ends.
    public void OnInteractExit()
    {
        rb.isKinematic = true;
        player.GetComponent<Movement3D>().SetPlayerSpeed(normalSpeed);
        transform.parent = null;
    }

    //Limits the diagonal velocity of the object
    private void DiagonalMoveClamp()
    {
        if (rb.velocity.x > 1.0f && rb.velocity.z > 1.0f)
        {
            rb.velocity = new Vector3(0.7f, rb.velocity.y, 0.7f);
        }
        else if (rb.velocity.x > 1.0f && rb.velocity.z < -1.0f)
        {
            rb.velocity = new Vector3(0.7f, rb.velocity.y, -0.7f);
        }
        else if (rb.velocity.x < -1.0f && rb.velocity.z > 1.0f)
        {
            rb.velocity = new Vector3(-0.7f, rb.velocity.y, 0.7f);
        }
        else if (rb.velocity.x < -1.0f && rb.velocity.z < -1.0f)
        {
            rb.velocity = new Vector3(-0.7f, rb.velocity.y, -0.7f);
        }
    }

    //Limits the cardinal velocity for the object
    private void CardianlMoveClamp()
    {
        if (rb.velocity.x > 1.4f)
        {
            rb.velocity = new Vector3(1.4f, rb.velocity.y, rb.velocity.z);
        }
        else if (rb.velocity.x < -1.4f)
        {
            rb.velocity = new Vector3(-1.4f, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.z > 1.4f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 1.4f);
        }
        else if (rb.velocity.z < -1.4f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -1.4f);
        }
    }

    private void DetermenDirection()
    {
        //generates normal vector between object and player.
        heading = player.transform.position - transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
    }
}
