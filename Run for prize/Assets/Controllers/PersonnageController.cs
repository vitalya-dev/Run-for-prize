using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour {

	[HideInInspector]
	public bool rolling = false;

	public GameObject particlePrefab;

	public LayerMask collisionMask;

	public Collider2D collisionLeft {
		get {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, collisionMask);
			return hit.collider;
		}
	}
	public Collider2D collisionRight {
		get {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, collisionMask);
			return hit.collider;
		}
	}

	public Collider2D collisionAbove {
		get {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.6f, collisionMask);
			return hit.collider;
		}
	}
	public Collider2D collisionBelow {
		get {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, collisionMask);
			return hit.collider;
		}
	}

	public Collider2D collisionAhead {
		get {
			RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3) face, Vector2.zero, 0.1f, collisionMask);
			return hit.collider;
		}
	}

	public float velocity;

	public Vector2 face {
		get {
			return transform.up;
		}
		set {
			transform.rotation = Quaternion.LookRotation(transform.forward, value);
		}
	}

	// Update is called once per frame
	void Update() {
		Debug.DrawRay(transform.position, Vector2.down / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.left / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.right / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.up / 2, Color.red);
	}

	public void Snap() {
		Vector3 rounded_position = new Vector3(
			Mathf.RoundToInt(transform.position.x),
			Mathf.RoundToInt(transform.position.y),
			Mathf.RoundToInt(transform.position.z)
		);
		transform.position = rounded_position;
	}

	public void Roll(float axis) {
		if (!rolling)
			StartCoroutine(RollRoutine(transform.position + new Vector3(axis, 0, 0), Quaternion.LookRotation(transform.forward, axis * transform.right)));
	}

	private IEnumerator RollRoutine(Vector3 finalPosition, Quaternion finalRotation) {
		rolling = true;

		Vector3 positionDeparture = transform.position;
		Quaternion rotationDeparture = transform.rotation;

		float time_needed = Vector3.Distance(positionDeparture, finalPosition) / velocity;
		float elapsed_time = 0;

		while (Vector3.Distance(transform.position, finalPosition) > 0.01f) {
			transform.position = Vector3.Lerp(positionDeparture, finalPosition, elapsed_time / time_needed);
			transform.rotation = Quaternion.Slerp(rotationDeparture, finalRotation, elapsed_time / time_needed);
			elapsed_time += Time.deltaTime;
			yield return null;
		}

		transform.position = finalPosition;
		transform.rotation = finalRotation;
		rolling = false;
	}

	public void Move(Vector2 direction) {
		if (!rolling)
			StartCoroutine(RollRoutine(transform.position + (Vector3)direction, Quaternion.LookRotation(transform.forward, face)));
	}

	public void Explode() {
		for (int i = 0; i < 200; i++) {
			GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
			particle.transform.Translate(new Vector3(0, 0, 1));
			particle.GetComponent<Rigidbody2D>().AddForce(
				new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0f, 1f)) * UnityEngine.Random.Range(200, 1000)
			);
		}
		GameObject.Destroy(gameObject);
	}
}