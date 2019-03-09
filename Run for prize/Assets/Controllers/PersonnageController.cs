using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour {

	public GameObject particlePrefab;

	public LayerMask collisionMask;

	public Collider2D collision {
		get {
			if (collisionLeft)
				return collisionLeft;
			else if (collisionRight)
				return collisionRight;
			else if (collisionAbove)
				return collisionAbove;
			else if (collisionBelow)
				return collisionBelow;
			else
				return null;
		}
	}

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

	public void Snap() {
		Vector3 rounded_position = new Vector3(
			Mathf.RoundToInt(transform.position.x),
			Mathf.RoundToInt(transform.position.y),
			Mathf.RoundToInt(transform.position.z)
		);
		transform.position = rounded_position;
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

	public Vector2 velocity;

	public Vector2 face {
		get {
			switch (Mathf.RoundToInt(transform.rotation.eulerAngles.z)) {
				case 0:
					return new Vector2(0, 1);
				case 270:
					return new Vector2(1, 0);
				case 180:
					return new Vector2(0, -1);
				case 90:
					return new Vector2(-1, 0);
				default:
					return new Vector2(0, 0);
			}
		}
		set {
			transform.rotation = Quaternion.LookRotation(transform.forward, value);
		}
	}

	public int euler_face {
		get {
			return Mathf.RoundToInt(transform.rotation.eulerAngles.z);
		}
	}

	// Update is called once per frame
	void Update() {
		Debug.DrawRay(transform.position, Vector2.down / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.left / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.right / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.up / 2, Color.red);
	}

	public void Move(Vector3 distance) {
		transform.position += distance;
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