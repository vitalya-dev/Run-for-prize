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
		switch (p_controller.euler_face) {
			case 0:
				if (p_controller.collisionAbove && p_controller.collisionAbove.tag == "Solid")
					animator.SetTrigger("Explode");
				else if (p_controller.collisionAbove && p_controller.collisionAbove.tag == "Jump Pack")
					animator.SetTrigger("Rotate");
				else if (p_controller.collisionAbove && p_controller.collisionAbove.tag == "Prize")
					animator.SetTrigger("Prized");
				break;
			case 90:
				if (p_controller.collisionLeft && p_controller.collisionLeft.tag == "Solid")
					animator.SetTrigger("Explode");
				else if (p_controller.collisionLeft && p_controller.collisionLeft.tag == "Jump Pack")
					animator.SetTrigger("Rotate");
				else if (p_controller.collisionLeft && p_controller.collisionLeft.tag == "Prize")
					animator.SetTrigger("Prized");
				break;
			case 180:
				if (p_controller.collisionBelow && p_controller.collisionBelow.tag == "Solid")
					animator.SetTrigger("Explode");
				else if (p_controller.collisionBelow && p_controller.collisionBelow.tag == "Jump Pack")
					animator.SetTrigger("Rotate");
				else if (p_controller.collisionBelow && p_controller.collisionBelow.tag == "Prize")
					animator.SetTrigger("Prized");
				break;
			case 270:
				if (p_controller.collisionRight && p_controller.collisionRight.tag == "Solid")
					animator.SetTrigger("Explode");
				else if (p_controller.collisionRight && p_controller.collisionRight.tag == "Jump Pack")
					animator.SetTrigger("Rotate");
				else if (p_controller.collisionRight && p_controller.collisionRight.tag == "Prize")
					animator.SetTrigger("Prized");
				break;
		}

		Vector2 velocity = p_controller.velocity;
		velocity.x *= p_controller.face.x;
		velocity.y *= p_controller.face.y;

		p_controller.Move(velocity * 3 * Time.deltaTime);
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