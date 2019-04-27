using System.Collections;
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

	// Use this for initialization
	void Awake() {
		GameObject level = transform.Find("Level").gameObject;
		level.SetActive(false);

		level_backup = GameObject.Instantiate(level, Vector3.zero, Quaternion.identity, transform)as GameObject;
		level_backup.SetActive(false);
	}

	public void Restart() {
		GameObject oldLevel = transform.Find("Level").gameObject;

		/* ================================================================= */
		GameObject newLevel = GameObject.Instantiate(
			level_backup,
			level_backup.transform.position,
			Quaternion.identity,
			transform
		)as GameObject;
		newLevel.SetActive(oldLevel.activeSelf);
		newLevel.name = "Level";
		/* ================================================================= */
		GameObject.Destroy(oldLevel);
		/* ================================================================= */
		for (int i = 0; i < transform.childCount; i++) {
			if (transform.GetChild(i).GetComponent<Action>())
				transform.GetChild(i).gameObject.SetActive(true);
		}
		/* ================================================================= */
	}
}