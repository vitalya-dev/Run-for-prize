using System.Collections;
using UnityEngine;

public class Show : MonoBehaviour {
	public float seconds;

	// Use this for initialization
	void Start() {
		GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
		StartCoroutine(show_after(seconds));
	}

	// Update is called once per frame
	void Update() {

	}

	private IEnumerator show_after(float seconds) {
		yield return new WaitForSeconds(seconds);
		GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
	}
}