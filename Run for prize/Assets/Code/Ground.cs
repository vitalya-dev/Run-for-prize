using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class Ground : MonoBehaviour {

	void Update() {
		if (Application.isEditor)
			transform.position = new Vector3(
				Mathf.RoundToInt(transform.position.x),
				Mathf.RoundToInt(transform.position.y),
				Mathf.RoundToInt(transform.position.z)
			);
	}
}