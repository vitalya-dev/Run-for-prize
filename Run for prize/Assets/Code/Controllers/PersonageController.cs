using System.Collections;
using UnityEngine;

public class PersonageController : MonoBehaviour {

	[HideInInspector]
	public bool rolling = false;

	public float velocity;

	public Vector2 face {
		get {
			return transform.up;
		}
		set {
			transform.rotation = Quaternion.LookRotation(transform.forward, value);
		}
	}

	public void Roll(float axis, float forsage = 1) {
		if (!rolling)
			StartCoroutine(RollRoutine(
				transform.position + new Vector3(axis, 0, 0),
				Quaternion.LookRotation(transform.forward, axis * transform.right),
				forsage
			));
	}

	private IEnumerator RollRoutine(Vector3 finalPosition, Quaternion finalRotation, float forsage) {
		rolling = true;

		Vector3 positionDeparture = transform.position;
		Quaternion rotationDeparture = transform.rotation;

		float time_needed = Vector3.Distance(positionDeparture, finalPosition) / (velocity * forsage);
		float elapsed_time = 0;

		do {
			elapsed_time += Time.deltaTime;

			transform.position = Vector3.Lerp(positionDeparture, finalPosition, elapsed_time / time_needed);
			transform.rotation = Quaternion.Slerp(rotationDeparture, finalRotation, elapsed_time / time_needed);
			
			yield return null;
		} while (elapsed_time / time_needed < 1);

		// transform.position = finalPosition;
		// transform.rotation = finalRotation;

		rolling = false;
	}
}