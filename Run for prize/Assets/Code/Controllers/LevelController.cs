using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour {
	private GameObject level_backup;

	// Use this for initialization
	void Awake() {
		level_backup = GameObject.Instantiate(transform.Find("Level").gameObject, Vector3.zero, Quaternion.identity, transform) as GameObject;
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
		) as GameObject;
		newLevel.SetActive(oldLevel.activeSelf);
		newLevel.name = "Level";
		/* ================================================================= */

		GameObject.Destroy(oldLevel);
	}
}