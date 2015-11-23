using UnityEngine;
using System.Collections;

// ----------------------
// Add to whatever is going to be the Light triggering object
// ----------------------

public class lvl4LightTriggerScript : MonoBehaviour
{

    public bool isLite;
	public bool simulateIsLit = false;
    private bool hasPlayedSound;
    public GameObject movingObj;
    public Transform endPos;
	public Material litMaterial;
	public Material unLitMaterial;



    void Awake()
    {
        movingObj = GameObject.Find("Brigepiece (2)");
    }

    void Update()
    {

		if (simulateIsLit)
			isLite = true;

		if (isLite && GetComponent<Renderer> ().material != litMaterial)
			GetComponent<Renderer> ().material = litMaterial;
		else
		{
			if(GetComponent<Renderer> ().material != unLitMaterial)
			GetComponent<Renderer> ().material = unLitMaterial;
		}

        // placeholder incase of object should react to something.
        if (isLite /*&& inTrigger*/)
        {
            Debug.Log("dong");
            if (movingObj.transform.position.y < 279.67)
            {
                //movingObj.transform.position = new Vector3(movingObj.transform.position.x, movingObj.transform.position.y + 0.04f, movingObj.transform.position.z);
                movingObj.transform.position = Vector3.Lerp(this.movingObj.transform.position, endPos.position, 0.3f * Time.deltaTime);
                if (!hasPlayedSound)
                {
                    movingObj.GetComponent<SECTR_PointSource>().Play();
                    hasPlayedSound = true;
                }
            }
            
        }
        else
        {

        }
		isLite = false;
    }

    public bool IsLite
    {
        get { return isLite; }
        set { isLite = value; }
    }
}
