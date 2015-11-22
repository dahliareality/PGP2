using UnityEngine;
using System.Collections;

public class armAnimationController : MonoBehaviour {

	//DOCUMENTATION
	//http://docs.unity3d.com/460/Documentation/Manual/AnimationParameters.html
	//SET THE PARAMETERS TO TRUE IF THE ANIMATION SHOULD PLAY
	
	protected Animator animator;

	public bool readyForGrab = false;
	public bool grab = false;

	
	bool animateOnce = false;
	
	
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(animator)
		{
		
			//AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);


			if(Input.GetKey(KeyCode.T))
				readyForGrab = true;
			else
				readyForGrab = false;
			




			if(readyForGrab) 
			{
				animator.SetBool ("readyForGrab",true);
//				animator.SetBool ("idle",false);
			} else 
			{
				animator.SetBool ("readyForGrab",false);
			}

			
			
		}       
	}  
}
