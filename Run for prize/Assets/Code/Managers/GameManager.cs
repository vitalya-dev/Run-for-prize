using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public LevelController[] levels;
	public int current_level;

	public void Start() {
		levels[current_level].active = true;
	}

	public void LevelRestart() {
		levels[current_level].Restart();
	}

	public void LevelNext() {
		StartCoroutine(LevelNextRoutine(1));
	}

	private IEnumerator LevelNextRoutine(float delay) {
		yield return new WaitForSeconds(delay);
		/* ====================================================== */
		levels[current_level].active = false;
		/* ====================================================== */
		current_level += 1;
		levels[current_level].active = true;
		/* ====================================================== */
		Camera.main.transform.position = new Vector3(
			levels[current_level].transform.position.x,
			levels[current_level].transform.position.y,
			Camera.main.transform.position.z
		);
	}
}
