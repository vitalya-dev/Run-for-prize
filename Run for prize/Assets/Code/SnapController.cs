using System.Collections;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class SnapController : MonoBehaviour {

	void Update() {
		if (Application.isEditor && Selection.activeGameObject == gameObject)
			transform.position = new Vector3(
				Mathf.RoundToInt(transform.position.x),
				Mathf.RoundToInt(transform.position.y),
				Mathf.RoundToInt(transform.position.z)
			);
	}
}