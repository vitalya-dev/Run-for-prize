using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HFallingState : HBaseFSM {
	private Vector3 finalDestination;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);

		finalDestination = p_controller.transform.position + new Vector3(0, -1, 0);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Vector2 velocity = p_controller.velocity;
		velocity.x = 0;
		float distance = Vector3.Distance(p_controller.transform.position, finalDestination);
		if (distance > 0.1 && distance < 1) {
			p_controller.Move(velocity * -1 * Time.deltaTime);
		} else {
			p_controller.transform.position = finalDestination;
			animator.SetBool("Grounded", true);
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