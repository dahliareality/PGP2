using UnityEngine;
using System.Collections;

public class AnimationStateController : MonoBehaviour {

	//DOCUMENTATION
	//http://docs.unity3d.com/460/Documentation/Manual/AnimationParameters.html
	//SET THE PARAMETERS TO TRUE IF THE ANIMATION SHOULD PLAY

	protected Animator animator;
	public Animation bagAnimation;
	public float DirectionDampTime = .25f;

	public bool walkForwards;
	public bool walkBackwards;
	public bool idle;
	public bool equippedInventory;

	bool animateOnce = false;


	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(animator)
		{
			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			
			//if we're in "Run" mode, respond to input for jump, and set the Jump parameter accordingly. 
			/*if(stateInfo.nameHash == Animator.StringToHash("Base Layer.RunBT"))
			{
				if(Input.GetButton("Fire1")) 
					animator.SetBool("Jump", true );
			}
			else
			{
				animator.SetBool("Jump", false);                
			}*/

			walkForwards = Input.GetKey(KeyCode.W);
			walkBackwards = Input.GetKey(KeyCode.S);

			if(Input.GetKeyDown(KeyCode.I))
			{
				if (!equippedInventory)
				{
					equippedInventory = true;
					animateOnce = true;
				}
				else
				{
					equippedInventory = false;
					animateOnce = true;
				}
			}


			if(walkForwards) 
			{
				animator.SetBool ("walking",true);
				animator.SetBool ("idle",false);
			} else if(walkBackwards)
			{
				animator.SetBool ("walkingBackwards",true);
				animator.SetBool ("idle",false);
			}
			else {
				animator.SetBool ("walking",false);
				animator.SetBool ("walkingBackwards",false);
				animator.SetBool ("idle",true);
			}
		
			if (equippedInventory && animateOnce)
			{
				animator.SetBool ("backpackEquip",true);
				bagAnimation["openBag"].speed = 1f;
				bagAnimation.Play();
				animateOnce = false;
			}
			else
			{
				if(animateOnce)
				{
					animator.SetBool ("backpackEquip",false);
					bagAnimation["openBag"].speed = -1f;
					bagAnimation.Play();
					animateOnce = false;
				}

			}

			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");
			
			//set event parameters based on user input
			animator.SetFloat("Speed", h*h+v*v);
			animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}       
	}        
}
