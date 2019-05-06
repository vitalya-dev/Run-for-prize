using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {
	private Queue<Action> action_stack;
	private Vector3 start_position;

	void Start() {
		Action[] actions = FindObjectsOfType<Action>();
		/* ===================================================================== */
		for (var i = 0; i < actions.Length; i++)
			for (var j = i + 1; j < actions.Length; j++)
				if (actions[i].transform.position.x > actions[j].transform.position.x) {
					var temp = actions[i];
					actions[i] = actions[j];
					actions[j] = temp;
				}
		/* ===================================================================== */
		action_stack = new Queue<Action>(actions);
		/* ===================================================================== */
		start_position = action_stack.Peek().transform.position;
		/* ===================================================================== */
	}

	public Action pop() {
		if (action_stack.Count > 0) {
			foreach (var action in action_stack) {
				action.transform.Translate(new Vector3(-1, 0, 0));
			}
			return action_stack.Dequeue();
		} else return null;
	}

	public void push(Action action) {
		if (action_stack.Count > 0) {
			action.transform.position = action_stack.Peek().transform.position;
			action.transform.Translate(new Vector3(action_stack.Count, 0, 0));
		} else {
			action.transform.position = start_position;
		}
		action_stack.Enqueue(action);
	}

	public void rotate(float axis) {
		if (axis < 0 && action_stack.Count > 0) {
			push(pop());
		} else if (axis > 0 && action_stack.Count > 0) {
			for (int i = 1; i < action_stack.Count; i++)
				push(pop());	
		}
	}
}