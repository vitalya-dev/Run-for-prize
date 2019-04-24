using System.Collections;
using UnityEngine;

public class HeroChangeDirectionState : HBaseFSM {
	Vector2 new_direction;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);

		Collider2D collisionAhead = personage.collisionAhead;
		if (
			collisionAhead.GetComponent<ArrowAction>().from_direction == Vector2.zero ||
			collisionAhead.GetComponent<ArrowAction>().from_direction == personage.face
		) {
			/* ####################################################################### */
			new_direction = collisionAhead.GetComponent<ArrowAction>().to_direction;
			/* ####################################################################### */
			collisionAhead.GetComponent<ExplodeController>().Explode();
			/* ####################################################################### */
			personage.Move(personage.face, 2);
			/* ####################################################################### */
		} else {
			collisionAhead.GetComponent<ExplodeController>().Explode();
			animator.SetTrigger("Crash");
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);

		if (!personage.moving) {
			personage.face = new_direction;
			animator.SetTrigger("Fly");
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