using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

	public UnityEvent start_callback = new UnityEvent();
	public UnityEvent finish_callback = new UnityEvent();
	public UnityEvent ticktack_callback = new UnityEvent();

	public int sec = 0;

	public float time_factor = 1;

	private bool done = false;

	void Start() {
		start_callback.Invoke();
		StartCoroutine(timer(sec));
	}

	private IEnumerator timer(int s) {
		for (int i = 0; i < s; i++) {
			ticktack_callback.Invoke();
			yield return new WaitForSeconds(1f * time_factor);
		}
		finish_callback.Invoke();
		done = true;
	}

	public void stop() {
		if (!done) {
			StopAllCoroutines();
			finish_callback.Invoke();
			done = true;
		}
	}
}