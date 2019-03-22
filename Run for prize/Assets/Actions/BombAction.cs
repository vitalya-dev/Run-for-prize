using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplodeController))]
public class BombAction : Action {
	public LayerMask collisionMask;

	// Update is called once per frame
	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0.0f, collisionMask);
		if (hit && hit.collider.transform.position == this.transform.position) {
			hit.collider.GetComponent<ExplodeController>().Explode();
			GetComponent<ExplodeController>().Explode();
		}
	}

	public override void StartDrag() {
		foreach (var s in GameObject.FindGameObjectsWithTag("Solid")) {
			if (s.GetComponent<HighlightController>() != null)
				s.GetComponent<HighlightController>().highlight = true;
		}
	}

	public override void StopDrag() {
		foreach (var s in GameObject.FindGameObjectsWithTag("Solid")) {
			if (s.GetComponent<HighlightController>() != null)
				s.GetComponent<HighlightController>().highlight = false;
		}
	}
}