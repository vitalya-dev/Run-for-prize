using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour {
	private bool _times_out = false;
	public bool times_out {
		get {
			return _times_out;
		}
		set {
			_times_out = value;
		}
	}

	public GameObject highlight_cell;

	void Update() {
		/* ################################################################## */
		if (Input.GetKeyDown(KeyCode.R))
			GameObject.FindObjectOfType<GameManager>().LevelRestart();
		/* ################################################################## */
		if (Input.GetKeyDown(KeyCode.Escape)) {
			FindObjectOfType<GameManager>().Pause();
		}
		/* ################################################################## */
		if (Input.GetMouseButtonDown(0) && !times_out) {
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
		/* ################################################################## */
		if (Input.GetMouseButtonDown(1) && !times_out) {
			RaycastHit2D hit = Physics2D.Raycast(
				Camera.main.ScreenPointToRay(Input.mousePosition).origin,
				Vector2.zero,
				Mathf.Infinity
			);
			if (hit.collider && hit.collider.GetComponent<Action>())
				GameObject.FindObjectOfType<ActionController>().push(hit.collider.GetComponent<Action>());
		}
		/* ################################################################## */
		highlight_cell.SetActive(true);
		Vector3 highlight_cell_pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
		highlight_cell_pos = new Vector3(
			Mathf.Floor(highlight_cell_pos.x),
			Mathf.Ceil(highlight_cell_pos.y),
			highlight_cell.transform.position.z
		);
		highlight_cell.transform.position = highlight_cell_pos;
		/* ################################################################## */
	}
}