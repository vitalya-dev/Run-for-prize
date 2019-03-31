using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject[] levels;
	public int current_level;

	public void Restart() {
		StartCoroutine(RestartRoutine());
	}

	private IEnumerator RestartRoutine() {
		yield return new WaitForSeconds(4f);
		levels[current_level].GetComponent<LevelController>().restart();
	}

	public void Next() {
		StartCoroutine(NextRoutine());
	}

	public void Start() {
		if (current_level < levels.Length) {
			Camera.main.transform.position = new Vector3(
				levels[current_level].transform.position.x,
				levels[current_level].transform.position.y,
				Camera.main.transform.position.z
			);
			levels[current_level].GetComponent<LevelController>().active = true;
		}
	}

	private IEnumerator NextRoutine() {
		yield return new WaitForSeconds(4f);

		levels[current_level].GetComponent<LevelController>().active = false;
		current_level += 1;

		if (current_level < levels.Length) {
			Camera.main.transform.position = new Vector3(
				levels[current_level].transform.position.x,
				levels[current_level].transform.position.y,
				Camera.main.transform.position.z
			);
			levels[current_level].GetComponent<LevelController>().active = true;
		}
	}
}