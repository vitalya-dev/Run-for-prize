using UnityEngine;
using System.Collections;

public class FreeFly : MonoBehaviour {
	public Vector2 direction;
	public float speed;
	
	void Start() {
		direction = direction.normalized;
	}
	void Update () {
		transform.Translate(direction * speed * Time.deltaTime);
	}
}
