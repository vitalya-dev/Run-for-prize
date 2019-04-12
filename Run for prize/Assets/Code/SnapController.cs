using System.Collections;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SnapController : MonoBehaviour {
	public float snap_x;
	public float snap_y;

	void Start() {
		if (Application.isPlaying)
			enabled = false;
	}

	void Update() {
	if (Selection.activeGameObject == gameObject)
		transform.position = new Vector3(
			Mathf.RoundToInt(transform.position.x) + snap_x,
			Mathf.RoundToInt(transform.position.y) + snap_y,
			Mathf.RoundToInt(transform.position.z)
		);
}
}