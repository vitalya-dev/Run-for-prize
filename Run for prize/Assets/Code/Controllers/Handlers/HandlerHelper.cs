using System.Collections;
using UnityEngine;

public class HandlerHelper : MonoBehaviour {

	public void timer_stop_or_level_next() {
		if (GameObject.FindObjectOfType<GameManager>().current_level.complete)
			GameObject.FindObjectOfType<GameManager>().LevelNext();
		else
			GameObject.FindObjectOfType<Timer>().stop();
	}

	public void place_action() {
		RaycastHit2D hit = Physics2D.Raycast(
			Camera.main.ScreenPointToRay(Input.mousePosition).origin,
			Vector2.zero,
			Mathf.Infinity
		);
		if (!hit.collider) {
			Action action = GameObject.FindObjectOfType<ActionController>().pop();
			if (action) {
				Vector3 pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
				pos = new Vector3(
					Mathf.Floor(pos.x),
					Mathf.Ceil(pos.y),
					Mathf.Round(action.transform.position.z)
				);
				action.transform.position = pos;
			}
		}
	}

	public void remove_action() {
		RaycastHit2D hit = Physics2D.Raycast(
			Camera.main.ScreenPointToRay(Input.mousePosition).origin,
			Vector2.zero,
			Mathf.Infinity
		);
		if (hit.collider && hit.collider.GetComponent<Action>())
			GameObject.FindObjectOfType<ActionController>().push(hit.collider.GetComponent<Action>());
	}

	public void remove_action_or_timer_stop() {
		RaycastHit2D hit = Physics2D.Raycast(
			Camera.main.ScreenPointToRay(Input.mousePosition).origin,
			Vector2.zero,
			Mathf.Infinity
		);
		if (hit.collider && hit.collider.GetComponent<Action>())
			GameObject.FindObjectOfType<ActionController>().push(hit.collider.GetComponent<Action>());
		else
			GameObject.FindObjectOfType<Timer>().stop();
	}

}