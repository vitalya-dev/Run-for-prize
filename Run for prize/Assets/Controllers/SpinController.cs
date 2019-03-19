using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (ExplodeController))]
public class SpinController : MonoBehaviour {
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
}