using UnityEngine;
using System.Collections;

public class CountdownController : MonoBehaviour {

	public Sprite[] elements;

	void Start() {
		do_count();
	}

	public void do_count() {
		StartCoroutine(do_count_coroutine());
	}

	private IEnumerator do_count_coroutine() {
		/* ======================================= */
		Vector2 intial_scale = transform.localScale;
		/* ======================================= */
		for (int i = 0; i < elements.Length; i++) {
			/* ======================================= */
			transform.localScale = intial_scale;
			/* ======================================= */
			GetComponent<SpriteRenderer>().sprite = elements[i];
			StartCoroutine(make_it_bigger_coroutine(1));
			/* ======================================= */
			yield return new WaitForSeconds(1.1f);
		}
		/* ======================================= */
		GetComponent<SpriteRenderer>().sprite = null;
	}

	private IEnumerator make_it_bigger_coroutine(int duration) {
		float flow = 0;
		while (flow < duration) {
			flow += Time.deltaTime;
			transform.localScale += new Vector3(.3f, .3f, 0);
			yield return null;
		}
	}
}
