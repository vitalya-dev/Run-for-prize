using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {
	public Action[] actions;
	private List<Action> action_list;
	private Vector3 start_position;

	void Start() {
		/* ===================================================================== */
		for (var i = 0; i < actions.Length; i++)
			for (var j = i + 1; j < actions.Length; j++)
				if (actions[i].transform.position.x > actions[j].transform.position.x) {
					var temp = actions[i];
					actions[i] = actions[j];
					actions[j] = temp;
				}
		/* ===================================================================== */
		action_list = new List<Action>(actions);
		/* ===================================================================== */
		start_position = action_list[0].transform.position;
		/* ===================================================================== */
	}

	public Action pop() {
		if (action_list.Count > 0) {
			/* ================================== */
			Action action = action_list[0];
			action_list.RemoveAt(0);
			/* ================================== */
			foreach (var a in action_list) {
				a.transform.Translate(new Vector3(-1, 0, 0));
			}
			/* ================================== */
			return action;
		} else {
			return null;
		}
	}

	public void push(Action action) {
		if (Array.IndexOf(actions, action) != -1) {
			action.transform.position = start_position;
			foreach (var a in action_list)
				a.transform.Translate(new Vector3(1, 0, 0));
			action_list.Insert(0, action);
		}
	}

	public void rotate(float axis) {
		if (axis < 0 && action_list.Count > 0) {
			Action action = pop();
			/* ******************************** */
			action.transform.Translate(new Vector3(action_list.Count, 0, 0));
			/* ******************************** */
			action_list.Add(action);
			/* ******************************** */
		} else if (axis > 0 && action_list.Count > 0) {
			Action action = action_list[action_list.Count - 1];
			/* ******************************** */
			action_list.Remove(action);
			/* ******************************** */
			push(action);
			/* ******************************** */
		}
	}
}