using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour
{
	
	
	//    public SwitchScript switchScript;
	public ParticleSystem flame;
	public ParticleSystem smoke;
	public ParticleSystem embers;
	public Light lightLight;
	public AudioClip flameOn;
	public bool activated = false;
	
	
	Interact interact;
	
	float timer = 0;
	float timeTillEgnition = 0;
	
	
	void Start()
	{
		interact = gameObject.GetComponent<Interact>();
		lightLight.enabled = false;
		timeTillEgnition = Random.Range (0,3);
		
	}
	
	
	void Update()
	{
		
		if (interact.activated && !activated)
		{
			timer += Time.deltaTime;
			
			if(timer > timeTillEgnition)
			{
				lightUp();
				playSound();
				activated = true;
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