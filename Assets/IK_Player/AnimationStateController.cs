using UnityEngine;
using System.Collections;

public class AnimationStateController : MonoBehaviour {

	//DOCUMENTATION
	//http://docs.unity3d.com/460/Documentation/Manual/AnimationParameters.html
	//SET THE PARAMETERS TO TRUE IF THE ANIMATION SHOULD PLAY

	protected Animator animator;
	public Animation bagAnimation;

	public bool walkForwards;
	public bool walkBackwards;
	public bool idle;
	public bool equippedInventory;

	public bool equipInventory;
	public bool unEquipInventory;

	public bool handOpen;
	public bool handGrab;

	//bool animateOnce = false;


	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(animator)
		{
			//get the current state
			//AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);



			walkForwards = Input.GetKey(KeyCode.W);
			walkBackwards = Input.GetKey(KeyCode.S);

			if (Input.GetAxis("Vertical") > 0.1f)
			{
				walkForwards = true;
				walkBackwards = false;
			}
			else if (Input.GetAxis("Vertical") < -0.1f)
			{
				walkForwards = false;
				walkBackwards = true;
			}

			if(Input.GetButtonDown("PS4_Triangle") || Input.GetKeyDown(KeyCode.I))
			{
				if (!equippedInventory)
				{
					equipInventory = true;
					equippedInventory = true;
//					animateOnce = true;
				}
				else
				{
					unEquipInventory = true;
					equippedInventory = false;
//					animateOnce = true;
				}
			}


			if(walkForwards) 
			{
				animator.SetBool ("walking",true);
				animator.SetBool ("walkingBackwards",false);
				animator.SetBool ("idle",false);
			} else if(walkBackwards)
			{
				animator.SetBool ("walkingBackwards",true);
				animator.SetBool ("walking",false);
				animator.SetBool ("idle",false);
			}
			else {
				animator.SetBool ("walking",false);
				animator.SetBool ("walkingBackwards",false);
				animator.SetBool ("idle",true);
			}
		


			if (equipInventory)
			{
				animator.SetBool ("backpackEquip",true);
				animator.SetBool ("backpackEquipped",true);
				equippedInventory = true;
				bagAnimation["openBag"].speed = 1f;
				bagAnimation.Play();
				//animateOnce = false;
			}
			else
				animator.SetBool ("backpackEquip",false);


			if (unEquipInventory)
			{
				animator.SetBool ("backpackUnequip",true);
				animator.SetBool ("backpackEquipped",false);
				equippedInventory = false;
				bagAnimation["openBag"].time = 1.5f;
				bagAnimation["openBag"].speed = -2f;
				bagAnimation.Play();
			}
			else
				animator.SetBool ("backpackUnequip",false);

			equipInventory = false;
			unEquipInventory = false;

//
//			if (equippedInventory)
//			{
//				animator.SetBool ("backpackEquip",true);
//				animator.SetBool ("backpackUnEquip",false);
//				if(animateOnce)
//				{
//					bagAnimation["openBag"].speed = 1f;
//					bagAnimation.Play();
//					animateOnce = false;
//				}
//			}
//			else
//			{
//				animator.SetBool ("backpackEquip",false);
//				animator.SetBool ("backpackUnEquip",true);
//
//				if(animateOnce)
//				{
//
//					bagAnimation["openBag"].time = 1.5f;
//					bagAnimation["openBag"].speed = -2f;
//					bagAnimation.Play();
//					animateOnce = false;
//				}
//
//			}


			if (handOpen)
			{
				animator.SetBool ("handOpen",true);
				animator.SetBool ("handGrab",false);
			}
			else
				animator.SetBool ("handOpen",false);

			if (handGrab)
			{
				animator.SetBool ("handOpen",false);
				animator.SetBool ("handGrab",true);
			}
			else
				animator.SetBool ("handGrab",false);


		}     
		handOpen = false;
		handGrab = false;
	}        
}

////get the current state
//AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
//
//
////
//walkForwards = Input.GetKey(KeyCode.W);
//walkBackwards = Input.GetKey(KeyCode.S);
//
//if (Input.GetAxis("Vertical") > 0.1f)
//{
//	walkForwards = true;
//	walkBackwards = false;
//}
//else if (Input.GetAxis("Vertical") < -0.1f)
//{
//	walkForwards = false;
//	walkBackwards = true;
//}
//
//if(Input.GetButtonDown("PS4_Triangle") || Input.GetKeyDown(KeyCode.I))
//{
//	if (!equippedInventory)
//	{
//		equippedInventory = true;
//		animateOnce = true;
//	}
//	else
//	{
//		equippedInventory = false;
//		animateOnce = true;
//	}
//}
//
//
//if(walkForwards) 
//{
//	animator.SetBool ("walking",true);
//	animator.SetBool ("idle",false);
//} else if(walkBackwards)
//{
//	animator.SetBool ("walkingBackwards",true);
//	animator.SetBool ("idle",false);
//}
//else {
//	animator.SetBool ("walking",false);
//	animator.SetBool ("walkingBackwards",false);
//	animator.SetBool ("idle",true);
//}
//
//if (equippedInventory)
//{
//	animator.SetBool ("backpackEquip",true);
//	animator.SetBool ("backpackUnEquip",false);
//	if(animateOnce)
//	{
//		bagAnimation["openBag"].speed = 1f;
//		bagAnimation.Play();
//		animateOnce = false;
//	}
//}
//else
//{
//	animator.SetBool ("backpackEquip",false);
//	animator.SetBool ("backpackUnEquip",true);
//	
//	if(animateOnce)
//	{
//		
//		bagAnimation["openBag"].time = 1.5f;
//		bagAnimation["openBag"].speed = -2f;
//		bagAnimation.Play();
//		animateOnce = false;
//	}
//	
//}
//
//
//if (handOpen)
//{
//	animator.SetBool ("handOpen",true);
//	animator.SetBool ("handGrab",false);
//}
//else
//	animator.SetBool ("handOpen",false);
//
//if (handGrab)
//{
//	animator.SetBool ("handOpen",false);
//	animator.SetBool ("handGrab",true);
//}
//else
//	animator.SetBool ("handGrab",false);
//
//
//}     
