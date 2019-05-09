using System.Collections;
using UnityEngine;

public class GirlWatchState : StateMachineBehaviour {
	LevelController current_level;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		current_level = FindObjectOfType<GameManager>().current_level;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GirlController girl = animator.GetComponent<GirlController>();
		if (current_level.complete) {
			animator.SetTrigger("Win");
			FindObjectOfType<SoundManager>().PlayClipAt(
				girl.that_was_awesome,
				girl.transform.position,
				0.7f
			);
		}
		if (!animator.GetComponent<GirlController>().piggy.collisionBelow) {
			animator.SetTrigger("Scarry");
			FindObjectOfType<SoundManager>().PlayClipAt(
				girl.scream,
				girl.transform.position,
				0.7f
			);
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