using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class InputHandler : InputHandlerHelper {
	private bool _disabled = false;
	public bool disabled {
		get {
			return _disabled;
		}
		set {
			_disabled = value;
		}
	}

	public  GameObject highlight_cell_prefab;
	private GameObject highlight_cell;

	public UnityEvent spacekey_callback = new UnityEvent();
	public UnityEvent rkey_callback = new UnityEvent();
	public UnityEvent esc_callback = new UnityEvent();


	void Start() {
		 highlight_cell = GameObject.Instantiate(highlight_cell_prefab, Vector3.zero, Quaternion.identity) as GameObject;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space))
			spacekey_callback.Invoke();
		/* ################################################################## */
		if (Input.GetKeyDown(KeyCode.R))
			rkey_callback.Invoke();
		/* ################################################################## */
		if (Input.GetKeyDown(KeyCode.Escape)) {
			esc_callback.Invoke();
		}
		/* ################################################################## */
		if (Input.GetMouseButtonDown(0) && !disabled) {
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
		if (Input.GetMouseButtonDown(1) && !disabled) {
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
		Action current_action = GameObject.FindObjectOfType<ActionController>().first();
		if (current_action)
			highlight_cell.GetComponent<SpriteRenderer>().sprite = current_action.GetComponent<SpriteRenderer>().sprite;
		else
			highlight_cell.GetComponent<SpriteRenderer>().sprite = null;
		if (disabled)
			highlight_cell.GetComponent<SpriteRenderer>().sprite = null;
		/* ################################################################## */
	}
}