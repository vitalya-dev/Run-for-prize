using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	private GameObject level;
	public bool active {
		get {
			return gameObject.transform.Find("Level").gameObject.activeSelf;
		}
		set {
			gameObject.transform.Find("Level").gameObject.SetActive(value);
		}
	}

	public void Start() {
		GameObject o = transform.Find("Level").gameObject;
		level = GameObject.Instantiate(o, o.transform.position, Quaternion.identity, transform);
	}

	public void restart() {
		GameObject.Destroy(transform.Find("Level").gameObject);
		GameObject o = GameObject.Instantiate(level, level.transform.position, Quaternion.identity, transform);
		o.name = "Level";
		o.SetActive(true);
	}


}
