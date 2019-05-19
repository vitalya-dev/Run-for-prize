using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour {

	public UnityEvent finish_callback = new UnityEvent();
	public UnityEvent ticktack_callback = new UnityEvent();

	public int sec = 0;

	void Start() {
		StartCoroutine(timer(sec));
	}

	private IEnumerator timer(int s) {
		for (int i = 0; i < s; i++) {
			ticktack_callback.Invoke();
			yield return new WaitForSeconds(1);
		}
		finish_callback.Invoke();
	}
}