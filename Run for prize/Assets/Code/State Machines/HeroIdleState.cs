﻿using System.Collections;
using UnityEngine;

public class HeroIdleState : HBaseFSM {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);

		animator.SetBool("Rolling", false);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateUpdate(animator, stateInfo, layerIndex);
		/* ======================================================= */
		Collider2D collisionBelow = personage.collisionBelow;
		if (collisionBelow) {
			switch (collisionBelow.tag) {
				case "Solid":
					animator.SetBool("Grounded", true);
					break;
				default:
					animator.SetTrigger("Crash");
					break;
			}
		} else {
			animator.SetBool("Grounded", false);
		}
		/* ======================================================= */

		/* ======================================================= */
		Collider2D collisionUnder = personage.collisionUnder;
		if (collisionUnder) {
			switch (collisionUnder.tag) {
				case "Fly":
					personage.face = new Vector2(-1, 0);
					collisionUnder.GetComponent<ExplodeController>().Explode();
					animator.SetTrigger("Fly");
					break;
				case "Arrow":
					ArrowAction arrow = collisionUnder.GetComponent<ArrowAction>();
					if (
						arrow.from_direction != Vector2.zero &&
						arrow.from_direction == personage.axis &&
						arrow.to_direction.y == 0
					) {
						/* ==================================================== */
						personage.axis = arrow.to_direction;
						collisionUnder.GetComponent<ExplodeController>().Explode();
						/* ==================================================== */
					} else if (
						arrow.from_direction == Vector2.zero &&
						arrow.to_direction.y == 0
					) {
						/* ==================================================== */
						personage.axis = arrow.to_direction;
						collisionUnder.GetComponent<ExplodeController>().Explode();
						/* ==================================================== */
					} else {
						/* ==================================================== */
						collisionUnder.GetComponent<ExplodeController>().Explode();
						animator.SetTrigger("Crash");
						/* ==================================================== */
					}
					break;
				case "Prize":
					animator.SetTrigger("Win");
					break;
				default:
					animator.SetTrigger("Crash");
					break;
			}
		} else {
			animator.SetBool("Rolling", true);
		}
		/* ======================================================= */
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateExit(animator, stateInfo, layerIndex);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}