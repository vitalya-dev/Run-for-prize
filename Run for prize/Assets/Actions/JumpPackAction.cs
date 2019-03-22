using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPackAction : Action {
	public Vector2 direction;

	public override void StartDrag() {
		foreach (var s in GameObject.FindGameObjectsWithTag("Background")) {
			if (s.GetComponent<HighlightController>() != null)
				s.GetComponent<HighlightController>().highlight = true;
		}
	}

	public override void StopDrag() {
		foreach (var s in GameObject.FindGameObjectsWithTag("Background")) {
			if (s.GetComponent<HighlightController>() != null)
				s.GetComponent<HighlightController>().highlight = false;
		}
	}
}