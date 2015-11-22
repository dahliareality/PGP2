using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour
{
	public Vector2 scrollSpeed = new Vector2(0.1f, 0.1f);
	void Update()
	{
		Material mat = GetComponent<Renderer>().material;
		mat.mainTextureOffset = new Vector2(Time.time * scrollSpeed.x, Time.time * scrollSpeed.y);
	}
}
