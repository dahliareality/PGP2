using UnityEngine;
using System.Collections;
//Attach to target waterfall

public class Waterfall : MonoBehaviour {

        //The speed of the waterfall
        //Can make public if needed to change in the editor
        float scrollSpeed = 0.1f;


    // Use this for initialization
    void Start () {

}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Renderer>().material.shader.isSupported)
        {
            Camera.main.depthTextureMode |= DepthTextureMode.Depth;

            //creates the value of which the total speed of the texture is scrolling
            float offset = Time.time * scrollSpeed;

            //Moves the bumpmap and texture along the vector to make them scroll
            GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", new Vector2(offset / -7.0f, offset));
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2 (offset / 10.0f, offset));
        }

	}
}
