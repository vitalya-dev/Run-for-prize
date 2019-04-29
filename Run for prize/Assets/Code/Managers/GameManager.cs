using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public LevelController[] levels;

	public LevelController current_level {
		get {
			return levels[current_level_index];
		}
	}

	private int current_level_index;

	public void Start() {
		levels[current_level_index].active = true;
	}

	public void LevelRestart() {	
		levels[current_level_index].Restart();
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
