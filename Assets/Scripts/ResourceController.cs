using UnityEngine;
using System.Collections;

public class ResourceController : MonoBehaviour {

	GameObject[] allObjects = new GameObject[999];
	private int counter = 5;
    public int threshold = 0;
	public int renderDist = 75;
	public Shader shader;
	public Shader tempShader;


	// Use this for initialization
	void Start () {

		/*allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach (GameObject obj in allObjects)
			if (obj.activeInHierarchy && obj.GetComponent<Renderer> () != null) {
				Renderer rend = obj.GetComponent<Renderer>();
			//rend.enabled = false;
			//rend.receiveShadows = false;
			//rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
//			if(obj.GetComponent<MeshCollider> () != null) Destroy(obj.GetComponent<MeshCollider>());
//			if(obj.GetComponent<BoxCollider> () != null) Destroy(obj.GetComponent<BoxCollider>());
//			if(obj.GetComponent<Animator> () != null) Destroy(obj.GetComponent<Animator>());
			}*/
//
//		allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
//		foreach (GameObject obj in allObjects)
//		{
//			if (obj.activeInHierarchy) {
//				if(Vector3.Distance(this.transform.position,obj.transform.position) > 50)
//				{
//					if(obj.name != "Terrain") obj.SetActive (false);
//				}
//			}
//		}
	
	}
	
	// Update is called once per frame
	void Update () {

	/*	counter++;
		if(counter >= threshold)
		{
		foreach (GameObject obj in allObjects)
			{
				float dist = Vector3.Distance(this.transform.position,obj.transform.position);
			if(dist < renderDist)
			{
			if (obj.activeInHierarchy && obj.GetComponent<Renderer>() != null){
				Renderer rend = obj.GetComponent<Renderer> ();
				rend.enabled = true;
				if(dist < renderDist *0.3)
				{
					rend.receiveShadows = true;
					rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
				}
				}
			} else if (obj.activeInHierarchy && obj.GetComponent<Renderer>() != null)
				{
					Renderer rend = obj.GetComponent<Renderer> ();
					rend.enabled = false;
					rend.receiveShadows = false;
					rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
				}
			}

			counter = 0;
		}*/

//		if(counter >= 300)
//		{
//			foreach (GameObject obj in allObjects)
//			{
//				obj.SetActive(true);
//				if(Vector3.Distance(this.transform.position,obj.transform.position) > 50)
//			{
//					if(obj.name != "Terrain") obj.SetActive(false);
//
//			}
//				
//			}
//			
//			counter = 0;
//		}

	
	}
}
