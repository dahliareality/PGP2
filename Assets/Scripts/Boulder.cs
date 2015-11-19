using UnityEngine;
using System.Collections;

// -----------------------
// Add to a boulder object.
// -----------------------

public class Boulder : MonoBehaviour {

	private bool isIndestructible = true; //Used to set whether or not the boulder can destroy other objects
    private bool reCollide = false;
	public bool getIsIndestructible()
	{
		return isIndestructible;
	}

	public void setIsIndestructible(bool value)
	{
		isIndestructible = value;		
	}

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Rigidbody> ().angularDrag = 0.05f;

	}
	
	// Update is called once per frame
	void Update () {
	
		//Debug.Log (gameObject.GetComponent<Rigidbody> ().velocity.magnitude.ToString());
		if(gameObject.GetComponent<Rigidbody> ().velocity.magnitude < 1) gameObject.GetComponent<Rigidbody> ().angularDrag = 2f;
		else gameObject.GetComponent<Rigidbody> ().angularDrag = 0.05f;

        if (GameObject.Find("lv3_Breakable_Wall_animation").GetComponent<BoulderTrigger>().HasCollided)
        {
            if (reCollide == false)
            {
                GameObject.Find("lv3_Breakable_Wall_animation").GetComponent<Animation>().Play();
                for (int i = 1; i < 251; i++)
                {
                    GameObject.Find("Box006_Part_" + i).GetComponent<Collider>().enabled = false;
                }
                reCollide = true;
            }
        }
        if (reCollide == true)
        {
            if (GameObject.Find("lv3_Breakable_Wall_animation").GetComponent<ExitPoint>().HasEntered)
            {
                for (int i = 1; i < 251; i++)
                {
                    GameObject.Find("Box006_Part_" + i).GetComponent<Collider>().enabled = true;
                }
            }
        }

        if (GameObject.Find("Whatevernameiwillcallit").GetComponent<BoulderTrigger>().HasCollided == true)
        {
            Destroy(this.gameObject);
        }

    }
}
