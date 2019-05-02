﻿using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.R))
			GameObject.FindObjectOfType<GameManager>().LevelRestart();
		if (Input.GetKeyDown(KeyCode.Escape)) {
			FindObjectOfType<GameManager>().Pause();
		}
	}
}