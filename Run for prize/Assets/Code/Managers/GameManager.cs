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

	[SerializeField]
	private int current_level_index = 0;

	private float pause_time;

	public void Start() {
		levels[current_level_index].active = true;
		/* ============================================== */
		if (!pause_menu)
			pause_menu = GameObject.Find("Pause Menu");
		pause_menu.SetActive(false);
		/* ============================================== */
		Camera.main.transform.position = new Vector3(
			levels[current_level_index].transform.position.x,
			levels[current_level_index].transform.position.y,
			Camera.main.transform.position.z
		);
	}

	public void LevelRestart() {
		Time.timeScale = 1f;
		StopAllCoroutines();
		levels[current_level_index].Restart();
		FindObjectOfType<ScoreManager>().Restart();
	}

	public void LevelRotate() {
		StartCoroutine(SlowMOEffect(0.2f, 0.1f));
		levels[current_level_index].Rotate();
	}

	private IEnumerator SlowMOEffect(float scale, float duration) {
		Time.timeScale = scale;
		yield return new WaitForSeconds(duration);
		Time.timeScale = 1.0f;
	}

	public void Exit() {
		Debug.Log("Quit...");
		Application.Quit();
	}

	public void Pause() {
		if (Time.timeScale > 0) {
			Time.timeScale = 0;
			pause_menu.SetActive(true);
			FindObjectOfType<SoundManager>().PauseMusic(true);
			pause_time = Time.realtimeSinceStartup;
		} else {
			if (Time.realtimeSinceStartup - pause_time < 0.2)
				Application.Quit();
			Time.timeScale = 1;
			pause_menu.SetActive(false);
			FindObjectOfType<SoundManager>().PauseMusic(false);
		}
	}

	public void LevelNext() {
		LevelComplete();
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