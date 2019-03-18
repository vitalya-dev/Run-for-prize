using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {
	public LayerMask collisionMask;

	// Update is called once per frame
	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0.0f, collisionMask);
		if (hit && hit.collider.transform.position == this.transform.position) {
			hit.collider.GetComponent<ExplodeController>().Explode();
			GameObject.Destroy(gameObject);
		}
	}
}