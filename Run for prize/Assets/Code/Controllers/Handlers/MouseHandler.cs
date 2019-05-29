using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MouseHandler : HandlerHelper {
	public GameObject highlight_cell_prefab;
	private GameObject highlight_cell;

	public UnityEvent lmb_callback = new UnityEvent();
	public UnityEvent rmb_callback = new UnityEvent();

	void Start() {
		highlight_cell = GameObject.Instantiate(
			highlight_cell_prefab,
			Vector3.zero, 
			Quaternion.identity,
			transform.parent) as GameObject;
	}

	void Update() {
		/* ################################################################## */
		if (Input.GetMouseButtonDown(0))
			lmb_callback.Invoke();

		/* ################################################################## */
		if (Input.GetMouseButtonDown(1))
			rmb_callback.Invoke();
		/* ################################################################## */

		/* ################################################################## */
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
		/* ################################################################## */
	}
}