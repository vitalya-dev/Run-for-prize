using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HFlyingState : HBaseFSM {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (!p_controller.rolling && p_controller.collisionAhead) {
			switch (p_controller.collisionAhead.tag) {
				case "Solid":
				case "Border":
					animator.SetTrigger("Explode");
					break;
				case "Jump Pack":
					p_controller.face = p_controller.collisionAhead.GetComponent<JumpPackAction>().direction;
					break;
				case "Prize":
					animator.SetTrigger("Prized");
					break;
			}
		} else {
			p_controller.Move(p_controller.face, 2);
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