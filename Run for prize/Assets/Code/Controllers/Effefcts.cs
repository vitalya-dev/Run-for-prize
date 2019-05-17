using System.Collections;
using UnityEngine;

public class Effefcts : MonoBehaviour {

	public void rotate(float duration) {
		StartCoroutine(rotate_coroutine(duration));
	}

	private IEnumerator rotate_coroutine(float duration) {
		float time_flow = 0;
		while (time_flow / duration < 1) {
			time_flow += Time.deltaTime;
			transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, 180, time_flow / duration), 0);
			yield return null;
		}
	}

}