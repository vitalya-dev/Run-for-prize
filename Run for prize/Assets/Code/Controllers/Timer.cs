using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

	public UnityEvent callback = new UnityEvent();

	public int sec = 0;

	void Start() {
		StartCoroutine(timer(sec));
	}

	private IEnumerator timer(int s) {
		yield return new WaitForSeconds(s);
		callback.Invoke();
	}
}