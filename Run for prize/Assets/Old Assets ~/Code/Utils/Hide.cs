using UnityEngine;
using System.Collections;

public class Hide : MonoBehaviour {
	public float seconds;

	// Use this for initialization
	void Start () {
		StartCoroutine(hide_after(seconds));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator hide_after(float seconds) {
		yield return new WaitForSeconds(seconds);
		gameObject.SetActive(false);
	}
}
