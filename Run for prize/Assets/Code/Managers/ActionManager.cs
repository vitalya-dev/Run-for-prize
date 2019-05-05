using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {
	public Action[] actions;

	private Queue<Action> action_stack;
	private Dictionary<Action, Vector3> actions_pos;

	void Start() {
		action_stack = new Queue<Action>(actions);
		/* ===================================================================== */
		actions_pos = new Dictionary<Action, Vector3>();
		foreach (var action in actions) actions_pos[action] = action.transform.position;
		/* ===================================================================== */
	}

	public Action pop() {
		if (action_stack.Count > 0)
			return action_stack.Dequeue();
		else return null;
	}

	public void push(Action action) {
		action_stack.Enqueue(action);
		action.transform.position = actions_pos[action];

	}
}