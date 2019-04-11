using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBaseFSM : StateMachineBehaviour {
	protected PersonageController personage;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		personage = animator.transform.GetComponent<PersonageController>();
	}
}