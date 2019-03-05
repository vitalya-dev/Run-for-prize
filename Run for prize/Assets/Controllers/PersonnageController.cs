using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour {

	public LayerMask collisionMask;

	public bool collisionLeft;
	public bool collisionRight;
	public bool collisionAbove;
	public bool collisionBelow;

	public Vector2 velocity;

	public Sprite[] sprites;
	public int sprite_index = 0;

	public Vector2 face {
		get {
			switch (sprite_index) {
				case 0:
					return new Vector2(0, 1);
				case 1:
					return new Vector2(1, 0);
				case 2:
					return new Vector2(0, -1);
				case 3:
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

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, collisionMask);
		if (hit.collider)
			collisionBelow = true;
		else
			collisionBelow = false;

		hit = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, collisionMask);
		if (hit.collider)
			collisionLeft = true;
		else
			collisionLeft = false;

		hit = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, collisionMask);
		if (hit.collider)
			collisionRight = true;
		else
			collisionRight = false;

		hit = Physics2D.Raycast(transform.position, Vector2.up, 0.6f, collisionMask);
		if (hit.collider)
			collisionAbove = true;
		else
			collisionAbove = false;

		sprite_index = sprite_index % sprites.Length;
		if (sprite_index < 0)
			sprite_index = sprites.Length - 1;
		if (transform.GetChild(0).GetComponent<SpriteRenderer>().sprite != sprites[sprite_index])
			transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[sprite_index];
	}

	public void Move(Vector3 distance) {
		transform.position += distance;
	}
}