﻿using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour {
	private GameObject level_backup;

	public bool active {
		get {
			return gameObject.transform.Find("Level").gameObject.activeSelf;
		}
		set {
			gameObject.transform.Find("Level").gameObject.SetActive(value);
			gameObject.transform.Find("Actions").gameObject.SetActive(value);
		}
	}

	public bool complete = false;

	// Use this for initialization
	void Awake() {
		/* ======================================================== */
		GameObject level = transform.Find("Level").gameObject;
		level.SetActive(false);
		/* ======================================================== */
		transform.Find("Actions").gameObject.SetActive(false);
		/* ======================================================== */
		level_backup = GameObject.Instantiate(level, level.transform.position, Quaternion.identity, transform)as GameObject;
		level_backup.SetActive(false);
	}

	public void Restart() {
		/* ================================================================= */
		foreach (Effects effect in FindObjectsOfType<Effects>())
			effect.StopAllCoroutines();
		/* ================================================================= */
		GameObject oldLevel = transform.Find("Level").gameObject;
		/* ================================================================= */
		GameObject newLevel = GameObject.Instantiate(
			level_backup,
			level_backup.transform.position,
			Quaternion.identity,
			transform
		)as GameObject;
		newLevel.SetActive(true);
		newLevel.name = "Level";
		/* ================================================================= */
		GameObject.Destroy(oldLevel);
		/* ================================================================= */
		Transform actions = transform.Find("Actions/Placed");
		for (int i = 0; i < actions.childCount; i++) {
			actions.GetChild(i).gameObject.SetActive(true);
		}
		actions.rotation = Quaternion.Euler(0, 0, 0);
		/* ================================================================= */
		complete = false;
	}

	public void Rotate() {
		GameObject grounds = transform.Find("Level/Grounds").gameObject;
		grounds.GetComponent<Effects>().rotate(.1f);
		GameObject actions = transform.Find("Actions/Placed").gameObject;
		actions.GetComponent<Effects>().rotate(.1f);
	}
}