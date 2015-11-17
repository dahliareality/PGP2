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

	float timer = 0;
	float timeTillEgnition = 0;


    void Start()
    {
        activatedScript = gameObject.GetComponent<Activated>();
        lightLight.enabled = false;
		timeTillEgnition = Random.Range (0,3);
        
    }


    void Update()
    {

        if (activatedScript.activated)
        {
			timer += Time.deltaTime;

			if(timer > timeTillEgnition)
			{
				lightUp();
            	activatedScript.deActivate();
            	playSound();
			}
           
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