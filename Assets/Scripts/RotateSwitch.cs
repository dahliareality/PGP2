using UnityEngine;
using System.Collections;

public class RotateSwitch : MonoBehaviour {

    public bool activated;
    private Animation anim;

    public bool hasPlayed;
    public AudioClip leverSound;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void Update()
    {
        if (activated)
        {
            playSound();
            anim.Play("LeverDown");
        }
        else
        { 
            anim.Play("LeverUp");
        }
    }

    void playSound()
    {
        if (!hasPlayed)
        {
            this.GetComponent<AudioSource>().PlayOneShot(leverSound, 1.0f);
            hasPlayed = true;
        }
    }
}
