using UnityEngine;
using System.Collections;

public class Level2CaveDoor : MonoBehaviour
{

    public GameObject level1Object;
    public GameObject exitObject;
	public int correctStatues = 0;
	public bool puzzleDone = false;

    //private Vector3 slideVector;
    private Vector3 startVector;
    //private bool nowOpen = false;
    //private bool soundHasPlayed = false;
	private int requiredStatues = 4;

    private bool finished;

    void Start()
    {

        //slideVector = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 5f);
        startVector = this.transform.position;
    }


    void Update()
    {
		if (correctStatues == requiredStatues) {

			puzzleDone = true;
			//DestroyObject(gameObject);
			//this.gameObject.transform.position = new Vector3(transform.position.x , transform.position.y-1, transform.position.z);
            if (!finished)
            {
                this.gameObject.GetComponent<Animation>().Play();
                finished = true;
					this.gameObject.GetComponent<SECTR_PointSource>().Play();
            }
		}
			

        if (!level1Object.GetComponent<Pickable>().CanPickUp && !exitObject.GetComponent<ExitPoint>().HasEntered)
        {
            //this.transform.position = Vector3.Lerp(this.transform.position, slideVector, 1.45f * Time.deltaTime);
            //Destroy(gameObject);
            //nowOpen = true;
        }
        //else if (exitObject.GetComponent<ExitPoint>().HasEntered)
        //{
        //    this.transform.position = Vector3.Lerp(this.transform.position, startVector, 1.45f * Time.deltaTime);
        //    //nowOpen = false;
        //}


    }
}
