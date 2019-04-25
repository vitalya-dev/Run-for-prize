using System.Collections;
using UnityEngine;

public class HeroFlyState : HBaseFSM {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateUpdate(animator, stateInfo, layerIndex);

		if (!personage.moving && personage.collisionAhead) {
			Collider2D collisionAhead = personage.collisionAhead;
			switch (collisionAhead.tag) {
				case "Solid":
					animator.SetTrigger("Crash");
					break;
				case "Arrow":
					animator.SetTrigger("Change Direction");
					break;
				case "Prize":
					animator.SetTrigger("Win");
					break;
				case "Roll":
					collisionAhead.GetComponent<ExplodeController>().Explode();
					animator.SetBool("Rolling", true);
					animator.SetFloat("Axis", personage.face.x);
					break;
			}
		} else {
			personage.Move(personage.face, 2);
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