using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour {
	private RaycastHit2D hit;

	void Update() {
		// Make sure the user pressed the mouse down
		if (!Input.GetMouseButtonDown(0)) {
			return;
		}

		// We need to actually hit an object
		hit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin,
			Camera.main.ScreenPointToRay(Input.mousePosition).direction);
		if (!hit.collider)
			return;

		StartCoroutine("Drag");
	}

	private IEnumerator Drag() {
		while (Input.GetMouseButton(0)) {
			Vector2 offset = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - hit.point;
			hit.transform.Translate(offset);
			hit.point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			yield return null;
		}
		Vector3 rounded_position = new Vector3(Mathf.RoundToInt(hit.transform.position.x),
			Mathf.RoundToInt(hit.transform.position.y),
			Mathf.RoundToInt(hit.transform.position.z)
		);
		hit.transform.position = rounded_position;
	}
}