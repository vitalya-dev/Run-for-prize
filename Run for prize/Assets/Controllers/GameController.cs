using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject personage;

	public void Restart() {
		StartCoroutine(RestartRoutine());
	}

	public IEnumerator RestartRoutine() {
		yield return new WaitForSeconds(1f);
		Instantiate(personage);
	}
}