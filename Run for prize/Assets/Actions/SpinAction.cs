using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplodeController))]
public class SpinAction : Action {
	public LayerMask collisionMask;

	// Update is called once per frame
	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0.0f, collisionMask);
		if (hit && hit.collider.transform.position == this.transform.position) {
			GameObject o = hit.collider.gameObject;
			o.transform.rotation = Quaternion.LookRotation(o.transform.forward, o.transform.right);
			GetComponent<ExplodeController>().Explode();
		}
	}

	public override void StartDrag() {
		foreach (var s in GameObject.FindGameObjectsWithTag("Player")) {
			if (s.GetComponent<HighlightController>() != null)
				s.GetComponent<HighlightController>().highlight = true;
			if (s.GetComponent<Animator>() != null)
				s.GetComponent<Animator>().enabled = false;

		}
	}

	public override void StopDrag() {
		foreach (var s in GameObject.FindGameObjectsWithTag("Player")) {
			if (s.GetComponent<HighlightController>() != null)
				s.GetComponent<HighlightController>().highlight = false;
			if (s.GetComponent<Animator>() != null)
				s.GetComponent<Animator>().enabled = true;
		}
	}
}