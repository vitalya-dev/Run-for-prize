﻿using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class PersonageController : MonoBehaviour {

	[HideInInspector]
	public bool rolling = false;

	public bool moving {
		get {
			return rolling;
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

	public LayerMask collisionMask;

	public Collider2D collisionLeft {
		get {
			GetComponent<Collider2D>().enabled = false;
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, collisionMask);
			GetComponent<Collider2D>().enabled = true;
			return hit.collider;
		}
	}

	public Collider2D collisionRight {
		get {
			GetComponent<Collider2D>().enabled = false;
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, collisionMask);
			GetComponent<Collider2D>().enabled = true;
			return hit.collider;
		}
	}

	public Collider2D collisionAbove {
		get {
			GetComponent<Collider2D>().enabled = false;
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.6f, collisionMask);
			GetComponent<Collider2D>().enabled = true;
			return hit.collider;
		}
	}
	
	public Collider2D collisionBelow {
		get {
			GetComponent<Collider2D>().enabled = false;
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, collisionMask);
			GetComponent<Collider2D>().enabled = true;
			return hit.collider;
		}
	}

	public Collider2D collisionAhead {
		get {
			GetComponent<Collider2D>().enabled = false;
			RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3) face, Vector2.zero, 0.1f, collisionMask);
			GetComponent<Collider2D>().enabled = true;
			return hit.collider;
		}
	}

	public void Roll(float axis, float forsage = 1) {
		if (!rolling)
			StartCoroutine(
				RollRoutine(
					transform.position + new Vector3(axis, 0, 0),
					Quaternion.LookRotation(transform.forward, axis * transform.right),
					forsage
				));

	}

	private IEnumerator RollRoutine(Vector3 finalPosition, Quaternion finalRotation, float forsage) {
		rolling = true;

		Vector3 positionDeparture = transform.position;
		Quaternion rotationDeparture = transform.rotation;

		float time_needed = Vector3.Distance(positionDeparture, finalPosition) / (velocity * forsage);
		float elapsed_time = 0;

		do {
			elapsed_time += Time.deltaTime;

			transform.position = Vector3.Lerp(positionDeparture, finalPosition, elapsed_time / time_needed);
			transform.rotation = Quaternion.Slerp(rotationDeparture, finalRotation, elapsed_time / time_needed);

			yield return null;
		} while (elapsed_time / time_needed < 1);

		// transform.position = finalPosition;
		// transform.rotation = finalRotation;

		rolling = false;
	}

	public void Move(Vector2 direction, float forsage = 1) {
		if (!moving)
			StartCoroutine(
				RollRoutine(
					transform.position + (Vector3) direction,
					Quaternion.LookRotation(transform.forward, face),
					forsage
				));
	}
}