using UnityEngine;
using System.Collections;

public class TurnArmControlOnOff : StateMachineBehaviour {




	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	private IKControl ikControl;
//	public bool turnOnOff;

	public float fadeSpeed = 2f;
	public float timeTillFadeDown = 2;

	private float timer = 0;

	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		ikControl = GameObject.FindGameObjectWithTag ("Animator").GetComponent<IKControl> ();
		ikControl.movement = 1;
		timer = 0;
	}

	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		timer += Time.deltaTime;


		if (ikControl.movement > 0 && timer < timeTillFadeDown)
			ikControl.movement -= fadeSpeed*Time.deltaTime;

		if (timer > timeTillFadeDown)
			ikControl.movement += fadeSpeed*Time.deltaTime;

	}
	
	override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		ikControl.movement = 1;
	}

}
