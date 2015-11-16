using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour
{


    public SwitchScript switchScript;
    public ParticleSystem flame;
    public ParticleSystem smoke;
    public ParticleSystem embers;
    public Light lightLight;
    public AudioClip flameOn;

    Activated activatedScript;


    void Start()
    {
        activatedScript = gameObject.GetComponent<Activated>();
        lightLight.enabled = false;
        
    }


    void Update()
    {

        if (activatedScript.activated)
        {
            lightUp();
            activatedScript.deActivate();
            playSound();
           
        }


    }


    void lightUp()
    {
        flame.Play();
        smoke.Play();
        embers.Play();
        lightLight.enabled = true;
    }

    void playSound()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(flameOn, 1.0f);
        }
    }

}