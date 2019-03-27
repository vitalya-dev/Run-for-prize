using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public bool isActive;

	// Use this for initialization
	void Start() {
		if (isActive)
			gameObject.transform.position = new Vector3(0, 0, -5);
		else
			gameObject.transform.position = new Vector3(0, 0, 5);
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape) && !isActive) {
			gameObject.transform.Translate(new Vector3(0, 0, -10));
			isActive = true;
		} else if (Input.GetKeyDown(KeyCode.Escape) && isActive) {
			gameObject.transform.Translate(new Vector3(0, 0, 10));
			isActive = false;
		}
	}

	public void NewGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}