using UnityEngine;
using System.Collections;

public class lv4Switch : MonoBehaviour {

    public bool isActive;
    public AudioClip leverSound;
    private bool hasPlayed = false;
    private Animation anima;

    void Start()
    {
        anima = GetComponent<Animation>();
    }

    void Update () {

        if (isActive)
        {
            playSound();
            anima.Play("LeverDown");
        }
        else
        {
            anima.Play("LeverUp");
        }
    }

    void playSound()
    {
        if (!hasPlayed)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(leverSound, 1.0f);
            hasPlayed = true;
        }
    }
}
