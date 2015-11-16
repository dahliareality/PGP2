﻿using UnityEngine;
using System.Collections;

public class FireLightAudio : MonoBehaviour {

    public AudioClip fireSound;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.parent.gameObject.GetComponent<Activated>().activated)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void playSound()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(fireSound, 1.0f);
        }
    }
}