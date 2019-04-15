using UnityEngine;
using System.Collections;

public class ExplodeController : MonoBehaviour {

	public void Explode() {
		Debug.Log("Explode");
		GameObject.Destroy(gameObject);
	}
}
