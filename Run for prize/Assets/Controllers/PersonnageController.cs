﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour {

	public LayerMask collisionMask;

	public bool collisionLeft {
		get {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, collisionMask);
			return hit.collider;
		}
	}
	public bool collisionRight {
		get {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, collisionMask);
			return hit.collider;
		}
	}
	public bool collisionAbove {
		get {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.6f, collisionMask);
			return hit.collider;
		}
	}
	public bool collisionBelow {
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
}