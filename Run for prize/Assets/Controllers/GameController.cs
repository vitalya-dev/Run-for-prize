using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public void Restart() {
		StartCoroutine(RestartRoutine());
	}

	private IEnumerator RestartRoutine() {
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Next() {
		StartCoroutine(NextRoutine());
	}

	private IEnumerator NextRoutine() {
		yield return new WaitForSeconds(4f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}