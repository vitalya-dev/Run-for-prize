using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIdleState : HBaseFSM {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);

		animator.SetFloat("Axis", 0.0f);
		animator.SetBool("Rolling", false);
		animator.SetBool("Grounded", p_controller.collisionBelow);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (Input.GetMouseButtonDown(1)) {
			animator.SetBool("Flying", true);
		}
		
		float input = Input.GetAxisRaw("Horizontal");
		if (Mathf.Abs(input) > 0) {
			float axis = Mathf.Sign(input);
			animator.SetFloat("Axis", axis);
			if ((axis > 0 && !p_controller.collisionRight) ||
				(axis < 0 && !p_controller.collisionLeft)) {
				animator.SetBool("Rolling", true);
			}
		}
	}

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
}