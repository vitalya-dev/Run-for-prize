using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject pause_menu;

	public LevelController[] levels;

	public LevelController current_level {
		get {
			return levels[current_level_index];
		}
	}

	private int current_level_index;

	public void Start() {
		levels[current_level_index].active = true;
		/* ============================================== */
		if (!pause_menu)
			pause_menu = GameObject.Find("Pause Menu");
		pause_menu.SetActive(false);
		/* ============================================== */
	}

	public void LevelRestart() {
		levels[current_level_index].Restart();
		FindObjectOfType<ScoreManager>().Restart();
	}

	public void Pause() {
		Time.timeScale = 1 - Time.timeScale;
		pause_menu.SetActive(Time.timeScale < 1);
	}
	public void LevelNext() {
		StartCoroutine(LevelNextRoutine(1));
	}

	public void LevelComplete() {
		current_level.complete = true;
	}

	private IEnumerator LevelNextRoutine(float delay) {
		yield return new WaitForSeconds(delay);
		/* ====================================================== */
		levels[current_level_index].active = false;
		/* ====================================================== */
		current_level_index += 1;
		levels[current_level_index].active = true;
		/* ====================================================== */
		Camera.main.transform.position = new Vector3(
			levels[current_level_index].transform.position.x,
			levels[current_level_index].transform.position.y,
			Camera.main.transform.position.z
		);
	}
}