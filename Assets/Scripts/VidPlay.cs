using UnityEngine;
using System.Collections;

public class VidPlay : MonoBehaviour {
	
	void Update () {
		
		Renderer r = GetComponent<Renderer>();
		MovieTexture movie = (MovieTexture)r.material.mainTexture;
		
		movie.Play();
	}
}