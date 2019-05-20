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
		}
	}

	public bool complete = false;

	// Use this for initialization
	void Awake() {
		/* ======================================================== */
		GameObject level = transform.Find("Level").gameObject;
		level.SetActive(false);
		/* ======================================================== */
		level_backup = GameObject.Instantiate(level, level.transform.position, Quaternion.identity, transform) as GameObject;
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
		complete = false;
	}

	public void Rotate() {
		GameObject grounds = transform.Find("Level/Grounds").gameObject;
		grounds.GetComponent<Effects>().rotate(.1f);
		GameObject actions = transform.Find("Level/Actions/Placed").gameObject;
		actions.GetComponent<Effects>().rotate(.1f);
	}

	public void vibrate(float bpm) {
		StartCoroutine(vibrate_coroutine(bpm));
	}

	private IEnumerator vibrate_coroutine(float bpm) {
		int k = 1;
		while (true) {
			/* ============================ */
			transform.localScale += new Vector3(0.001f, 0.001f, 0f) * k;
			k *= -1;
			/* ============================ */
			yield return new WaitForSeconds(60.0f / bpm);
		}
	}
}