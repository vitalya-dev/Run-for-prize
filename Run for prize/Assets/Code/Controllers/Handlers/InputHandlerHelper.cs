using System.Collections;
using UnityEngine;

public class InputHandlerHelper : MonoBehaviour {

	public void timer_stop_or_level_next() {
		if (GameObject.FindObjectOfType<GameManager>().current_level.complete)
			GameObject.FindObjectOfType<GameManager>().LevelNext();
		else
			GameObject.FindObjectOfType<Timer>().stop();
	}
}