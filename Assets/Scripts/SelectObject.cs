using UnityEngine;
using System.Collections;

public class SelectObject : MonoBehaviour {
    private RaycastHit hit;
    public GameObject grabbedObject = null;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	void FixedUpdate ()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); //casts a a ray from where the player looks.

        //checks if the ray hits another collider.
        if (Physics.Raycast(ray, out hit, 10))
        {
            /*if (hit.collider.gameObject.tag == "moveable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    grabbedObject = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<MoveInteract>().OnInteractEnter();
                }

                if (Input.GetKey(KeyCode.E))// if E is held down
                {
                    if (grabbedObject == null) //safeguard to prevent objects from being picked back up while holding E.
                    {
                        return;
                    }
                    hit.collider.gameObject.GetComponent<MoveInteract>().OnInteractHold();
                }
                else if (Input.GetKeyUp(KeyCode.E) && grabbedObject != null)//if E is released while holding an object
                {
                    grabbedObject.GetComponent<MoveInteract>().OnInteractExit();
                    grabbedObject = null;
                }
            }// end if tag == "moveable"*/

            /*if (hit.collider.gameObject.tag == "rotateable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    grabbedObject = hit.collider.gameObject;
                }

                if (Input.GetKey(KeyCode.E))// if E is held down
                {
                    if (grabbedObject == null) //safeguard to prevent objects from being picked back up while holding E.
                    {
                        return;
                    }
                    hit.collider.gameObject.GetComponent<RotateInteract>().OnInteractHold();
                }
                else if (Input.GetKeyUp(KeyCode.E) && grabbedObject != null) //if E is released while holding an object
                {
                    grabbedObject = null;
                }
            }//end if tag == "turnable"*/
        }

        if (grabbedObject != null)//if ray no longer hits object, drop it.
        {
            if ((hit.collider.gameObject == null || hit.collider.gameObject != grabbedObject) && grabbedObject.tag == "moveable")
            {
                //grabbedObject.GetComponent<MoveInteract>().OnInteractExit();
                grabbedObject = null;
            }
            else if ((hit.collider.gameObject == null || grabbedObject != hit.collider.gameObject) && grabbedObject.tag == "turnable")
            {
                grabbedObject = null;
            }
        }
    }

    public GameObject GetGrabbedObject()
    {
        return grabbedObject;
    }
}