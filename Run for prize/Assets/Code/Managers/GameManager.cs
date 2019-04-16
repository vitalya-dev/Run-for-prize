using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public LevelController[] levels;
	public int current_level;

	public void LevelRestart() {
		levels[current_level].Restart();
	}
}
