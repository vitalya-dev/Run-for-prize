﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRollingState : HBaseFSM {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);
		float axis = animator.GetFloat("Axis");
		p_controller.Roll(
			p_controller.transform.position + new Vector3(axis, 0, 0),
			Quaternion.LookRotation(p_controller.transform.forward, axis * p_controller.transform.right)
		);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("Rolling", p_controller.rolling);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	// override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	// }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}