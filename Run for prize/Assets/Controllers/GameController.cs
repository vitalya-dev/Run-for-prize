using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject personage;

	public string nextLevel;

	public void Restart() {
		StartCoroutine(RestartRoutine());
	}

	private IEnumerator RestartRoutine() {
		yield return new WaitForSeconds(1f);
		Instantiate(personage);
	}

	public void Next() {
		StartCoroutine(NextRoutine());
	}

	private IEnumerator NextRoutine() {
		yield return new WaitForSeconds(4f);
		SceneManager.LoadScene(nextLevel);
	}

}