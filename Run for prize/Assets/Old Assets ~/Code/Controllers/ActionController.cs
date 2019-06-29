using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionController : MonoBehaviour {
	public Action[] actions;
	private List<Action> action_list;
	private Vector3 start_position;

	public GameObject placed;

	void Start() {
		for (var i = 0; i < actions.Length; i++) {
			int rnd = Random.Range(0, actions.Length);
			/* ============================================ */
			Vector3 temp = actions[i].transform.position;
			actions[i].transform.position = actions[rnd].transform.position;
			actions[rnd].transform.position = temp;
			/* ============================================ */
		}
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
		if (action_list.Count > 0)
			start_position = action_list[0].transform.position;
		/* ===================================================================== */
	}

	public Action pop(bool change_parent = true) {
		if (action_list.Count > 0) {
			/* ================================== */
			Action action = action_list[0];
			action_list.RemoveAt(0);
			/* ================================== */
			foreach (var a in action_list) {
				a.transform.Translate(new Vector3(-1, 0, 0));
			}
			/* ================================== */
			if (change_parent)
				action.transform.parent = placed.transform;
			/* ================================== */
			return action;
		} else {
			return null;
		}
	}

	public Action first() {
		if (action_list.Count > 0) return action_list[0]; else return null;
	}

	public void push(Action action, bool change_parent = true) {
		if (Array.IndexOf(actions, action) != -1) {
			action.transform.position = start_position;
			if (change_parent)
				action.transform.parent = placed.transform.parent;
			foreach (var a in action_list)
				a.transform.Translate(new Vector3(1, 0, 0));
			action_list.Insert(0, action);
		}
	}

	public void rotate(float axis) {
		if (axis < 0 && action_list.Count > 0) {
			Action action = pop(false);
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
			push(action, false);
			/* ******************************** */
		}
	}
}