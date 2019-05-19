using System.Collections;
using UnityEngine;

public class CountdownController : MonoBehaviour {

	public Sprite[] elements;
	
	private int counter = -1;

	public void count_it() {
		/* ======================================= */
		StopAllCoroutines();
		transform.localScale = new Vector3(1, 1, 1);
		/* ======================================= */
		counter += 1;
		/* ======================================= */
		if (counter < elements.Length) {
			GetComponent<SpriteRenderer>().sprite = elements[counter];
			StartCoroutine(make_it_bigger_coroutine());
		}
	}

	private IEnumerator make_it_bigger_coroutine() {
		while (true) {
			transform.localScale += new Vector3(.3f, .3f, 0);
			yield return null;
		}
	}

	public void done() {
		StopAllCoroutines();
		transform.localScale = new Vector3(1, 1, 1);
		GetComponent<SpriteRenderer>().sprite = null;
		counter = -1;
	}
}