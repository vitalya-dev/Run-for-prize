using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	private GameObject levelClone;
	public bool active {
		get {
			return gameObject.transform.Find("Level").gameObject.activeSelf;
		}
		set {
			gameObject.transform.Find("Level").gameObject.SetActive(value);
		}
	}

	public void Awake() {
		active = false;
		
		GameObject level = transform.Find("Level").gameObject;
		levelClone = GameObject.Instantiate(level, level.transform.position, Quaternion.identity, transform);
	}

	public void Restart() {
		GameObject oldLevel = transform.Find("Level").gameObject;
		//////////////////////////////////////////////////////////
		GameObject newLevel = GameObject.Instantiate(levelClone, levelClone.transform.position, Quaternion.identity, transform);
		newLevel.SetActive(oldLevel.activeSelf);
		newLevel.name = oldLevel.name;
		//////////////////////////////////////////////////////////
		GameObject.Destroy(oldLevel);
		//////////////////////////////////////////////////////////
	}

}