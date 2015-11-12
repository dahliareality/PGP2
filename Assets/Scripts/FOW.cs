using UnityEngine;
using System.Collections;

public class FOW : MonoBehaviour {

    private bool fogDensity;
	// Use this for initialization
	void Start () {
        fogDensity = true;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fog = true;
        RenderSettings.fogColor = Color.yellow;
        RenderSettings.fogStartDistance = 0;
        RenderSettings.fogEndDistance = 400;

        GameObject LoS1 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject LoS2 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject LoS3 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject LoS4 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject LoS5 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        LoS1.GetComponent<Collider>().enabled = false;
        LoS2.GetComponent<Collider>().enabled = false;
        LoS3.GetComponent<Collider>().enabled = false;
        LoS4.GetComponent<Collider>().enabled = false;
        LoS5.GetComponent<Collider>().enabled = false;
        LoS1.transform.localScale = new Vector3(25f, 1f, 25f);
        LoS2.transform.localScale = new Vector3(25f, 1f, 25f);
        LoS3.transform.localScale = new Vector3(25f, 1f, 25f);
        LoS4.transform.localScale = new Vector3(25f, 1f, 25f);
        LoS5.transform.localScale = new Vector3(25f, 1f, 25f);
        LoS1.transform.Rotate(new Vector3(0f, 270f, 90f));
        LoS2.transform.Rotate(new Vector3(0f, 270f, 180f));
        LoS3.transform.Rotate(new Vector3(0f, 270f, -90f));
        LoS4.transform.Rotate(new Vector3(0f, 0f, 90f));
        LoS5.transform.Rotate(new Vector3(0f, 0f, 270f));
        LoS1.transform.parent = GameObject.Find("LoS").transform;
        LoS2.transform.parent = GameObject.Find("LoS").transform;
        LoS3.transform.parent = GameObject.Find("LoS").transform;
        LoS4.transform.parent = GameObject.Find("LoS").transform;
        LoS5.transform.parent = GameObject.Find("LoS").transform;
        LoS1.transform.localPosition = new Vector3(0f, 0f, 75f);
        LoS2.transform.localPosition = new Vector3(-14.7f, 50f, -39.9f);
        LoS3.transform.localPosition = new Vector3(0f, 0f, -75f);
        LoS4.transform.localPosition = new Vector3(75f, 0f, -24f);
        LoS5.transform.localPosition = new Vector3(-75f, 0f, -24f);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.B) == true)
        {   

        }
        if (Input.GetKeyDown(KeyCode.P) == true)
        {
            fogDensity = false;
            RenderSettings.fog = false;
            Destroy(GameObject.Find("LoS"));
        }
        if (fogDensity == false)
        {
            if (RenderSettings.fogEndDistance <= 1000)
            {
                RenderSettings.fogEndDistance += 2;
            }
        }
        else
        {
            if (RenderSettings.fogEndDistance >= 400)
            {
                RenderSettings.fogEndDistance -= 2;
            }
        }
	}
}
