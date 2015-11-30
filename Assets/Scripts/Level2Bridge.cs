using UnityEngine;
using System.Collections;

public class Level2Bridge : MonoBehaviour
{
    // Put this on the part of the bridge that should lift up on puzzle completion

    public int correctStatues = 0;
    public bool puzzleDone = false;

    //private Vector3 startVector;
    private bool nowOpen = false;
    private bool soundHasPlayed = false;
    private int requiredStatues = 3;

    public GameObject endItem;
    public GameObject Bridge1;
    public GameObject invisWall;
    private GameObject parenting;
    private bool finished;

    void Start()
    {
        if(endItem.GetComponent<Pickable>() == null)
        {
            //Debug.Log("Wrong Object, or this object needs a pickable script");
        }
        parenting = GameObject.Find("Lv2_Nabatean_Sunstone_Circle_Engraving_Floor");
      /*  slideVector = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 5f);
        startVector = this.transform.position;*/
		invisWall = GameObject.Find ("BridgeBlock");
    }


    void Update()
    {
        if (endItem.transform.parent != parenting && !endItem.GetComponent<Pickable>().CanPickUp)
        {
            puzzleDone = true;
            //DestroyObject(gameObject);
            //this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            if (!finished)
            {
                Bridge1.GetComponent<Animation>().Play();
                finished = true;
                nowOpen = false;
            }
            if (finished)
            {
                Destroy(invisWall);
                nowOpen = true;
            }
			//this.gameObject.GetComponent<SECTR_PointSource>().Play();
        }

        if (nowOpen && !soundHasPlayed)
        {
            this.GetComponent<SECTR_PropagationSource>().Play();
            soundHasPlayed = true;
        }
    }
}
