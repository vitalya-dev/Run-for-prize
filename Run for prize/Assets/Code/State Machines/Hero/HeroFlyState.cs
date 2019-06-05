using System.Collections;
using UnityEngine;

public class HeroFlyState : HBaseFSM {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);
		personage.fly_callback.Invoke();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateUpdate(animator, stateInfo, layerIndex);

		if (!personage.moving && personage.collisionUnder) {
			Collider2D collisionUnder = personage.collisionUnder;
			switch (collisionUnder.tag) {
				case "Solid":
				case "Wall":
					animator.SetTrigger("Crash");
					break;
				case "Arrow":
					ArrowAction arrow = collisionUnder.GetComponent<ArrowAction>();
					if (
						arrow.from_direction != Vector2.zero &&
						arrow.from_direction == personage.axis
					) {
						personage.face = arrow.to_direction;
					}
					if (arrow.from_direction == Vector2.zero)personage.face = arrow.to_direction;
					arrow.GetComponent<ExplodeController>().Explode();
					break;
				case "Prize":
					animator.SetTrigger("Win");
					break;
				case "Rotate":
					RotateAction rotate = collisionUnder.GetComponent<RotateAction>();
					GameObject.FindObjectOfType<GameManager>().LevelRotate();
					rotate.GetComponent<ExplodeController>().Explode();
					animator.SetTrigger("Stop");
					break;
				case "Roll":
					collisionUnder.GetComponent<ExplodeController>().Explode();
					personage.axis = new Vector2(personage.face.x, 0);
					animator.SetBool("Rolling", true);
					break;
				default:
					personage.Move(personage.face, 2);
					break;
			}
		} else if (!personage.moving && personage.collisionAhead) {
			Collider2D collisionAhead = personage.collisionAhead;
			switch (collisionAhead.tag) {
				case "Solid":
				case "Wall":
					animator.SetTrigger("Crash");
					break;
				default:
					personage.Move(personage.face, 2);
					break;
			}
		} else
			personage.Move(personage.face, 2);
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