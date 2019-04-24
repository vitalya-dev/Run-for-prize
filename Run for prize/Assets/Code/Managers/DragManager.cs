using System.Collections;
using UnityEngine;

public class DragManager : MonoBehaviour {

	void Update() {
		// Make sure the user pressed the mouse down
		if (!Input.GetMouseButtonDown(0)) {
			return;
		}

		// We need to actually hit an object
		RaycastHit2D hit = Physics2D.Raycast(
			Camera.main.ScreenPointToRay(Input.mousePosition).origin,
			Vector2.zero,
			Mathf.Infinity
		);
		if (!hit.collider || hit.collider.GetComponent<Action>() == null)
			return;

		StartCoroutine(Drag(hit));
	}

	private IEnumerator Drag(RaycastHit2D hit) {
		Action action = hit.collider.GetComponent<Action>();

		Vector3 old_pos = hit.transform.position;
		hit.transform.position = new Vector3(old_pos.x, old_pos.y, Camera.main.transform.position.z + 1);

		while (Input.GetMouseButton(0)) {
			Vector2 offset = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - hit.point;
			hit.transform.Translate(offset);
			hit.point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			yield return null;
		}

		Vector3 rounded_position = new Vector3(Mathf.RoundToInt(hit.transform.position.x),
			Mathf.RoundToInt(hit.transform.position.y),
			Mathf.RoundToInt(old_pos.z)
		);
		hit.transform.position = rounded_position;

		yield return null;
	}
}