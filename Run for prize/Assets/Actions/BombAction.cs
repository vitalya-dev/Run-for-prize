using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplodeController))]
public class BombAction : Action {

	// Update is called once per frame
	void Update() {
		RaycastHit2D hit = raycast4tag(transform.position, Vector2.zero, 0.0f, places);
		if (hit && hit.collider.transform.position == this.transform.position) {
			hit.collider.GetComponent<ExplodeController>().Explode();
			GetComponent<ExplodeController>().Explode();
		}
	}
}